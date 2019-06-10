///<reference path="jquery-3.3.1.js" />
///<reference path="megapix-image.js" />

const client = {};
(function ($) {

    client.clientID = getUniqueID(1000);

    $.fn.extend({
        /**
         *ファイルアップロードコンボ作成
         * @param {Element} fileInput ファイル入力フィールド
         * @returns {any} filePicker
         * 
         */
        fileUploader: function (fileInput) {
            var filePicker = $(this);
            filePicker.attr('dropzone', 'copy file:');
            filePicker.on('dragenter', function (e) {
                e.stopPropagation();
                e.preventDefault();
                $(filePicker).addClass('dragover');
            }).on('dragover', function (e) {
                e.stopPropagation();
                e.preventDefault();
            }).on('drop', function (e) {
                $(filePicker).removeClass('dragover');
                e.preventDefault();
                var files = e.originalEvent.dataTransfer.files;
                uploadImage(files[0], function () {
                    //アップロード処理完了
                    alert("Uploaded!!!!");
                });
            }).on('dragout', function (e) {
                $(filePicker).removeClass('dragover');
                e.stopPropagation();
                e.preventDefault();
            });

            $(fileInput).on("change", function () {
                let files = $(this).get(0).files;
                if (files) {
                    // アップロード処理を行うメソッド
                    uploadImage(files[0], function () {
                        //アップロード処理完了
                        alert("Uploaded!!!!");
                    });
                }
            });

            filePicker.on("click", function () {
                $(fileInput).get(0).click();
            });

            $(document).on('dragenter dragover drop', function (e) {
                e.stopPropagation();
                e.preventDefault();
            });
            return filePicker;
        }
    });

    /**
    *(内部関数)AJAXでファイルアップロードする
    * @param {File[]} files ファイル配列
    * @param {Function} callback callback関数
    */
    function handleFileUpload(files, callback) {
        let successCount = 0;
        for (var i = 0; i < files.length; i++) {
            let file = files[i];
            let formData = new FormData();
            formData.append('file', file);
            var uploadURL = "./upload"; //Upload URL
            var jqXHR = $.ajax({
                url: uploadURL,
                type: "POST",
                contentType: false,
                processData: false,
                cache: false,
                data: formData,
                success: function (data) {
                    callback(data);
                }.bind(file),
                error: function (data) {
                    alert(data);
                }
            });
        }
    }

    /**
    *(内部関数)AJAXでファイルアップロードする
    * @param {Blob} blob blobデータ
    * @param {string} name ファイル名
    * @param {Function} callback callback関数
    */
    function handleImgUpload(blob, name, callback) {
        let successCount = 0;
        let formData = new FormData();
        formData.append('file', blob, name);
        formData.append('clientID', client.clientID);
        var uploadURL = "./upload"; //Upload URL
        var jqXHR = $.ajax({
            url: uploadURL,
            type: "POST",
            contentType: false,
            processData: false,
            cache: false,
            //           mimeType: "multipart/form-data",
            data: formData,
            success: function (data) {
                callback(data);
            },
            error: function (data) {
                let error = JSON.stringify(data);
                alert(error);
            }
        });
    }

    /* on Page Loaded */
    $(function () {
        //画像
        $("#droparea").fileUploader($("#fileupload"));
    });

    /**
     * 画像を圧縮してアップロードする
     * @param {File} imageFile 画像ファイル
     * @param {Function} callback Callback関数
     */
    function uploadImage(imageFile, callback) {
        let reader = new FileReader();
        let img = new Image();
        $(reader).on("load", function (e) {
            img.src = e.target.result;
        });
        $(img).on("load", function () {
            let orgW = this.width;
            let orgH = this.height;
            let maxW = 2048, maxH = 2048;
            let rate = orgW / orgH;
            let targetW = orgW, targetH = orgH;
            if (rate > 1.0) {
                if (orgW > maxW) {
                    targetW = maxW;
                    targetH = targetW / rate;
                }
            } else {
                if (orgH > maxH) {
                    targetH = maxH;
                    targetW = targetH * rate;
                }
            }
            let canvas = document.createElement("canvas");
            //let context = canvas.getContext("2d");
            //canvas.width = targetW;
            //canvas.height = targetH;
            //context.clearRect(0, 0, targetW, targetH);
            //context.drawImage(img, 0, 0, targetW, targetH);
            let magaImg = new MegaPixImage(img);
            magaImg.render(canvas, { width: targetW, height: targetH });
            let imgData = canvas.toBlob(function (bolb) {
                handleImgUpload(bolb, imageFile.name, callback);
            }, imageFile.type);
        });
        reader.readAsDataURL(imageFile);
    }


    /**
      * WebScoket Client 登録
      * @param {string} wshost:ws://localhost:8080の形式
      * @returns {WebSocket} WebSocket
      */
    function wsClientRegist(wshost) {
        let ws = new WebSocket(wshost);
        let clientID = client.clientID;

        ws.onopen = function (e) {
            console.log('Connection to server opened=>' + 'clientID: ' + clientID);
            sendMessage('opened');
        };
        ws.onmessage = function (event) {
            //console.log('Client received a message', event.data);
            $("#result").html(showResult(event.data));
        };
        ws.onclose = function (e) {
            console.log('connection closed.');
        };
        function sendMessage(state, data) {
            let msg = {
                id: clientID,
                state: state,
                type: 'sd',
                data: data
            };
            ws.send(JSON.stringify(msg));
        }
        return ws;
    }


    function showResult(strJson) {
        let data = {};
        try {
            data = JSON.parse(strJson);
        } catch (ex) {
            return strJson;
        }
        let response = data;
        let labelAnnotations = response.labelAnnotations;
        let webEntities = response.webEntities;
        let visuallySimilarImages = response.visuallySimilarImages;
        let bestGuessLabels = response.bestGuessLabels;
        let fullMatchingImages = [];
        let SimilarImages = [];
        if (response.fullMatchingImages && response.fullMatchingImages.length > 0) {
            fullMatchingImages.push(response.fullMatchingImages[0]);
        }
        if (response.partialMatchingImages) {
            response.partialMatchingImages.forEach(function (item) {
                SimilarImages.push(item);
            });
        }
        if (response.visuallySimilarImages) {
            response.visuallySimilarImages.forEach(function (item) {
                SimilarImages.push(item);
            });
        }

        let htmls = [];
        htmls.push("<div class='best-guess-label'>" + bestGuessLabels[0].label + "</div>");
        if (fullMatchingImages.length > 0) {
            htmls.push("<img class='full-matching-image' src='" + fullMatchingImages[0].url + "' >");
        }
        $(labelAnnotations).each(function () {
            htmls.push("<div class='label-annotation'>" + this.description + "</div>");
        });
        if (response.fullTextAnnotation) {
            htmls.push("<div class='fulltext-annotation'>" + response.fullTextAnnotation + "</div>");
        }
        $(webEntities).each(function () {
            htmls.push("<div class='web-entitie'>" + this.description + "</div>");
        });
        $(SimilarImages).each(function () {
            htmls.push("<img class='similar-images' src='" + this.url + "' >");
        });
        return htmls.join("");
    }


    function getUniqueID(myStrong) {
        let strong = 1000;
        if (myStrong) strong = myStrong;
        return new Date().getTime().toString(16) + '-' + Math.floor(strong * Math.random()).toString(16);
    }

    //Export
    client.wsClientRegist = wsClientRegist;


}(jQuery));
