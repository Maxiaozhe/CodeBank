"use strict";
/**
 * ファイルアップロード用のスクリプト
 */

$(function() {
	$(document).off('dragenter.fileupload-common');
	$(document).on('dragenter.fileupload-common', function (e)
			{
			    e.stopPropagation();
			    e.preventDefault();
			});
	$(document).off('dragover.fileupload-common');
	$(document).on('dragover.fileupload-common', function (e)
			{
			  e.stopPropagation();
			  e.preventDefault();
// this._dropArea.css('border', '2px dotted #0B85A1');
			});
	$(document).off('drop.fileupload-common');
	$(document).on('drop.fileupload-common', function (e)
	{
	    e.stopPropagation();
	    e.preventDefault();
	});
});

/**
 * File Upload Class
 *
 * @param $element (jquery-obj)ファイルアップロードエリアエレメント
 * @param flgReadOnly ファイルのアップロード & 添付済みファイル削除操作不可フラグ。true: 操作不可 (default false)
 */
function FileUploader($element, flgReadOnly) {
	// TODO: readonlyの対応
	var readOnly = (flgReadOnly !== undefined && flgReadOnly !== null)? flgReadOnly: false;
	var uploadFiles = {};
	var deletedList = [];
	const UPLOAD_URL = CONTEXT_PATH + '/util/fileUpload/';
	const MAX_BYTE = 5 * 1024 * 1024;
	const MAX_COUNT = 10;
	const TIMEOUT = 100000;

	/* コンストラクタ */
	// TODO: Drag & Drop, File APIが使えない場合

	// 引数のエレメントが存在しない場合はnullを返す。
	// 存在する場合、ファイルドラッグアンドドロップ領域、添付ファイルの表示領域を作成しインスタンスを返却
	if ($element !== undefined && $element !== null) {
		var $myobj = $element;
		var $dropArea = $('<div>').addClass('file_upload_drop_area').appendTo($myobj);
		var $displayArea = $('<div>').addClass('file_upload_selectedfile_display_area').appendTo($myobj);
		var $displaySelectFilesUl = $('<ul>').addClass('upload_file').appendTo($displayArea);
		var $attachedFileUl = $('<ul>').addClass('attached_file').appendTo($displayArea);

		// 添付操作可能な場合、ドロップエリア、input[type=file]要素を追加
		if (!readOnly) {
			$dropArea.append($('<span>').addClass('lang_jp').text('ファイルをドラッグアンドドロップ'));
			$dropArea.append($('<span>').addClass('lang_en').text('Drag and drop files here'));
			$dropArea.append($('<span>').addClass('lang_cn').text('(中)ファイルをドラッグアンドドロップ'));
			$dropArea.append('<br/>');
			var selectButton = $('<button class="button_selectfile" style="font-size: 50%;">'
					+ '<span class="lang_jp">ファイル選択</span>'
					+ '<span class="lang_en">select file</span>'
					+ '<span class="lang_cn">(中)ファイル選択</span>'
					+ '</button>').appendTo($dropArea);
			selectButton.button();

			var inputFileElm = $('<input type="file" style="display:none;" multiple="multiple"></input>').appendTo($dropArea);

			let lang = getLanguageType();
			$myobj.find('.lang_jp').addClass('hidden');
			$myobj.find('.lang_en').addClass('hidden');
			$myobj.find('.lang_cn').addClass('hidden');
			$myobj.find('.lang_' + lang).removeClass('hidden');

			// DragEnterイベント
			$dropArea.on('dragenter', function (e)
					{
					   e.stopPropagation();
					   e.preventDefault();
					   $(this).css('border-style', 'solid');
					});
			// DragOverイベント
			$dropArea.on('dragover', function (e)
					{
					    e.stopPropagation();
					    e.preventDefault();
					});
			$(document).on('dragover', function (e)
					{
				     	e.preventDefault();
					    e.preventDefault();
					    $dropArea.css('border-style', 'dotted');
					});
			// Dropイベント
			$dropArea.on('drop', function (e)
					{
				// try { TODO: 読み込みエラーのハンドリング
				     e.preventDefault();
				    $(this).css('border-style', 'dotted');

				     let files = e.originalEvent.dataTransfer.files;
				     if (files) {

			    		   // TODO: ファイルサイズチェック エラー
			    		   // ERR_UPLOAD_SIZE_OVER=1ファイルのサイズ制限を超えています(5MB以下)。
				    	   for (let i = 0; i < files.length; i++)
				    	   {
			    			   uploadFiles[files[i].name] = files[i];
				    	   }

				    	   _displayUploadFiles($displaySelectFilesUl);
				     	}

						// } catch (e) {
						// エラーメッセージの表示 終了
						// ERR_UPLOAD_READ=ファイルの内容を読み取れません。
					// }
					});

			// 選択ボタンクリックイベント
			selectButton.on('click', function (e){
			    $(inputFileElm).click();
			    return false;
			});

			// ファイル選択ダイアログ選択後イベント
			inputFileElm.off('change');
			inputFileElm.on('change', function() {
			    // 選択したファイル情報を取得し変数に格納
				// try { TODO: 読み込みエラーのハンドリング
				    let files = $(this).get(0).files;
				     if (files) {
				    	   for (let i = 0; i < files.length; i++)
				    	   {
				    		   // TODO: ファイルサイズチェック エラー
				    		   // ERR_UPLOAD_SIZE_OVER=1ファイルのサイズ制限を超えています(5MB以下)。

				    		   // オブジェクトに値を詰める
			    			   uploadFiles[files[i].name] = files[i];
				    	   }
				    	   //画面にファイルの情報を表示するメソッド
				    	   _displayUploadFiles($displaySelectFilesUl);
				    	   //ファイル選択テキストボックスの値をクリアする
				    	   $(this).val('');
				     	}
				// } catch (e) {
					// エラーメッセージの表示 終了
					// ERR_UPLOAD_READ=ファイルの内容を読み取れません。
				// }
			});
		} else {
			// readonly ドロップエリア、選択されたファイル表示エリアを非表示
			$dropArea.addClass('hidden');
			$displaySelectFilesUl.addClass('hidden');
		}
	} else {
		return null;
	}

	/**
	 * Private Function アップロード選択されたファイル情報を表示します。
	 */
	function _displayUploadFiles($ul) {
		$ul.empty();

		for ( let key in uploadFiles) {
			let $li = $('<li>');
			$li.append($('<p>').addClass('upload_file_name').text(uploadFiles[key].name));
			$li.append($('<p>').addClass('upload_file_info')
						.append($('<span>').addClass('lang_jp').text('(未保存)'))
						.append($('<span>').addClass('lang_en').text('(not saved'))
						.append($('<span>').addClass('lang_cn').text('(not saved)'))
						.append($('<span>').text(_fileSizeFormat(uploadFiles[key].size)))
						);
			let $delButton = $('<p>').addClass('upload_file_delete').text('×')
			.appendTo($li);
			$ul.append($li);

			// ×ボタンクリックイベント登録
			$delButton.off('click');
			$delButton.on('click', function() {
				let delItemKey = $(this).closest('li').find('p.upload_file_name').text();
				delete uploadFiles[delItemKey];
				$li.remove();
			});
		}

		let lang = getLanguageType();
		$ul.find('.lang_jp').addClass('hidden');
		$ul.find('.lang_en').addClass('hidden');
		$ul.find('.lang_cn').addClass('hidden');
		$ul.find('.lang_' + lang).removeClass('hidden');
	};


/*リスエストにファイル形式を詰めてサーブレットで判断し処理を分岐する
レスポンスのコンテンツタイプを取得し、成功時の処理の分岐を行う*/

	/**
	 * Private Function ファイルサイズ表記をフォーマットします。
	 */
	function _fileSizeFormat(fileSize) {
		let result = '';
		if (fileSize < Math.pow(1024, 2)){ // 1MB未満
			let calcByte = Math.ceil(fileSize / 1024);
			result = calcByte + 'KB';
		} else if (fileSize <  Math.pow(1024, 2) * 100){ // 1MB ～ 100MB
			let calcByte = Math.ceil(fileSize / Math.pow(1024, 2) * Math.pow(10, 1)) / Math.pow(10, 1) ;
			result = calcByte + 'MB';
		} else if (fileSize <  Math.pow(1024, 3)){ // 100MB ～ 1GB
			let calcByte = Math.ceil(fileSize / Math.pow(1024, 2) * Math.pow(10, 1));
			result = calcByte + 'MB';
		} else if (fileSize <  Math.pow(1024, 4)){ // 1GB ～ 1TB
			let calcByte = Math.ceil(fileSize / Math.pow(1024, 3) * Math.pow(10, 1)) / Math.pow(10, 1) ;
			result = calcByte + 'GB';
		} else if (fileSize <  Math.pow(1024, 4)){ // 1TB ～
			let calcByte = Math.ceil(fileSize / Math.pow(1024, 4) * Math.pow(10, 1));
			result = calcByte + 'TB';
		}
		return result;
	}

	function _fileUpload (gid, defferd) {

		//リクエストに値を詰める
		let formData = new FormData();
		//苦情番号、ファイルの並び順の情報などを追加する
		if (gid === null) {
			formData.append('fgid', '');
		} else {
			formData.append('fgid', gid);
		}

		//アップロードするファイルの中身をリクエストに詰める
		let fileCount = 0;
		for(let key in uploadFiles){
			// ファイルデータを設定
    		formData.append('file' + fileCount++, uploadFiles[key]);
		}

		if (fileCount > 0) {
			//サーブレットへ送信するメソッド

			// ファイル送信
			$.ajax({
				url : UPLOAD_URL,
				type : "POST",
				timeout : TIMEOUT,
				contentType : false,
				processData : false,
				cache : false,
				override: true,
				data : formData,
				headers: {
//					"Content-Type": "multipart/mixed",
					"Content-Type": "multipart/form-data"
				},
				success : function(data){
					console.log("upload success! " + data);
					// ファイルグループIDを返却
					defferd.resolve(data);
				},
				error : function(jqXHR, settings, exception) {
					hideProcessingLayer();


					// TODO: エラーハンドリング
//	    				ERR_FILE_TOOMANY=ファイル数が多すぎます。\n1つの苦情に対して添付できるファイル総数は10個までです。
//	    				ERR_FILE_TOOBIG=ファイルサイズが大きすぎます。\n1つの苦情に対して添付できるファイル総サイズは20MBまでです。
//	    				ERR_UPLOAD_FAILURE=予期せぬ理由でアップロードに失敗しました。
					// エラー → そのまま ERR_UPLOAD_FAILURE
					//timeout → そのまま タイムアウト

					if (jqXHR.status) {
						let statusCode = parseInt(jqXHR.status);

						switch (statusCode) {
							case 401:		// 未ログイン → ログイン画面遷移 ERR_NOLOGIN
								errorDialog = showErrorMessageDialog(APP_MASSAGES[getLanguageType()]['ERR_NOLOGIN']);
								errorDialog.then(
									function () {
										showProcessingLayer();
						        		window.location.href = CONTEXT_PATH + '/action/login/';
						        		return false;
									}
								);
								break;
							case 403:		// 権限なし → ERR_NORIGHT
								errorDialog = showErrorMessageDialog(APP_MASSAGES[getLanguageType()]['ERR_NORIGHT']);
								errorDialog.then(
									function () {
										// TODO: 確認 ファイル削除? して後続処理?
//										showProcessingLayer();
//						        		window.location.href = errorPageUrl;
//						        		return false;
									}
								);
								break;
							default:		// その他 エラー
								errorDialog = showErrorMessageDialog(APP_MASSAGES[getLanguageType()]['ERR_UPLOAD_FAILURE']);
								errorDialog.then(
									function () {
										// 失敗として後続処理を中止
										 defferd.reject();
									}
								);
								break;
						};
					 } else if (exception === 'timeout') {
						 // タイムアウトした時の処理
						showErrorMessageDialog(APP_MASSAGES[getLanguageType()]['ERR_AJAX_TIMEOUT']);
						// 失敗として終了
						defferd.reject();

					 } else if (exception === 'abort') {
					    // Ajax通信をキャンセルした時の処理
						errorDialog = showErrorMessageDialog(APP_MASSAGES[getLanguageType()]['ERR_UPLOAD_FAILURE']);
						// 失敗として終了
						defferd.reject();

					 } else {
					    // その他のエラー
						errorDialog = showErrorMessageDialog(APP_MASSAGES[getLanguageType()]['ERR_UPLOAD_FAILURE']);
						// TODO: どうする？？
						// ① 失敗として後続処理を中止
						 defferd.reject();
						// ② ファイルを削除し、後続処理を実行させる ?
						// defferd.resolve(gid);
					 }
				}
			});
    	} else {
    		// 1件もファイルが添付されていない場合は成功として終了
			defferd.resolve(gid);
			return;
    	}
	}

	/**
	 * Private Function ファイルをダウンロードします。
	 */
	function fileDownload(fileId, fileName){
		// TODO: ファイルダウンロード処理
//		ERR_NOLOGIN_DWLD=ログイン情報が確認できません。\n再度ログイン画面からログインを行ってください。

//		alert(fileId);
//		alert(fileName);

		// リスエストにデータを詰める
		let formData = new FormData();
		formData.append('id',111);
		formData.append('file',"fileName");

		var URL = CONTEXT_PATH + '/util/fileDownload/';

		$.ajax({
			url : URL,
			type : "POST",
			contentType : false,
			processData : false,
			cache : false,
			data : formData,
			success : function(response){
				var blobObject = new Blob([ response ], "text/csv");// ファイル形式は変わる
				window.navigator.msSaveBlob(blobObject,fileName);
						//'msSaveBlob_testFile.csv');// 名前
				return false;
			}});
	};

    let Instance = function(){};
    /**
	 * Public Methods 添付済みファイルを描画します。
	 *
	 * @param fileId: ファイルId
	 * @param fileName: ファイル名
	 * @param uploadDate: 登録日 (yyyy/MM/dd HH:mm:ss.SSS)
	 * @param fileSize: ファイルサイズ(Byte)
	 * @param registUser: 登録ユーザー名{jp: en: cn}
	 */
    Instance.prototype.drawAttachedFile = function(fileId, fileName, registDate, fileSize, registUser) {
    	let hrefVal = '#';
		let $li = $('<li>')
		.append($('<a>').prop('href', hrefVal).text(fileName))
		.append($('<p>').addClass('attached_file_info')
			.append($('<span>').text(registDate.substring(0, 10) + ' ' + _fileSizeFormat(fileSize) + ' '))
			.append($('<span>').addClass('lang_jp').text(registUser.jp))
			.append($('<span>').addClass('lang_en').text(registUser.en))
			.append($('<span>').addClass('lang_cn').text(registUser.cn))
		).appendTo($attachedFileUl);

		// ファイルダウンロードイベントの登録
		$li.on('a', 'click', function(){
			fileDownload(fileId, fileName);
			return false;	// aタグのイベント伝播を行わない
		});

		if (!readOnly) {
			let $delButton = $('<p class="attached_file_delete">×</p></li>').appendTo($li);

			// ×ボタンクリックイベント登録
			$delButton.on('click', function() {
				let message = APP_MASSAGES[getLanguageType()]['INF_DELETE'];
				let confDialog = showConfirmMessageDialog(message);
				confDialog.then(
					function() {
						$li.remove();
						deletedList.push(fileId);
					},
					function() {
						return false;
					}
				);
			});
		}

		$li.find('.lang_jp').addClass('hidden');
		$li.find('.lang_en').addClass('hidden');
		$li.find('.lang_cn').addClass('hidden');
		$li.find('.lang_' + getLanguageType()).removeClass('hidden');
    };

    /**
	 * Public Methods TODO: ファイルをサーバーにアップロードします。
	 */
    Instance.prototype.fileUpload = function(fileGroupId) {
    	// TODO: 同期化できるように $.Deferred()オブジェクトを生成しreturnする
    	let resultDef = new $.Deferred();
    	_fileUpload(fileGroupId, resultDef);
    	return resultDef.promise();
    };

    /**
	 * Public Methods TODO: 添付済みファイルで削除操作されたファイルリストを取得します。
	 */
    Instance.prototype.getDeletedFileList = function() {
    	return deletedList;
    };

    return new Instance();
};

