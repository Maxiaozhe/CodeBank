/// <reference path="../pulugins/jquery-3.2.1.js" />
/// <reference path="../pulugins/jquery-ui.js" />
/// <reference path="common.js" />
/// <reference path="dialogs/masterSelectDialog.js" />

"use strict";
$(function () {

    //ダイアログ種別
    const dialogEnum = {
        /**BUnit(マスタメンテ)*/
        BUnit: 14,
        /**SBUマスタ(マスタメンテ)*/
        SBU: 15,
        //得意先グループマスタ
        CUST_GROUP: 16,
        //回答部門マスタ
        ANSWER_DEPARTMENT: 6,
        //拠点
        MFGLOCATION: 13,
    }

    //マスタ情報リスト
    const mstList = {
        /** 担当者関連 */
        // SBU担当QA（顧客）:MST_QA_GROUP
        QA_GROUP_SBU_QA: { id: 0, fileName: 'qaGroup_sbuQa.csv' },
        // 営業QA担当者（顧客）:MST_QA_GROUP
        QA_GROUP_SALES_QA: { id: 1, fileName: 'qaGroup_salesQa.csv' },
        // 物流QA担当者（顧客）:MST_QA_GROUP
        QA_GROUP_PD_QA: { id: 2, fileName: 'qaGroup_pdQa.csv' },
        // 技術部門（顧客）:MST_QA_GROUP
        QA_GROUP_TECHNICAL_QA: { id: 3, fileName: 'qaGroup_technicalQa.csv' },
        // QA担当者(購買):MST_QA_GROUP
        QA_GROUP_QA: { id: 4, fileName: 'qaGroup_qa.csv' },
        // 資材担当者：MST_TPO_GROUP
        TPO_GROUP: { id: 5, fileName: 'tpoGroup.csv' },
        /** 回答部門関連 */
        // 回答部門マスタ:MST_RESPONSE_DEPT
        RESPONSE_DEPT: { id: 6, fileName: 'tpoGroup.csv' },
        // 回答部門担当者マスタ(MST_RESPONSE_DEPT_PIC)
        RESPONSE_DEPT_PIC: { id: 7, fileName: 'responseDept.csv' },
        /** メール関連 */
        // ランク別メール送信先マスタ:MST_MAIL_RANK
        MAIL_RANK: { id: 8, fileName: 'mailRank.csv' },
        // 得意先グループ別メール送信先マスタ:MST_MAIL_CUST_GROUP
        MAIL_CUST_GROUP: { id: 9, fileName: 'mailCustGroup.csv' },
        /** 回答管理項目 */
        // 苦情分類:MST_INVESTIGATION_SUMMARY
        INVESTIGATION_SUMMARY_COMPLAINT: { id: 10, fileName: 'investigationSummary_Complaint.csv' },
        // 不具合分類:MST_INVESTIGATION_SUMMARY
        INVESTIGATION_SUMMARY_DEFECTIVE: { id: 11, fileName: 'investigationSummary_Defective.csv' },
        // 発生原因:MST_INVESTIGATION_SUMMARY
        INVESTIGATION_SUMMARY_CAUSE: { id: 12, fileName: 'investigationSummary_Cause.csv' },
        // 変化点の有無:MST_INVESTIGATION_SUMMARY
        INVESTIGATION_SUMMARY_CHANGE: { id: 13, fileName: 'investigationSummary_Change.csv' },
        // 発生工程:MST_INVESTIGATION_SUMMARY
        INVESTIGATION_SUMMARY_GENERATION_PROCESS: { id: 14, fileName: 'investigationSummary_GenerationProcess.csv' },
        /** 事業所 */
        // 製造元マスタ:MST_PRODUCTION
        PRODUCTION: { id: 15, fileName: 'production.csv' },
        // 営業所マスタ:MST_SALES_OFFICE
        SALES_OFFICE: { id: 16, fileName: 'salesOffice.csv' },
        // 外部事業所マスタ：MST_OUTSIDE_OFFICE
        OUTSIDE_OFFICE: { id: 17, fileName: 'outsideOffice.csv' },
        // 資材拠点：MST_TPO_OFFICE
        TPO_OFFICE: { id: 18, fileName: 'tpoOffice.csv' },
        // 出荷情報関連
        // 配送業者：MST_SEND_CORP
        PD_SEND_CORP: { id: 19, fileName: 'mstSendCorp.csv' },
        // 包装形態：MST_PACKAGE_STYLE
        PD_PACKAGE: { id: 20, fileName: 'mstPackageStyle.csv' },
        // 傭者：MST_PD_EMPLOY
        PD_EMPLOY: { id: 21, fileName: 'mstPdEmploy.csv' },
        // 港：MST_PD_PORT
        PD_PORT: { id: 22, fileName: 'mstPdPort.csv' },
        // I/V：MST_PD_IV
        PD_IV: { id: 23, fileName: 'mstPdIv.csv' },
        /**Idで情報を取得する*/
        getById: function (selectedId) {
            let mstId = Number(selectedId);
            for (let fld in this) {
                if (!this.hasOwnProperty(fld) || fld === 'getById') continue;
                if (this[fld].id === mstId) {
                    return this[fld];
                }
            }
            return null;
        }
    };


    /** アップロード処理を行うメソッド*/
    function handleFileUpload(files, callback) {

        // ファイル拡張子を取得する
        // 最初にファイル名を取得する
        let fileName = files[0].name;
        // .で分割し配列とする
        let dividedList = fileName.split(".");
        // ファイル名に.が使用可能なため、最後の要素を取得する
        let fileType = dividedList[dividedList.length - 1];

        // csvファイルを選択しているかを確認する。
        if (fileType.match(/csv/i)) {

            let formData = new FormData();

            // 通信用データにファイルの内容を追加する
            formData.append('file', files[0]);
            formData.append('fileType', fileType);

            // サーブレットへ送信するメソッド
            sendFileToServer(formData, callback);
        } else {
            // csvファイルを選択していない場合、警告する
            showErrorMessageDialog("csvファイルを選択してください。");
            if (callback) { callback(); }
        }

    }

    // サーブレットへ送信するメソッド
    function sendFileToServer(formData, callback) {
        // 送信先のURLを指定する
        const UPLOAD_URL = CONTEXT_PATH + '/action/mstFileUpload/';

        // ajax通信を行う
        $.ajax({
            url: UPLOAD_URL,
            type: "POST",
            contentType: false,
            processData: false,
            cache: false,
            data: formData,
            success: function (data) {
                showInfoMessageDialog("アップロードが完了しました。");
            },
            complete:callback,
        });
    }

    /**
     * #main の高さをWindowサイズに合わせて変更します。
     */
    function resizeMainContainer() {
        let bodyHeight = parseFloat($(window).height());
        let bodyMarginTop = parseFloat($('body').css('margin-top'));
        // body height をヘッダー部分を除いた高さに設定
        $('body').css('height', bodyHeight - bodyMarginTop + 'px');
        //
        // // メインコンテナ部分の高さを設定
        // let containerHeight = parseFloat($('body').height());
        // containerHeight -= parseFloat($('#containerInner').css('margin-top'))
        // + parseFloat($('#containerInner').css('margin-bottom'));
        // containerHeight -= parseFloat($('#containerInner').css('padding-top'))
        // + parseFloat($('#containerInner').css('padding-bottom'));
        // containerHeight -=
        // parseFloat($('#containerInner').css('border-top-width'))
        // + parseFloat($('#containerInner').css('border-bottom-width'));
        // $('#container').css('height', containerHeight + 'px');
        // $('#containerInner').css('height', containerHeight + 'px');
    }

    /**
     * 不良部品一覧ページ独自の言語設定変更イベントメソッド TODO: 削除
     */
    function langChangeDefectivePartsListPage() {

        // /* 検索条件詳細ダイアログの言語変更 */
        // setSearchDetailDialogLangage(langType);
    };

    //オプション情報を設定する
    function getOptions(opts) {
        let retOpts = {
            term: false,
            sbuCode: false,
            mfgLocation: false,
            divSub: false,
            responseDeptCode: false,
            custGroupCode: false
        };
        if ('term' in opts) { retOpts.term = true; }
        if ('sbuCode' in opts) { retOpts.sbuCode = true; }
        if ('mfgLocation' in opts) { retOpts.mfgLocation = true; }
        if ('divSub' in opts) { retOpts.divSub = true; }
        if ('responseDeptCode' in opts) { retOpts.responseDeptCode = true; }
        if ('custGroupCode' in opts) { retOpts.custGroupCode = true; }
        return retOpts;
    }
    /**マスタ情報を取得*/
    function getMstInfo(selectedId) {
        let mstId = Number(selectedId);
        if (mstId >= mstList.QA_GROUP_SBU_QA.id
          && mstId <= mstList.QA_GROUP_QA.id) {
            //管理担当者グループ
            return getOptions({
                term: true,    //期
                sbuCode: true, //SBU
                mfgLocation: true, //拠点
            });
        }
        if (mstId === mstList.TPO_GROUP.id) {
            //資材担当者グループ
            return getOptions({
                divSub: true, //B.Unit
                term: true, //期
            });
        }
        if (mstId === mstList.RESPONSE_DEPT.id) {
            //回答部門マスタ
            return getOptions({
                term: true,
                divSub: true, //B.Unit
            });
        }
        if (mstId === mstList.RESPONSE_DEPT_PIC.id) {
            //回答部門担当者マスタ
            return getOptions({
                term: true,
                responseDeptCode: true, //回答部門
            });
        }
        if (mstId === mstList.MAIL_RANK.id) {
            //ランク別メール送信先マスタ
            return getOptions({
                term: true,
                divSub: true, //B.Unit
            });
        }
        if (mstId === mstList.MAIL_CUST_GROUP.id) {
            //得意先グループ別メール送信先マスタ
            return getOptions({
                custGroupCode: true, //得意先グループ
            });
        }

        if (mstId >= mstList.INVESTIGATION_SUMMARY_COMPLAINT.id
        && mstId <= mstList.INVESTIGATION_SUMMARY_GENERATION_PROCESS.id) {
            //回答管理項目マスタ
            return getOptions({
                term: true,    //期
                divSub: true, //B.Unit
            });
        }
        if (mstId === mstList.PRODUCTION.id
        || mstId === mstList.SALES_OFFICE.id) {
            //製造元マスタ||営業所マスタ
            return getOptions({
                term: true,    //期
            });
        }
        //その他パラメタなし
        return getOptions({});

    }
    /**マスタIDによる検索条件ON/OFF設定*/
    function setMstOption(mstId) {
        let opts = getMstInfo(mstId);
        //一括出力ボタンON/OFF
        $('#btn_master_maintenance_batch_export').button({ disabled: (mstId === undefined) })
        //期
        if (opts.term) {
            $('#select_term').selectmenu('enable');
        } else {
            $('#select_term').selectmenu('disable');
        }
        //SBU
        $('#btn_master_maintenance_sbu').button({ disabled: !opts.sbuCode });
        if (!opts.sbuCode) {
            $('#selected_sbu_code').val("");
            $('#selected_sbu_name span').text("");
        }
        //拠点
        $('#btn_master_maintenance_location').button({ disabled: !opts.mfgLocation });
        if (!opts.mfgLocation) {
            $('#selected_location_code').val("");
            $('#selected_location_name span').text("");
        }
        //B.Unit
        $('#btn_master_maintenance_bunit').button({ disabled: !opts.divSub });
        if (!opts.divSub) {
            $('#selected_bunit_code').val("");
            $('#selected_bunit_name span').text("");
        }
        //得意先グループ
        $('#btn_master_maintenance_customer_group').button({ disabled: !opts.custGroupCode });
        if (!opts.custGroupCodes) {
            // 得意先グループ
            $('#selected_customer_group_code').val("");
            $('#selected_customer_group_name span').text("");
        }
        //回答部門
        $('#btn_master_maintenance_answer_department').button({ disabled: !opts.responseDeptCode });
        if (!opts.responseDeptCode) {
            // 回答部門
            $('#selected_answer_department_code').val("");
            $('#selected_answer_department_name span').text("");
        }
    }

    /*
	 * jQuery-Ui 定義、スタイル設定
	 */
    // 期ドロップダウン 初期化
    $('#select_term option').remove();
    for (let i = 0, len = termList.length; i < len; i++) {
        $('#select_term').append(
				$('<option>').val(termList[i]).text(termList[i]));
    }
    // 期の最大値(現在の期)で初期化
    $('#select_term')[0].selectedIndex = 0;
    $('#select_term').selectmenu({
        width: '8em',
        disabled: true
    });
    //ボタン状態初期化
    setMstOption($('[name=select_master]:checked').val());
    // B.Unit
    let dialog_master_maintenance_bunit = new MasterSelectDialog(dialogEnum.BUnit, null, function (obj) {
	    $('#selected_bunit_code').val(obj.code);
	    $('#selected_bunit_name span.lang_jp').text(obj.displayValue.jp);
	    $('#selected_bunit_name span.lang_en').text(obj.displayValue.en);
	    $('#selected_bunit_name span.lang_cn').text(obj.displayValue.cn);
	});
    // B.Unitボタン
    $("#btn_master_maintenance_bunit").on('click', function () {
        let termId = getInputValue($('#select_term'));
        dialog_master_maintenance_bunit.SetOptArg(termId);
        dialog_master_maintenance_bunit.DialogOpen();
    });

    // TODO: MasterSelectDialogではなくSbuSelectDialogにする
    // SBU
    let dialog_master_maintenance_sbu = new MasterSelectDialog(dialogEnum.SBU, null, function (obj) {
	    $('#selected_sbu_code').val(obj.code);
	    $('#selected_sbu_name span.lang_jp').text(obj.displayValue.jp);
	    $('#selected_sbu_name span.lang_en').text(obj.displayValue.en);
	    $('#selected_sbu_name span.lang_cn').text(obj.displayValue.cn);
	});
    // SBUボタン
    $("#btn_master_maintenance_sbu").on('click', function () {
        let termId = getInputValue($('#select_term'));
        dialog_master_maintenance_sbu.SetOptArg(termId);
        dialog_master_maintenance_sbu.DialogOpen();
    });

    //// 拠点(苦情受付画面)
    //let dialog_master_maintenance_location = new MasterSelectDialog(5, null,
	//		function (obj) {
	//		    $('#selected_location_code').val(obj.code);
	//		    $('#selected_location_name span.lang_jp').text(obj.value.jp);
	//		    $('#selected_location_name span.lang_en').text(obj.value.en);
	//		    $('#selected_location_name span.lang_cn').text(obj.value.cn);
	//		});

    // 拠点（拠点資材画面）
    let dialog_master_maintenance_mfglocation = new MasterSelectDialog(dialogEnum.MFGLOCATION, null, function (obj) {
	    $('#selected_location_code').val(obj.code);
	    $('#selected_location_name span.lang_jp').text(obj.displayValue.jp);
	    $('#selected_location_name span.lang_en').text(obj.displayValue.en);
	    $('#selected_location_name span.lang_cn').text(obj.displayValue.cn);
	});
    // 拠点ボタン
    $("#btn_master_maintenance_location").on('click', function () {
        dialog_master_maintenance_mfglocation.DialogOpen();
        //if (masterType_num != 13) {
        //    dialog_master_maintenance_location.DialogOpen();
        //} else {
        //    dialog_master_maintenance_mfglocation.DialogOpen();
        //}
    });

    // 得意先グループ
    let dialog_master_maintenance_customer_group = new MasterSelectDialog(dialogEnum.CUST_GROUP, null, function (obj) {
	    $('#selected_customer_group_code').val(obj.code);
	    $('#selected_customer_group_name span.lang_jp').text(obj.displayValue.jp);
	    $('#selected_customer_group_name span.lang_en').text(obj.displayValue.en);
	    $('#selected_customer_group_name span.lang_cn').text(obj.displayValue.cn);
	});
    // 得意先グループボタン
    $("#btn_master_maintenance_customer_group").on('click', function () {
        dialog_master_maintenance_customer_group.DialogOpen();
    });

    // 回答部門
    let dialog_master_maintenance_answer_department = new MasterSelectDialog(dialogEnum.ANSWER_DEPARTMENT, null, function (obj) {
	    $('#selected_answer_department_code').val(obj.code);
	    $('#selected_answer_department_name span.lang_jp').text(obj.displayValue.jp);
	    $('#selected_answer_department_name span.lang_en').text(obj.displayValue.en);
	    $('#selected_answer_department_name span.lang_cn').text(obj.displayValue.cn);
	});
    // 回答部門ボタン
    $("#btn_master_maintenance_answer_department").on('click', null, function () {
	    let termId = getInputValue($('#select_term'));
	    dialog_master_maintenance_answer_department.SetOptArg(termId);
	    dialog_master_maintenance_answer_department.DialogOpen();
	});

    // 条件のクリアボタン クリックイベント
    $("#btn_clear_conditions").on('click', function () {
        // 期セレクトボックス
        $('#select_term')[0].selectedIndex = 0;
        $('#select_term').selectmenu('refresh');
        // B.Unit
        $('#selected_bunit_code').val("");
        $('#selected_bunit_name span').text("");
        // SBU
        $('#selected_sbu_code').val("");
        $('#selected_sbu_name span').text("");
        // 拠点
        $('#selected_location_code').val("");
        $('#selected_location_name span').text("");
        // 得意先グループ
        $('#selected_customer_group_code').val("");
        $('#selected_customer_group_name span').text("");
        // 回答部門
        $('#selected_answer_department_code').val("");
        $('#selected_answer_department_name span').text("");
    });

    // 一括出力ボタン クリックイベント 値を取得する
    $('#btn_master_maintenance_batch_export').on('click', function () {

	    // TODO: 処理中レイヤーの表示/表示を適切に実行する
	    // common.js showProcessingLayer(), hideProcessingLayer()
	    // ラジオボタンの値を取得する
	    let masterId = $('[name=select_master]:checked').val();
	    let params = getMstInfo(masterId);
	    // B.Unit
	    let selected_bunit = $('#selected_bunit_code').val();
	    // SBU
	    let selected_sbu = $('#selected_sbu_code').val();
	    // 期
	    let selected_termId = getInputValue($('#select_term'));
	    // 拠点
	    let selected_location = $('#selected_location_code').val();
	    // 得意先グループ
	    let customerGroup = $('#selected_customer_group_code').val();
	    // 回答部門;
	    let responseDept = $('#selected_answer_department_code').val();

	    // リクエストに選択値を詰める
	    let formData = new FormData();
	    formData.append('TYPE', masterId);
	    // B.Unit
	    if (params.divSub) {
	        // B.Unit
	        formData.append('DIVSUB', selected_bunit);
	    }
	    // SBU
	    if (params.sbuCode) {
	        formData.append('SBU', selected_sbu);
	    }
	    // 期
	    if (params.term) {
	        formData.append('TERM', selected_termId);
	    }
	    // 拠点
	    if (params.mfgLocation) {
	        formData.append('LOCATION', selected_location);
	    }
	    // 得意先グループ
	    if (params.custGroupCode) {
	        formData.append('CUSTOMER_GROUP', customerGroup);
	    }
	    if (params.responseDeptCode) {
	        // 回答部門
	        formData.append('RESPONSE_DEPT', responseDept);
	    }

	    // ダイアログ接続パス
	    let POST_URL = CONTEXT_PATH + '/action/mstFileDownload/';
        //csvファイル名取得
	    let csvFileName = mstList.getById(masterId).fileName;

	    $.ajax({
	        url: POST_URL,
	        type: "POST",
	        contentType: false,
	        processData: false,
	        cache: false,
	        data: formData,
	        success: function (response) {
	        	let bom = new Uint8Array([0xEF, 0xBB, 0xBF]);
	            let blobObject = new Blob([bom,response], { "type": "text/csv" });
	            if ('msSaveBlob' in window.navigator) {
	                window.navigator.msSaveOrOpenBlob(blobObject, csvFileName); // 名前
	            } else {
	                //IE以外
	                let alink = $('<a style="display:none" id="tmp_download_link"/>').appendTo('body');
	                let blobUrl = window.URL.createObjectURL(blobObject);
	                alink.attr('href', blobUrl);
	                alink.attr('download', csvFileName);
	                alink[0].click();
                    $(alink).remove();

	            }
	        }
	    });
	    return false;
	});

    // 一括取込ボタン クリックイベント
    $("#btn_master_maintenance_batch_import").on('click', function (e) {
        // hiddenの参照ボタンをクリックイベントを発動させる
        $("#hidden_master_maintenance_file_upload").click();
    });

    // ファイル選択ダイアログ選択後イベント
    $("#hidden_master_maintenance_file_upload").on('change', function () {

        // TODO: 処理中レイヤーの表示/表示を適切に実行する
        // common.js showProcessingLayer(), hideProcessingLayer()

        // 選択されたファイルを取得する
        let files = $(this).get(0).files;
        if (files) {
            // アップロード処理を行うメソッド
            handleFileUpload(files, function () {
                //アップロード処理完了
                $("#hidden_master_maintenance_file_upload").val("");
            });
        }
    });

    var masterType_num = 5;
    // マスタ選択ラジオボタンli クリックイベント
    $('input[type=radio][name=select_master]').on('click', function () {
        console.log(this);
        $('.select_master_box ul li').removeClass('selected');
        $(this).parent("li").addClass('selected');
        //$(this).prop('checked', true);

        // ラジオボタンの値を取得
        let mstId = $(this).val();
        //マスタのIDによって画面項目の活性状態を制御する
        setMstOption(mstId);
    });

    /* 言語変更イベントの登録 TODO: 不要 */
    $('input[name="lang_button"]:radio').on('change', function () {
        langChangeDefectivePartsListPage();
        // WindoiwResize
        // resizeMainContainer();
    });

    // #Container のリサイズ処理
    resizeMainContainer();

    // #Containerのリサイズ処理を登録
    $(window).on('resize', function () {
        resizeMainContainer();
    });

    // Loading解除
    toggleLoading(false);

});
