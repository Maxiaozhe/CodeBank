///<reference path="jquery-3.3.1.js" />
'use strict';
const iwbApp = {};
(function ($) {
    iwbApp.clientID = getUniqueID(1000);
    /**
     * WebScoket Client 登録
     * @param {string} wshost:ws://localhost:8080の形式
     * @returns {WebSocket} wensocket
     */
    function wsClientRegist(wshost) {
        //let ws = new WebSocket(wshost);
        //let clientID = iwbApp.clientID;

        //ws.onopen = function (e) {
        //    console.log('Connection to server opened=>' + 'clientID: ' + clientID);
        //    sendMessage('ping');
        //};
        //ws.onmessage = function (event) {
        //    //console.log('Client received a message', event.data);
        //   // $("#result").html(showResult(event.data));
        //    let data = event.data;
        //    if (typeof data === 'string' && data === 'pong') {
        //        $("#wsstate").prop('class', 'connecting');
        //        return;
        //    }
        //    jumpToUrl(event.data);
        //};  
        //ws.onclose = function (e) {
        //    console.log('connection closed.');
        //};
        var lockReconnect = false;  //reconnect locker
        let clientID = iwbApp.clientID;
        let ws = createWebSocket();
        function createWebSocket() {
            try {
                let wsclient = new WebSocket(wshost);
                wsclient.onopen = function (e) {
                    console.log('Connection to server opened=>' + 'clientID: ' + clientID);
                    sendMessage('ping');
                };
                wsclient.onmessage = function (event) {
                    //console.log('Client received a message', event.data);
                    let data = event.data;
                    if (typeof data === 'string' && data === 'pong') {
                        $("#wsstate").prop('class', 'connecting');
                        return;
                    }
                    jumpToUrl(event.data);
                };
                wsclient.onclose = function (e) {
                    console.log('connection closed.');
                    reconnect();
                };
                return wsclient;
            } catch (ex) {
                console.error(ex);
                reconnect();
            }
        }

        function sendMessage(state, data) {
            let msg = {
                id: clientID,
                state: state,
                type:'iwb',
                data: data
            };
            ws.send(JSON.stringify(msg));
        }

        //reconnect
        function reconnect() {
            if (lockReconnect) return;
            lockReconnect = true;
            $("#wsstate").prop('class', 'closed');
            setTimeout(function () {
                iwbApp.clientID = getUniqueID(1000);
                clientID = iwbApp.clientID;
                ws = createWebSocket();
                lockReconnect = false;
            }, 2000);
        }

        //Hard check
        var heartCheck = {
            timeout: 540000,
            timeoutObj: null,
            serverTimeoutObj: null,
            reset: function () {
                clearTimeout(this.timeoutObj);
                clearTimeout(this.serverTimeoutObj);
                return this;
            },
            start: function () {
                var self = this;
                this.timeoutObj = setTimeout(function () {
                    sendMessage("ping");
                    console.log("ping!");
                    self.serverTimeoutObj = setTimeout(function () {
                        $("#wsstate").prop('class', 'closed');
                        ws.close();
                    }, self.timeout);
                }, this.timeout);
            }
        };

        return ws;
    }

    function jumpToUrl(strJson) {
        let data = {};
        try {
            data = JSON.parse(strJson);
        } catch (ex) {
            return;
        }
        if (data && data.url) {
            $("iframe.display").attr("src", data.url);
        }
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
        if (response.fullMatchingImages && response.fullMatchingImages.length>0) {
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

    iwbApp.wsClientRegist = wsClientRegist;

})(jQuery);
