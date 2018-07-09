/// <reference path="../pulugins/jquery-1.12.4.js" />
/// <reference path="../pulugins/jquery-ui.js" />
/// <reference path="../pulugins/jquery.twbsPagination.min.js" />
/// <reference path="common.js" />

"use strict";
(function(){
/** 状態 */
const CUST_STATUS={
    MAKE:"1000",					// 作成中
    QA_ACCEPT_WAIT:"1010",			// 管理担当受付待ち
    ANSWER_ACCEPT_WAIT:"1020",		// 回答受付待ち
    ANSWER_REPORT_WAIT:"1030",		// 回答報告待ち
    ACCEPT_WAIT:"1040",				// 営業提出日未入力
    ASSOCIATE_CLOSE_WAIT:"1050",		// 連携元クローズ待ち
    ASSOCIATE_WAIT:"1060",			// 連携待ち
    CLOSE:"1990"						// クローズ
}
/** 修理内容 */
const REPAIRES = {
	LAMBDA_VAL1_01 : '10',	// 修理
	LAMBDA_VAL1_02 : '20',	// クレーム(解析と修理)
	LAMBDA_VAL1_03 : '30',	// オーバーホール
	LAMBDA_VAL1_04 : '40',	// データ採取
	LAMBDA_VAL1_05 : '50',	// 倉戻し
	LAMBDA_VAL1_06 : '60',	// 改造
	LAMBDA_VAL1_07 : '70',	// 回収
	LAMBDA_VAL1_08 : '80',	// クレーム(解析のみ)
}

/** 責任区分 */
const RESPONSIBILITY ={
	LAMBDA_VAL7_01 : '01',	// 部品不良
	LAMBDA_VAL7_02 : '02',	// 取扱不良
	LAMBDA_VAL7_03 : '03',	// 製造不良
	LAMBDA_VAL7_04 : '04',	// 設計不良
	LAMBDA_VAL7_05 : '05',	// 運送不良
	LAMBDA_VAL7_06 : '06',	// その他
	LAMBDA_VAL7_07 : '07',	// 再現せず
	LAMBDA_VAL7_08 : '08',	// 寿命
}
/** 現象 */
const PHENOMENON={
	LAMBDA_VAL9_01 : '01',	// オープン故障
	LAMBDA_VAL9_02 : '02',	// 半導通故障
	LAMBDA_VAL9_03 : '03',	// ショート故障
	LAMBDA_VAL9_04 : '04',	// 特性不良
	LAMBDA_VAL9_05 : '05',	// 高温にて動作不良
	LAMBDA_VAL9_06 : '06',	// 低温にて動作不良
	LAMBDA_VAL9_07 : '07',	// 寸法不良
	LAMBDA_VAL9_08 : '08',	// 容量減少
	LAMBDA_VAL9_09 : '09',	// 発煙、発火、異臭
	LAMBDA_VAL9_10 : '10',	// 接触不良
	LAMBDA_VAL9_11 : '11',	// 外観不良
	LAMBDA_VAL9_12 : '12',	// 液漏れ
	LAMBDA_VAL9_13 : '13',	// RoHS不適合
	LAMBDA_VAL9_14 : '99',	// その他
}
/** 欠点度 */
const DEFECTIVE_CLASS = {
	CLITICAL : '1' ,	// 致命欠点
	SERIOUS  : '2' ,	// 重欠点
	SLIGHT   : '3' ,	// 軽欠点
	FLAWLESS : '4' ,	// 欠点なし
}

/**発生場所*/
const OCCURRENCE_LOCATION={
	MARKET : '1',		//市場
	SHIP : '2',         //出荷
	PROGRESS : '3',     //工程
	RECEP : '4',        //受入
	RELIABILITY : '5',  //信頼性
	AUTHORIZATION : '6',//認定
	ZERO_KM : '8',      //0 - km 不良
	OTHER : '7',        //その他
}

/** データフォーマット関数集 */
const formatters = {
  getStatus: function (data) {
    switch (String(data)) {
      case CUST_STATUS.MAKE:
        return "▯▯▯▯▯▯";
      case CUST_STATUS.QA_ACCEPT_WAIT:
        return "▮▯▯▯▯▯";
      case CUST_STATUS.ANSWER_ACCEPT_WAIT:
        return "▮▮▯▯▯▯";
      case CUST_STATUS.ANSWER_REPORT_WAIT:
        return "▮▮▮▯▯▯";
      case CUST_STATUS.ACCEPT_WAIT:
        return "▮▮▮▮▯▯";
      case CUST_STATUS.ASSOCIATE_CLOSE_WAIT:
        return "▮▮▮▮▮▯";
      case CUST_STATUS.ASSOCIATE_WAIT:
        return "▮▮▮▮▮▯";
      case CUST_STATUS.CLOSE:
        return "▮▮▮▮▮▮";
      default:
        return "▯▯▯▯▯▯";
    }
  },
  dateFormat: function (data) {
    if (!data) {
      return '';
    }
    if (typeof data === 'string') {
      // 文字列の場合、Dateに変換
      data = new Date(data);
    }
    return $.datepicker.formatDate('yy/mm/dd', data);
  },
  /** 改行処理（必要があるか?） */
  replaceCrLf: function (data) {
    if (!data || typeof data!=='string') {
      return data;
    }
    return data.replace(/\r?\n/g," ");
  },
  /** 欠点度名称取得 */
  getDefectiveClass:function(data){
	let itemId='';
	switch (String(data)) {
		case DEFECTIVE_CLASS.CLITICAL:
			itemId = 'COMMON_VALUE-0301';
			break;
		case DEFECTIVE_CLASS.SERIOUS:
			itemId = 'COMMON_VALUE-0302';
			break;
		case DEFECTIVE_CLASS.SLIGHT:
			itemId = 'COMMON_VALUE-0303';
			break;
		case DEFECTIVE_CLASS.FLAWLESS:
			itemId = 'COMMON_VALUE-0304';
			break;
		default:
			return data;
	}
	let name={
		jp:getItemDef(itemId,'jp'),
		en:getItemDef(itemId,'en'),
		cn:getItemDef(itemId,'cn'),
	};
    return formatters.getDisplayName(name);
  },
  /** 修理内容名称取得 */
  getRepairName: function (data) {
	  let itemId='';
		switch (String(data)) {
			case REPAIRES.LAMBDA_VAL1_01:
				itemId = 'COMMON_VALUE-L08-01';
				break;
			case REPAIRES.LAMBDA_VAL1_02:
				itemId = 'COMMON_VALUE-L08-02';
				break;
			case REPAIRES.LAMBDA_VAL1_03:
				itemId = 'COMMON_VALUE-L08-03';
				break;
			case REPAIRES.LAMBDA_VAL1_04:
				itemId = 'COMMON_VALUE-L08-04';
				break;
			case REPAIRES.LAMBDA_VAL1_05:
				itemId = 'COMMON_VALUE-L08-05';
				break;
			case REPAIRES.LAMBDA_VAL1_06:
				itemId = 'COMMON_VALUE-L08-06';
				break;
			case REPAIRES.LAMBDA_VAL1_07:
				itemId = 'COMMON_VALUE-L08-07';
				break;
			case REPAIRES.LAMBDA_VAL1_08:
				itemId = 'COMMON_VALUE-L08-08';
				break;
			default:
				return data;
		}
		let name={
			jp:getItemDef(itemId,'jp'),
			en:getItemDef(itemId,'en'),
			cn:getItemDef(itemId,'cn'),
		};
	    return formatters.getDisplayName(name);
  },
  /** 責任区分名称取得 */
  getResponsibilityName: function (data) {
	let itemId='';
	switch (String(data)) {
		case RESPONSIBILITY.LAMBDA_VAL7_01:
			itemId = 'COMMON_VALUE-L14-01';
			break;
		case RESPONSIBILITY.LAMBDA_VAL7_02:
			itemId = 'COMMON_VALUE-L14-02';
			break;
		case RESPONSIBILITY.LAMBDA_VAL7_03:
			itemId = 'COMMON_VALUE-L14-03';
			break;
		case RESPONSIBILITY.LAMBDA_VAL7_04:
			itemId = 'COMMON_VALUE-L14-04';
			break;
		case RESPONSIBILITY.LAMBDA_VAL7_05:
			itemId = 'COMMON_VALUE-L14-05';
			break;
		case RESPONSIBILITY.LAMBDA_VAL7_06:
			itemId = 'COMMON_VALUE-L14-06';
			break;
		case RESPONSIBILITY.LAMBDA_VAL7_07:
			itemId = 'COMMON_VALUE-L14-07';
			break;
		case RESPONSIBILITY.LAMBDA_VAL7_08:
			itemId = 'COMMON_VALUE-L14-08';
			break;
		default:
			return data;
	}
	let name={
			jp:getItemDef(itemId,'jp'),
			en:getItemDef(itemId,'en'),
			cn:getItemDef(itemId,'cn'),
		};
	return formatters.getDisplayName(name);
  },
  /** 発生場所名称取得 */
  getOccurrenceLocationName: function (data) {
	let itemId='';
	switch( String(data)) {
		case OCCURRENCE_LOCATION.MARKET:
			itemId = 'COMMON_VALUE-0001';
			break;
		case OCCURRENCE_LOCATION.SHIP:
			itemId = 'COMMON_VALUE-0002';
			break;
		case OCCURRENCE_LOCATION.PROGRESS:
			itemId = 'COMMON_VALUE-0003';
			break;
		case OCCURRENCE_LOCATION.RECEP:
			itemId = 'COMMON_VALUE-0004';
			break;
		case OCCURRENCE_LOCATION.RELIABILITY:
			itemId = 'COMMON_VALUE-0005';
			break;
		case OCCURRENCE_LOCATION.AUTHORIZATION:
			itemId = 'COMMON_VALUE-0006';
			break;
		case OCCURRENCE_LOCATION.ZERO_KM:
			itemId = 'COMMON_VALUE-0007';
			break;
		case OCCURRENCE_LOCATION.OTHER:
			itemId = 'COMMON_VALUE-0008';
			break;
		default:
			return data;
	}
	let name={
			jp:getItemDef(itemId,'jp'),
			en:getItemDef(itemId,'en'),
			cn:getItemDef(itemId,'cn'),
		};
	return formatters.getDisplayName(name);
  },
  /** 現象名称取得 */
  getPhenomenonName: function (data) {
	  let itemId='';
      switch (String(data)) {
		case PHENOMENON.LAMBDA_VAL9_01:
			itemId = 'COMMON_VALUE-L16-01';
			break;
		case PHENOMENON.LAMBDA_VAL9_02:
			itemId = 'COMMON_VALUE-L16-02';
			break;
		case PHENOMENON.LAMBDA_VAL9_03:
			itemId = 'COMMON_VALUE-L16-03';
			break;
		case PHENOMENON.LAMBDA_VAL9_04:
			itemId = 'COMMON_VALUE-L16-04';
			break;
		case PHENOMENON.LAMBDA_VAL9_05:
			itemId = 'COMMON_VALUE-L16-05';
			break;
		case PHENOMENON.LAMBDA_VAL9_06:
			itemId = 'COMMON_VALUE-L16-06';
			break;
		case PHENOMENON.LAMBDA_VAL9_07:
			itemId = 'COMMON_VALUE-L16-07';
			break;
		case PHENOMENON.LAMBDA_VAL9_08:
			itemId = 'COMMON_VALUE-L16-08';
			break;
		case PHENOMENON.LAMBDA_VAL9_09:
			itemId = 'COMMON_VALUE-L16-09';
			break;
		case PHENOMENON.LAMBDA_VAL9_10:
			itemId = 'COMMON_VALUE-L16-10';
			break;
		case PHENOMENON.LAMBDA_VAL9_11:
			itemId = 'COMMON_VALUE-L16-11';
			break;
		case PHENOMENON.LAMBDA_VAL9_12:
			itemId = 'COMMON_VALUE-L16-12';
			break;
		case PHENOMENON.LAMBDA_VAL9_13:
			itemId = 'COMMON_VALUE-L16-13';
			break;
		case PHENOMENON.LAMBDA_VAL9_14:
			itemId = 'COMMON_VALUE-L16-14';
			break;
		default:
			return data;
    }
    let name={
		jp:getItemDef(itemId,'jp'),
		en:getItemDef(itemId,'en'),
		cn:getItemDef(itemId,'cn'),
	};
	return formatters.getDisplayName(name);
  },
  getRemarks: function (data) {
    return data;
  },
  /** マルチ言語の表示名変換 */
  getDisplayName: function (data) {
    function addHidden(lang) {
      let currLang = getLanguageType();
      if (lang === currLang) {
        return '';
      } else {
        return ' hidden';
      }
    }
    let html = '';
    let jp = '';
    let en = '';
    let cn = '';
    if (Array && Array.isArray(data)) {
      let jpNames = data.map(function (item) {
        return item.jp || '';
      });
      let enNames = data.map(function (item) {
        return item.en || item.jp || '';
      });
      let cnNames = data.map(function (item) {
        return item.cn || item.en ||item.jp ||'';
      });
      jp = jpNames.join(",");
      en = enNames.join(",");
      cn = cnNames.join(",");
    }else if(data) {
      jp = data.jp || '';
      en = data.en ||data.jp|| '';
      cn = data.cn ||data.en||data.jp|| '';
    }
    html = '<span class="lang_jp' + addHidden('jp') + '" >' + jp + '</span>'
    html = html + '<span class="lang_en' + addHidden('en') + '" >' + en + '</span>'
    html = html + '<span class="lang_cn' + addHidden('cn') + '" >' + cn + '</span>'
    return html;
  }
}

/**
 * ItemIdから表示テキストを取得
 *
 * @param {String}
 *            itemId 項目ID
 * @param {String}
 *            lang 言語ID
 * @return {String} 現在の言語のテキスト
 */
const getItemDef = function (itemId, lang) {
  if (!lang) {
    lang = getLanguageType();
  }
  return itemDefList[lang][itemId];
}
// メッセージを取得する
const getMessage = function (messageId, lang) {
  if (!lang) {
    lang = getLanguageType();
  }
  return APP_MASSAGES[lang][messageId];
}

const allColumns = {
  // 進捗
  "col01": { head: "CUST-08", fld: "status", format: formatters.getStatus, fix: true },
  // 水平展開
  "col02": { head: "CUST-635", fld: "deployment", fix: true },
  // 苦情No.
  "col03": { head: "CUST-09", fld: "no", fix: true },
  // 苦情発行日
  "col04": { head: "CUST-10", fld: "issuedDate", format: formatters.dateFormat },
  // 販売拠点コード
  "col05": { head: "CUST-11", fld: "salesSiteCode" },
  // 販売拠点名
  "col06": { head: "CUST-12", fld: "salesLocName", format: formatters.getDisplayName },
  // 得意先略称
  "col07": { head: "CUST-13", fld: "ovsCustName", format: formatters.getDisplayName },
  // 得意先グループ名
  "col08": { head: "CUST-14", fld: "custGroupName", format: formatters.getDisplayName },
  // OSコード
  "col09": { head: "CUST-15", fld: "osCode" },
  // OS担当者名
  "col10": { head: "CUST-16", fld: "salesUserName", format: formatters.getDisplayName },
  // 営業所
  "col11": { head: "CUST-17", fld: "salesOfficeName" , format: formatters.getDisplayName},
  // 営業所コード
  "col12": { head: "CUST-18", fld: "salesOfficeCode" },
  // 得意先P#
  "col13": { head: "CUST-19", fld: "custPartNo" },
  // TDK品名
  "col14": { head: "CUST-20", fld: "itemName" },
  // 品名コード
  "col15": { head: "CUST-21", fld: "itemCode" },
  // 機種コード
  "col16": { head: "CUST-22", fld: "itemGroup" },
  // B.Grpコード
  "col17": { head: "CUST-23", fld: "divHq" },
  // B.Unitコード
  "col18": { head: "CUST-24", fld: "divSub" },
  // CBU名
  "col19": { head: "CUST-25", fld: "cbuName", format: formatters.getDisplayName },
  // SBU名
  "col20": { head: "CUST-26", fld: "sbuName", format: formatters.getDisplayName },
  // 分野統括部
  "col21": { head: "CUST-27", fld: "marketingGroupName", format: formatters.getDisplayName },
  // MMT
  "col22": { head: "CUST-28", fld: "marketingFieldName", format: formatters.getDisplayName },
  // SETグループ
  "col23": { head: "CUST-29", fld: "setClassName", format: formatters.getDisplayName },
  // SET名称
  "col24": { head: "CUST-30", fld: "setName", format: formatters.getDisplayName },
  // 得意先製品区分
  "col25": { head: "CUST-31", fld: "customerCatDisp" },
  // 営業受付日
  "col26": { head: "CUST-32", fld: "saleReceiveDate", format: formatters.dateFormat },
  // 得意先又は市場での苦情発生日
  "col27": { head: "CUST-33", fld: "occurrenceDate", format: formatters.dateFormat },
  // 発生場所
  "col28": { head: "CUST-34", fld: "occurrenceLocation",format:formatters.getOccurrenceLocationName },
  // 発生数
  "col29": { head: "CUST-35", fld: "customerIssueFormOccurrenceQty" },
  // 苦情分類（1）
  "col30": { head: "CUST-36", fld: "complaintCat1Name", format: formatters.getDisplayName },
  // 苦情分類（2）
  "col31": { head: "CUST-37", fld: "complaintCat2Name", format: formatters.getDisplayName },
  // 苦情詳細
  "col32": { head: "CUST-38", fld: "complaintDetail", format: formatters.replaceCrLf },
  // 営業判定重要コード
  "col33": { head: "CUST-39", fld: "salesRankCode" },
  // 得意先管理番号
  "col34": { head: "CUST-40", fld: "customerReferenceNo" },
  // 回答書
  "col35": { head: "CUST-41", fld: "reportRequestDisp" },
  // 回答書得意先希望日
  "col36": { head: "CUST-42", fld: "customerRequestDate", format: formatters.dateFormat },
  // 回答書営業希望日
  "col37": { head: "CUST-43", fld: "salesRequestDate", format: formatters.dateFormat },
  // 解析サンプルの有無
  "col38": { head: "CUST-44", fld: "sampleExistenceDisp" },
  // サンプル送付数量
  "col39": { head: "CUST-45", fld: "sampleQty" },
  // サンプル送付日
  "col40": { head: "CUST-46", fld: "sampleShippedDate", format: formatters.dateFormat },
  // サンプル送付手段
  "col41": { head: "CUST-47", fld: "sampleShippedViaDisp" },
  // QA受付担当者
  "col42": { head: "CUST-48", fld: "qaUserName", format: formatters.getDisplayName },
  // QA受付日
  "col43": { head: "CUST-49", fld: "qaAcceptDate", format: formatters.dateFormat },
  // サンプル到着日
  "col44": { head: "CUST-50", fld: "sampleArrivalDate", format: formatters.dateFormat },
  // 受付部門管理No.
  "col45": { head: "CUST-51", fld: "ownRefNo" },
  // 製造拠点
  "col46": { head: "CUST-52", fld: "productionName", format: formatters.getDisplayName },
  // 苦情回答部門
  "col47": { head: "CUST-53", fld: "responseDeptName", format: formatters.getDisplayName },
  // 苦情回答部門担当者
  "col48": { head: "CUST-54", fld: "responseUserName", format: formatters.getDisplayName },
  // 得意先要求事項（1）予定日
  "col49": { head: "CUST-56", fld: "requirement1Schedule", format: formatters.dateFormat },
  // 得意先要求事項（2）予定日
  "col50": { head: "CUST-57", fld: "requirement2Schedule", format: formatters.dateFormat },
  // 回答部門受付日
  "col51": { head: "CUST-58", fld: "responseAcceptDate", format: formatters.dateFormat },
  // 一次回答書承認日
  "col52": { head: "CUST-59-0", fld: "firstReportApprovalDate", format: formatters.dateFormat },
  // 最終回答書承認日
  "col53": { head: "CUST-59", fld: "finalReportApprovalDate", format: formatters.dateFormat },
  // 得意先要求事項（1）実施日
  "col54": { head: "CUST-60", fld: "requirement1Implemented", format: formatters.dateFormat },
  // 得意先要求事項（2）実施日
  "col55": { head: "CUST-61", fld: "requirement2Implemented", format: formatters.dateFormat },
  // 欠点度
  "col56": { head: "CUST-62", fld: "defectiveClass", format: formatters.getDefectiveClass },
  // 製造判定重要度コード
  "col57": { head: "CUST-63", fld: "productionRankCode" },
  // 不具合部位
  "col58": { head: "CUST-64", fld: "defectivePortion" },
  // 不具合分類（1）
  "col59": { head: "CUST-65", fld: "defectiveCat1Name", format: formatters.getDisplayName },
  // 不具合分類（2）
  "col60": { head: "CUST-66", fld: "defectiveCat2Name" , format: formatters.getDisplayName},
  // 不具合の発生数
  "col61": { head: "CUST-67", fld: "customerReportOccurrenceQty" },
  // 回答報告製造元
  "col62": { head: "CUST-68", fld: "reportProductionName", format: formatters.getDisplayName },
  // 発生工程
  "col63": { head: "CUST-69", fld: "generationProcessName", format: formatters.getDisplayName },
  // 発生原因（大分類）
  "col64": { head: "CUST-70", fld: "causeCat1Name", format: formatters.getDisplayName },
  // 発生原因（中分類）
  "col65": { head: "CUST-71", fld: "causeCat2Name", format: formatters.getDisplayName },
  // 変化点の有無
  "col66": { head: "CUST-72", fld: "changePointName", format: formatters.getDisplayName },
  // 一次回答書営業提出日
  "col67": { head: "CUST-73", fld: "firstSalesSubmissionDate", format: formatters.dateFormat },
  // 一次回答書得意先承認日
  "col68": { head: "CUST-74", fld: "firstCustSubmissionDate", format: formatters.dateFormat },
  // 最終回答書営業提出日
  "col69": { head: "CUST-75", fld: "finalSalesSubmissionDate", format: formatters.dateFormat },
  // 最終回答書得意先承認日
  "col70": { head: "CUST-76", fld: "finalCustSubmissionDate", format: formatters.dateFormat },
  // 発生元苦情No.
  "col71": { head: "CUST-L02-014", fld: "baseCompNo" },
  // エンドユーザー
  "col72": { head: "CUST-L02-036", fld: "endUser" },
  // 製造ロットNo
  "col73": { head: "CUST-322", fld: "productionLotNo" },
  // 修理内容
  "col74": { head: "CUST-L02-016", fld: "repair", format: formatters.getRepairName },
  // 責任区分
  "col75": { head: "CUST-L03-003", fld: "responsibility", format: formatters.getResponsibilityName },
  // 原因1
  "col76": { head: "CUST-L03-005", fld: "cause1Name", format: formatters.getDisplayName },
  // 原因2
  "col77": { head: "CUST-L03-007", fld: "cause2Name", format: formatters.getDisplayName },
  // 番地
  "col78": { head: "CUST-L03-009", fld: "address" },
  // Item名称
  "col79": { head: "CUST-L03-028", fld: "reportItemName", format: formatters.getDisplayName },
  // 現象
  "col80": { head: "CUST-L03-013", fld: "phenomenon", format: formatters.getPhenomenonName },
  // 備考
  "col81": { head: "CUST-L03-022", fld: "remarks", format: formatters.getRemarks },
  // 部品Lot No.
  "col82": { head: "'CUST-L03-015", fld: "itemLot" },
}

/** データバント用Util（必要の場合、COMMONに移動する） */
const bindUtil = function createBindUtil() {
  /**
	 * 入力項目の種別を取得する
	 *
	 * @param elem{selector}:対象項目のSelector
	 */
  function inputType(elem) {
    if ($(elem).is('input[type="hidden"]')) {
      return "hidden";
    }
    if ($(elem).is('input[type="text"].datepicker')) {
      return "datepicker";
    }
    if ($(elem).is('input[type="text"]')) {
      return "textbox";
    }
    if ($(elem).is('input[type="checkbox"]')) {
      return "checkbox";
    }
    if ($(elem).is('input[type="radio"]')) {
      return "radio";
    }
    if ($(elem).is('select')) {
      return "select";
    }
    if ($(elem).is('textarea')) {
      return "textarea";
    }
    if ($(elem).is('input')) {
      return $(elem).attr("type");
    }
    return $(elem).prop("tagName").toLowerCase();
  }
  /**
	 * 項目に値を設定する
	 *
	 * @param elem
	 *            {JQueryObject} 項目
	 * @param value
	 *            {Object} 値
	 */
  function setValue(elem, value) {
    let tmpval;
    switch (bindUtil.inputType(elem)) {
      case "hidden":
      case "textbox":
      case "textarea":
      case "select":
        $(elem).val(value);
        break;
      case "checkbox":
        tmpval = $(elem).val();
        if (value === null || value === undefined) {
          // 設定なしの場合
          $(elem).prop("checked", false).change();
        }
        else if (Array.isArray(value)) {
          // チェックリスト時、Value値にバンド
          if (value.indexOf(tmpval) >= 0) {
            $(elem).prop("checked", true).change();
          } else {
            $(elem).prop("checked", false).change();
          }
        }
        else if (typeof value === "boolean") {
          // 値はbool時、Checked値にバンド
          $(elem).prop("checked", value);
        }
        break;
      case "datepicker":
        if (value) {
          $(elem).datepicker('setDate', new Date(value));
        } else {
          $(elem).val("");
        }
        break;
      case "span":
      case "label":
        $(elem).text(value);
      default:
        break;
    }
  }
  /**
	 * 項目から入力値を取得する
	 *
	 * @param elem
	 */
  function getValue(elem) {
    let format;
    let tempVal;
    let chklst;
    if ($(elem).length === 0) {
      return null;
    }
    switch (bindUtil.inputType(elem)) {
      case "hidden": case "textbox": case "textarea":
        // can get by $(elem).val
        return $(elem).val();
      case "select":
        return $(elem).val();
      case "checkbox":
        // get array form checkbox or checkbox group
        chklst = $(elem).filter(":checked");
        tempVal = chklst.map(function () {
          return $(this).val();
        }).toArray();
        return tempVal;
      case "radio":
        chklst = $(elem).filter(":checked");
        if (chklst.length === 0) {
          return -1;
        }
        return chklst.val();
      case "datepicker":
        // get date from datepicker
        tempVal = $(elem).datepicker('getDate');
        return tempVal;
      default:
        break;
    }
  }
  // 外部公開モジュール追加
  let exportModules = {
    inputType: inputType,
    setValue: setValue,
    getValue: getValue
  };
  return exportModules;
}();

/**
 * 検索条件管理するモジュール
 */
const detailCondtions = function conditions() {
  /** データを検索項目にバンド（非公開） */
  function bindToField(bindInfo, elem, value) {
    switch (bindInfo.type) {
      case "STRING":
      case "DATE":
      case "CHECKLIST":
        bindUtil.setValue(elem, value);
        break;
      default:
        $(elem).data("raw", value);
        break;
    }
  }
  /** データを検索条件画面にバンドする */
  function bindTo() {
    $(".search_detail_container [data-field]").each(
        function fieldBind() {
          let bindInfo = $(this).data();
          if (currentCondition[bindInfo.field]) {
            bindToField(bindInfo, this, currentCondition[bindInfo.field]);
          } else {
            bindToField(bindInfo, this, null);
          }
        }
    );
  }
  /** 検索条件画面からデータをバンドする */
  function bindFrom() {
    let fields = [];
    let value = null;

    currentCondition = {};
    // get all fields
    $(".search_detail_container [data-field]").each(
       function getfield() {
         let field = $(this).data('field');
         if (fields.indexOf(field) === -1) {
           fields.push(field);
         }
       });

    for (let i = 0; i < fields.length; i++) {
      let elems = $('[data-field="' + fields[i] + '"]');
      let bindInfo = $(elems).data();
      switch (bindInfo.type) {
        case "STRING":
        case "DATE":
        case "CHECKLIST":
          value = bindUtil.getValue(elems);
          if (value) {
            currentCondition[bindInfo.field] = value;
          }
          break;
        default:
          value = $(elems).data("raw");
          if (value) {
            currentCondition[bindInfo.field] = value;
          }
          break;
      }
    }
    return currentCondition;
  }

  function getCondition() {
    return currentCondition;
  }

  function setCondtion(condition, id, name) {
    currentCondition = condition;
    conditionId = $.isNumeric(id) ? Number(id) : 0;
    conditionName = name;
  }

  /** 現在の検索条件設定 */
  let conditionId = 0;
  /** 現在の検索条件名 */
  let conditionName = '';
  /** 現在の検索条件オブジェクト */
  let currentCondition = {};

  /** 検索結果 */
  let result = {}

  let exportModules = {
    getCondition: getCondition,
    setCondtion: setCondtion,
    bindFrom: bindFrom,
    bindTo: bindTo,

    getId: function () { return conditionId; },
    getName: function () { return conditionName; },
  };

  return exportModules;
}();

/** 表示列 */
let displayColumns = [];
/** 検索結果 */
let searchResult = {
  totalPage:0,
  startPage: 0,
  resultCount: 0,
  result:{}
};

// 列設定
if (displayColumns.length === 0) {
  for (let col in allColumns) {
    if (allColumns[col].fix) {
      displayColumns.push(col);
    }
  }
}

/**
 * JQuery UI component extend
 */
$.fn.extend({
  /**
	 * グリッドビューを生成する this {tbody} グリッドビューのコンテンツ
	 *
	 * @param {JsonArray}
	 *            data
	 * @param {json}
	 *            columns [
	 *            	{ fld: 'dataField', class: 'className', style:{width:20%}
	 *            	  format: callback
	 *            	}, ...
	 *            ]
	 * @param {json}
	 *            options { altRow:true|false
	 *            rowTemp: '<tr class="cssname" id="row-{rowid}">',
	 *            colTemp: '<td class="col-{colid}-{rowid}">{fieldName}</td>',
	 *            }
	 */
  gridview:function(data, columns, options) {

    /** テンプレートのバンド値を変換する */
    function replaceBind(bindData, temp, rowid, colid, fld , foramtValue) {
      let regex = /\{([^\}]+)\}/g;
      return temp.replace(regex, function (group, match) {
        // 行番号の場合{rowid}
        if (match && match.toLowerCase() === 'rowid') {
          // null||undefinedの場合空値で戻す
          return rowid == null ? '' : rowid;
        }
        // 列のField名の場合{colid}
        if (match && match.toLowerCase() === 'colid') {
          // null||undefinedの場合空値で戻す
          return colid == null ? '' : colid;
        }
        // 列のバンド値の場合{fld}
        if (match && fld && match.toLowerCase() === 'fld') {
          // null||undefinedの場合空値で戻す
          return (foramtValue) ? foramtValue : '';
        }
        // dataのFieldの場合{fieldName}
        return (bindData && bindData[match]) ? bindData[match] : '';
      });
    }
    // default setting
    let defaultOpt = {
      altRow: true,
      rowTemp: '<tr>',
      colTemp: '<td>{fld}</td>'
    };
    options = options || defaultOpt;
    let html = '';
    let container = $(this);
    container.html('');
    // bind begin
    if (!data || !Array.isArray(data)) {
      return;
    }
    for (let rowid in data) {
      html = replaceBind(data[rowid], options.rowTemp, rowid);
      let addCss = (rowid % 2) === 0 ? 'even' : 'odd';
      let row = $(html).addClass(addCss);
      if (columns && Array.isArray(columns)) {
        for (let colid in columns) {
          let column = columns[colid];
          if (column.fld === undefined) {
            continue;
          }
          let value = data[rowid][column.fld];
          if (column.format && typeof column.format === 'function') {
            value = column.format.call(column, value);
          }
          html = replaceBind(data[rowid], options.colTemp, rowid, colid, column.fld, value);
          let col = $(html);
          if (column.class) {
            col.addClass(column.class);
          }
          if (column.style) {
            col.css(column.style);
          }
          row.append(col);
        }
        container.append(row);
      }
    }
    return this;
  },

});

/* アクション処理関数モジュール */
const actions = function ajaxActions() {
  /**
	 * ACTION_TYPE.SEARCH：条件検索
	 *
	 * @param {Object}
	 *            condition :検索条件
	 * @param {Number}
	 *            pageNo:ページ番号
	 * @param {Function}
	 *            callback
	 */
  function search(condition, pageNo,callback) {
    // ダイアログ接続パス
    let POST_URL = CONTEXT_PATH + '/action/custSearch/';
    // 表示件数
    let limit = bindUtil.getValue($("#select_display_result"));
    // ページ番号
    if (!pageNo) {
      pageNo = 1;
    }
    // リクエストパラメータを設定
    let args = {
      action: ACTION_TYPE.SEARCH,
      params: {
        condition: JSON.stringify(condition),
        pageNo: pageNo,
        limit: limit
      }
    };
    let reqArg = { 'reqArg': JSON.stringify(args) };
    $.ajax({
      type: 'POST',
      url: POST_URL,
      cache: false,
      dataType: 'json',
      data: reqArg,
      success: function (response) {
        if(callback){
          callback(response);
        }
      }
    });
  }
  /**
	 * ACTION_TYPE.SAVE_CONDITION：検索保存
	 *
	 * @param {Number}
	 *            saveMode:保存モード（0:新規,1:上書）
	 * @param {String}
	 *            saveName:検索条件名(上書モード無視する)
	 * @param {Number}
	 *            id:条件ID（新規モード無視する）
	 * @param {Object}
	 *            condition :検索条件
	 * @param {Function}
	 *            callback :callback関数
	 */
  function saveCondition(saveMode, saveName, id, condition, callback) {
    // ダイアログ接続パス
    let POST_URL = CONTEXT_PATH + '/action/custSearch/';
    // リクエストパラメータを設定
    let args = {
      action: ACTION_TYPE.SAVE_CONDITION,
      params: {
        condition: JSON.stringify(condition),
        saveMode: saveMode,
        saveId: id,
        saveName: saveName
      }
    };
    let reqArg = { 'reqArg': JSON.stringify(args) };
    $.ajax({
      type: 'POST',
      url: POST_URL,
      cache: false,
      dataType: 'json',
      data: reqArg,
      success: function (response) {
        if (callback) {
          callback(response);
        }
      }
    });
  }
  /**
	 * 検索条件一覧を取得する
	 *
	 * @param {Function}
	 *            callback
	 */
  function getConditionList(callback) {
    // ダイアログ接続パス
    let POST_URL = CONTEXT_PATH + '/action/custSearch/';
    // リクエストパラメータを設定
    let args = {
      action: ACTION_TYPE.GET_CONDITION_LIST,
      params: {}
    };
    let reqArg = { 'reqArg': JSON.stringify(args) };
    $.ajax({
      type: 'POST',
      url: POST_URL,
      cache: false,
      dataType: 'json',
      data: reqArg,
      success: function (condition) {
        if (callback) {
          callback(condition);
        }
      }
    });
  }
  /**
	 * 検索条件を削除する
	 *
	 * @param {int}
	 *            id
	 * @param {Function}
	 *            callback
	 */
  function deleteCondition(id, callback) {
    // ダイアログ接続パス
    let POST_URL = CONTEXT_PATH + '/action/custSearch/';
    // リクエストパラメータを設定
    let args = {
      action: ACTION_TYPE.DELET_CONDITION,
      params: { id: id }
    };
    let reqArg = { 'reqArg': JSON.stringify(args) };
    $.ajax({
      type: 'POST',
      url: POST_URL,
      cache: false,
      dataType: 'json',
      data: reqArg,
      success: function (condition) {
        if (callback) {
          callback(condition);
        }
      }
    });
  }

  /**
	 * ACTION_TYPE.DELETE_CUST：選択データを削除する
	 *
	 * @param {String}
	 *            compNo:苦情番号
	 * @param {Function}
	 *            callback
	 */
  function deleteCust(compNo, callback) {
    // ダイアログ接続パス
    let POST_URL = CONTEXT_PATH + '/action/custSearch/';
    // リクエストパラメータを設定
    let args = {
      action: ACTION_TYPE.DELETE_CUST,
      params: {
        no: compNo
      }
    };
    let reqArg = { 'reqArg': JSON.stringify(args) };
    $.ajax({
      type: 'POST',
      url: POST_URL,
      cache: false,
      dataType: 'json',
      data: reqArg,
      success: function (response) {
        if (callback) {
          callback(response);
        }
      }
    });
  }

  /**
	 * 検索条件のソート順を更新する
	 *
	 * @param id
	 *            {int}
	 * @param {Function}
	 *            callback
	 */
  function sortCondition(ids, callback) {
    // ダイアログ接続パス
    let POST_URL = CONTEXT_PATH + '/action/custSearch/';
    // リクエストパラメータを設定
    let args = {
      action: ACTION_TYPE.SORT_CONDITION,
      params: { ids: JSON.stringify(ids) }
    };
    let reqArg = { 'reqArg': JSON.stringify(args) };
    $.ajax({
      type: 'POST',
      url: POST_URL,
      cache: false,
      dataType: 'json',
      data: reqArg,
      success: function (condition) {
        if (callback) {
          callback(condition);
        }
      }
    });
  }

  return {
    search: search,
    saveCondition: saveCondition,
    getConditionList: getConditionList,
    deleteCondition: deleteCondition,
    sortCondition: sortCondition,
    deleteCust: deleteCust
  }
}();

/**
 * 検索条件一覧初期化する
 *
 * @param {JsonArray}
 *            conditions
 * @param {Boolean}
 *            isFirst:初回ロードかどうか
 */
function initConditionList(conditions, isFirst) {
  $("#select_condition option").remove();
  // 空条件を追加
  $("<option></option>")
      .val(0)
      .appendTo("#select_condition")
      .data("raw", "{}");
  let index = 0;
  let selectedIndex = 0;
  if (conditions && Array.isArray(conditions)) {
    for (let idx in conditions) {
      index++;
      let condition = conditions[idx];
      $("<option></option>")
        .val(condition.id)
        .text(condition.conditionName)
        .appendTo("#select_condition")
        .data("raw", condition.conditions);
      if (condition.id == detailCondtions.getId()) {
        selectedIndex = index;
      }
    }
  }
  $("#select_condition").prop("selectedIndex", selectedIndex);
  $("#select_condition").selectmenu("refresh");
  // イベントバンドする
  if (isFirst) {
    $("#select_condition").selectmenu({
      select: function (event, ui) {
        let id = $(ui.item.element).val();
        let name = $(ui.item.element).text();
        let condition = JSON.parse($(ui.item.element).data("raw"));
        detailCondtions.setCondtion(condition, id, name);
        detailCondtions.bindTo();
      }
    });
  }

}
/**
 * 保存ダイアログ画面初期化
 *
 * @param {JsonArray}
 *            conditions:検索条件一覧
 * @param {Boolean}
 *            isFirst:初回ロードかどうか
 */
function initSaveConditionDialog(conditions, isFirst) {
  if (isFirst) {
    /* 保存方法ラジオボタン変更イベントの登録 */
    $('input[name="radio_search_condition_save"]:radio').on('change',
      function onSaveModeChange() {
        let saveMode = Number(bindUtil.getValue($("[name=radio_search_condition_save]")));
        if (saveMode === 0) {
          // 新規保存
          $('#input_new_search_condition_name').prop('disabled', false);
          $('#table_search_condition_save tbody tr.selected').removeClass('selected');
        } else {
          // 上書き保存
          $('#input_new_search_condition_name').prop('disabled', true);
        }
      });
  }

  /* 条件一覧ビュー初期化 */
  // 列設定
  let columns = [
    { fld: 'conditionName' }
  ];
  // テンプレート設定
  let opts = {
    altRow: true,
    rowTemp: '<tr>',
    colTemp: '<td data-id="{id}">{fld}</td>'
  };
  // データバンド
  $("#condition_name_list").gridview(conditions, columns, opts);
  // 行選択イベントバンドする
  $("#condition_name_list tr").click(
    function onConditionRowClick(ev) {
      let saveMode = Number(bindUtil.getValue("[name=radio_search_condition_save]"));
      // 新規モードの場合選択不可
      if (saveMode === 0) {
        return;
      }
      if ($(this).hasClass("selected")) {
        $(this).removeClass("selected");
      } else {
        $("#condition_name_list tr.selected").removeClass("selected");
        $(this).addClass("selected");
      }
    });
}
/**
 * 条件設定編集ダイアログの条件一覧
 *
 * @param {JsonArray}
 *            conditions
 * @param {Boolean}
 *            isFirst
 */
function initEditConditionDialog(conditions, isFirst) {
  // 列設定
  let columns = [
    { fld: 'conditionName' }
  ];
  // オプション設定
  let opts = {
    rowTemp: '<li class="ui-sortable-handle" data-id="{id}"></li>',
    colTemp: '<span >{fld}</span>'
  };
  $("#saved_search_condition_items").gridview(conditions, columns, opts);
  // 選択イベントバンドする
  $("#saved_search_condition_items li").click(function (ev) {
    if ($(this).hasClass("selected")) {
      $(this).removeClass("selected");
    } else {
      $("#saved_search_condition_items li.selected").removeClass("selected");
      $(this).addClass("selected");
    }
  });
}

/**
 * 検索条件一覧リストを初期化する
 */
function initConditions(conditions, isFirst) {
  // 検索条件一覧初期化する
  initConditionList(conditions, isFirst);
  // 保存ダイアログリスト更新
  initSaveConditionDialog(conditions, isFirst);
  // 条件設定編集ダイアログの条件一覧
  initEditConditionDialog(conditions, isFirst)
}

const pageDefaultOpts = {
  visiblePages: 5,
  prev: '<',
  next: '>',
  initiateStartPageClick: false,
  onPageClick: function (event, page) {
    if (page > 0) {
      showProcessingLayer();
      actions.search(detailCondtions.getCondition(), page,
        function onResponse(res) {
          // 明細データ表示
          searchResult = res;
          initResultBody();
          hideProcessingLayer();
          initResultCountNumber();
        });
    }
  }
}


/**
 * ページング初期化
 */
function initPaging(isFirst) {
  // ページ件数
  let totalPage = searchResult.totalPage;
  let startPage = searchResult.startPage;
  let pagingUnit = Number(bindUtil.getValue($("#select_display_result")));
  // ページングインスタンス取得
  let pagination = $('#search_result_pagination');
  if (!isFirst) {
    pagination.twbsPagination('destroy');
  }
  if (searchResult.resultCount === 0) {
    pagination.twbsPagination(pageDefaultOpts);
    pagination.twbsPagination('disable');
    $('#search_result_count').addClass('hidden');
    return;
  }
  // ページ初期化
  pagination.twbsPagination($.extend({}, pageDefaultOpts, {
    startPage: startPage,
    totalPages: totalPage
  }));
  initResultCountNumber();
}

/** データ件数表示更新 */
function initResultCountNumber() {
  let startPage = searchResult.startPage;
  let pagingUnit = Number(bindUtil.getValue($("#select_display_result")));
  let start = (startPage - 1) * pagingUnit + 1;
  let end = start + pagingUnit - 1;
  if (end > searchResult.resultCount) {
    end = searchResult.resultCount;
  }
  $('#search_result_count').removeClass('hidden');
  $('#result_display_start_count').text(start);
  $('#result_display_end_count').text(end);
  $('#result_all_count').text(searchResult.resultCount);
}

/**
 * 検索結果データを表示する
 */
function initResultBody() {
  let resData = searchResult.result;
  // オプション設定
  let opts = {
    altRow:true,
    rowTemp: '<tr data-compno="{no}">',
    colTemp: '<td class="searchResult-{colid}-sizer"><div class="ellipsis" style="width: inherit;">{fld}</div></td>'
  };

  // 列設定
  let columns = displayColumns.map(function (column) {
     return allColumns[column];
  });
  // データバンドする
  $("#table_search_result_body").gridview(resData, columns, opts);
  // テーブル操作イベント登録
  registTableEffect();
}
/***/
function initResultHeader() {
  // ソート条件の保持等が必要かも？
  $('#table_search_result').tablesorter("destroy");
  $('#table_search_result th').resizable("destroy");

  // ヘッダー列クリア
  $('#table_search_result thead tr th').each(function (index) {
    $(this).remove();
  });
  // データ列クリア
  $('#table_search_result tbody tr').each(function (index) {
    while ($(this).children('td').length > 0) {
      $(this).children('td:last').remove();
    }
  });

  let idInex = 0;
  // 固定列を追加
  // 列設定
  if (displayColumns.length === 0) {
    for (let col in allColumns) {
      if (allColumns[col].fix) {
        displayColumns.push(col);
      }
    }
  }
  // 変動列を追加
  for (let i = 0; i < displayColumns.length; i++) {
    let column = allColumns[displayColumns[i]];
    // ヘッダー追加
    let $appendTh = $('<th>').append(
   $('<div>').addClass('ellipsis').css('width', 'inherit')
     .append($('<span>').addClass('lang_jp hidden').text(getItemDef(column.head, "jp")))
     .append($('<span>').addClass('lang_en hidden').text(getItemDef(column.head, "en")))
     .append($('<span>').addClass('lang_cn hidden').text(getItemDef(column.head, "cn"))));
    $('table#table_search_result thead tr').append($appendTh);
  }

  // 現在表示中の言語のspanのみ表示
  $('table#table_search_result span.lang_' + getLanguageType()).removeClass('hidden');

  // テーブル操作イベント登録
  registTableEffect();
}

/**
 * テーブル操作イベントの登録
 */
function registTableEffect() {
  // Table 列リサイズ登録
  $('#table_search_result th').resizable({
    handles: 'e',
    transparent: false,
    minWidth: 15,
    resize: function (event, ui) {
      $('.searchResult-' + event.target.cellIndex + '-sizer').css('width', ui.size.width + 'px');
    }
  });

  // Table Sort 登録
  // Table SorterとTable 列リサイズを登録する場合、列リサイズを先に登録するほうが良い
  $('#table_search_result').tablesorter({
    widgets: ['zebra', 'columns']
  });

  // TODO: 即時関数で定義(デリゲートを指定すればできるはず)
  $('#table_search_result tbody tr').on('click', function () {
    let oldSelected = $('#table_search_result tbody tr.selected');
    oldSelected.removeClass('selected');
    if (!$(this).is(oldSelected)) {
      $(this).addClass('selected');
    }
  });

  $('#table_search_result tbody tr').on('dblclick', function () {
    let url = CONTEXT_PATH + '/action/customerMain/?' + GET_PARAMKEY_COMPNO + '=';
    url += $(this).data('compno');
    window.open(url, "_blank");
  });
}

$(function () {
  // #Container のリサイズ処理
  resizeMainContainer();

  // TODO: Dataload
  // 一覧表示データ、一覧表示項目取得 → テーブル作成処理記述など

  /*
	 * jQuery-Ui 定義、スタイル設定
	 */
  // accordion
  $(".search_detail_container").accordion({ heightStyle: "content" });

  /* jQuery-Ui Selectmenu */
  $('#select_condition').selectmenu({
    width: '13em'
  });
  $('#select_display_result').selectmenu({
    width: '6em'
  });


  // 検索条件一覧初期化する
  actions.getConditionList(function (conditions) {
    // 検索条件ダイアログ画面初期化
    initConditions(conditions, true);
  });

  /* jQuery-Ui Dialog */
  // 一覧表示項目設定ダイアログ
  $("#list_col_setting_dialog").dialog({
    autoOpen: false,
    width: 600,
    modal: true,
    resizable: false,
    title: getItemDef("CUST-04"),
    closeOnEscape: false,
    buttons: [{ // OKボタンの設定 start
      text: "OK",
      click: function () {
        saveDisplayItemSetting();
        initResultHeader();
        initResultBody();
        $(this).dialog("close");
      }
    }, // OKボタンの設定 end
{ // Cancelボタンの設定 start
  text: "Cancel",
  click: function () {
    $(this).dialog("close");
  }
}, // Cancelボタンの設定 end
    ]
  });

  // 検索条件設定ダイアログ
  $("#search_condition_setting_dialog").dialog({
    autoOpen: false,
    width: 450,
    modal: true,
    resizable: false,
    title: getItemDef("COMMON-08"),// 検索条件設定
    closeOnEscape: false,
    // Open Event
    open: function (ev, ui) {
      this.title = getItemDef("COMMON-08");
    },
    buttons: [
      {
        // 削除ボタン
        text: getItemDef("COMMON-10"),
        click: function onDeleteClick() {
          let selItem = $("#saved_search_condition_items li.selected");
          if (selItem.length === 0) {
            return;
          }
          let selectedId = $(selItem).data("id");
          // 削除処理開始
          showProcessingLayer();
          actions.deleteCondition(selectedId, function (conditions) {
            // 条件一覧を更新する
            initConditions(conditions, false);
            hideProcessingLayer();
          });
        }
      },
      { // OKボタンの設定 start
        text: "Save",
        click: function onSaveClick() {
          // 検索条件設定ソート順保存処理
          // 検索条件のID一覧を取得する
          let elems = $("#saved_search_condition_items li");
          let idList = [];
          elems.each(function () {
            let id = $(this).data("id");
            idList.push(id);
          });
          if (idList.length === 0) {
            return;
          }
          // ソート順更新処理
          showProcessingLayer();
          actions.sortCondition(idList, function (conditions) {
            initConditions(conditions, false);
            hideProcessingLayer();
          });
          $(this).dialog("close");
        }
      }, // OKボタンの設定 end
    { // Cancelボタンの設定 start
      text: "Cancel",
      click: function () {
        $(this).dialog("close");
      }
    }, // Cancelボタンの設定 end

    ]
  });

  // 検索条件設定ダイアログ 保存済み検索条件Table クリックイベント
  $('#saved_search_condition_items li').on('click', function () {
    let oldSelected = $('#saved_search_condition_items li.selected');
    if (!$(this).is(oldSelected)) {
      oldSelected.removeClass('selected');
      $(this).addClass('selected');
    }
  });

  // 検索条件の保存ダイアログ
  $('#search_condition_save_dialog').dialog(
  {
    title: getItemDef("COMMON-14"),
    autoOpen: false,
    width: 480,
    modal: true,
    resizable: false,
    minWidth: 480,
    minheight: 400,
    closeOnEscape: false,
    buttons: [
      // Saveボタン
      {
        text: "Save",
        click: function () {
          // 検索条件情報を取得する
          // 保存種別
          let saveMode = Number(bindUtil.getValue("[name=radio_search_condition_save]"));
          if (saveMode === -1) {
            return;
          }
          // 保存名
          let saveName = '';
          let saveId = 0;
          if (saveMode === 0) {
            // 新規保存
            saveName = bindUtil.getValue("#input_new_search_condition_name");
          } else {
            // 上書保存
            let selRow = $("#condition_name_list tr.selected");
            if (selRow.length === 0) {
              showErrorMessageDialog(getMessage('ERR_CONDITION_NOSELECT'));
              return;
            }
            saveId = selRow.children("td").data("id");
            saveName = selRow.children("td").text();
          }
          // 検索条件名入力チェック
          if (saveMode === 0 && !saveName) {
            // 検索条件名を入力してください
            showErrorMessageDialog(getMessage('ERR_CONDITION_NOINPU'));
            return;
          }
          // 重複入力名チェック
          if (saveMode === 0) {
            let hasSameName = false;
            $("#condition_name_list td").each(function () {
              if ($(this).text() === saveName) {
                hasSameName = true;
                // break
                return false;
              }
            });
            if (hasSameName) {
              showErrorMessageDialog(getMessage('ERR_CONDITION_SAMEINPUT'));
              return;
            }
          }
          // 条件入力をConditionにバンドする
          let condition = detailCondtions.bindFrom();
          // 保存処理
          showProcessingLayer();
          let dialog = this;
          actions.saveCondition(saveMode, saveName, saveId, condition,
            function callback(conditionList) {
              // 検索条件ドロップダウンを変更。新規の場合は選択肢追加
              initConditions(conditionList, false);
              // 保存中Gif解除
              hideProcessingLayer();
              $(dialog).dialog('close');
            });

        }
      },
      // キャンセルボタン
      {
        text: "Cancel",
        click: function () {
          $(this).dialog('close');
        }
      }]
  });

  // 検索条件詳細ダイアログ
  $('#search_detail_dialog').dialog({
    autoOpen: false,
    width: 600,
    height: 750,
    modal: false,
    resizable: true,
    minWidth: 600,
    minheight: 400,
    closeOnEscape: false,
    buttons: [
        {
          text: "Search",
          click: function () {
            // 検索処理
            let conditions = detailCondtions.bindFrom();
            showProcessingLayer();
            actions.search(conditions, 1, function (res) {
               searchResult = res;
               initPaging(false);
               initResultBody();
              hideProcessingLayer();
            });
          }
        },
        {
          text: "Save",
          click: function () {
            $('#search_condition_save_dialog').dialog('open');
            $('#radio_search_condition_save_new').prop('checked', true);
            $('#input_new_search_condition_name').val('');
          }
        },
        {
          text: 'Close',
          click: function () {
            $(this).dialog('close');
          }
        }
    ]
  });

  /* jQuery-Ui Button */
  // 検索条件ヘッダーエリア
  $("#button_edit_seach_condition").button('option', 'disabled', false); // 検索条件設定ボタン
  $("#button_edit_seach_condition").button().on('click', function () {
    // TODO: 検索条件設定ダイアログ初期化
    $('#saved_search_condition_items li.selected').removeClass('selected');
    $("#search_condition_setting_dialog").dialog('open');
    searchConditionSettingDialogItemsSetStyle();
  });
  $("#button_clear_seach_condition").button(); // 検索条件クリアボタン
  // $("#button_clear_seach_condition").button('option', 'disabled', true);
  // クリアボタン
  $("#button_clear_seach_condition").click(function () {
    // 現在の検索条件をクリアする
    let condiName = detailCondtions.getName();
    let condiId = detailCondtions.getId();
    detailCondtions.setCondtion({}, condiId, condiName);
    detailCondtions.bindTo();
  });
  // // 検索条件詳細ボタン
  $("#button_search_detail_opener").button().on('click', function () {
    $('#search_detail_dialog').dialog('open');
  });

  // 検索結果エリア
  $("#button_list_custom_opener").on('click', function () {
    // ダイアログタイトルを多言語対応
    let lang = getLanguageType();
    // 一覧項目設定
    let titleStr = getItemDef("COMMON-23", lang);
    // ダイアログの表示項目リストを設定
    itemsSetListItem();
    $('#list_col_setting_dialog').dialog('option', 'title', titleStr);
    // ダイアログ表示
    $('#list_col_setting_dialog').dialog('open');
  });
  $("#button_copy").button('option', 'disabled', true);
  // $("#button_download").button();
  // $("#button_download_txt").button();
  // $("#button_status_example").button();
  // $("#button_report").button();
  // $("#button_url").button();

  // 検索条件詳細Dialig内ボタン
  // $("#button_select_sales").button(); // 営業部門条件選択ボタン
  // $("#button_select_client").button(); // 得意先選択ボタン
  // $("#button_select_product").button(); // 製品選択ボタン
  // $("#button_select_product2").button(); // 製品選択ボタン


  // 検索ボタン
  $("#button_search").button(); // 検索ボタン
  $("#button_search").click(function () {
    showProcessingLayer();
    actions.search(detailCondtions.getCondition(), 1,
      function onResponse(res) {
        // 明細データ表示
        searchResult = res;
        initPaging(false);
        initResultBody();
        hideProcessingLayer();
      });
  });

  // 削除ボタン
  $("#button_delete").button();
  $("#button_delete").click(function () {
    let compNo=$("#table_search_result_body tr").data("compno");
    showProcessingLayer();
    actions.deleteCust(compNo, function (res) {
      // 削除成功
      actions.search(detailCondtions.getCondition(), 1,
          function onResponse(res) {
            // 明細データ表示
            searchResult = res;
            initPaging(false);
            initResultBody();
            hideProcessingLayer();
          });
    });
  });

  // 一覧項目設定Dialog内ボタン
  $("#item_add_all").on('click', function () {
    let allItem = $('#non_display_items li');
    if (allItem.length > 0) {
      $('#non_display_items li.selected').removeClass('selected');
      allItem.appendTo('#display_items');
      // 項目リストのスタイル適応
      itemsSetStyle();
    }
  });
  $("#item_add").on('click', function () {
    let selectedItem = $('#non_display_items li.selected');
    if (selectedItem.length > 0) {
      $(selectedItem).removeClass('selected');
      selectedItem.appendTo('#display_items');
      // 項目リストのスタイル適応
      itemsSetStyle();
    }
  });
  $("#item_del").on('click', function () {
    let selectedItem = $('#display_items li.selected');
    if (selectedItem.length > 0) {
      $(selectedItem).removeClass('selected');
      $('#non_display_items').append($(selectedItem));
      // 項目リストのスタイル適応
      itemsSetStyle();
    }
  });
  $("#item_del_all").on('click', function () {
    let allItem = $('#display_items li');
    if (allItem.length > 0) {
      $('#display_items li.selected').removeClass('selected');
      $('#non_display_items').append($(allItem));
      // 項目リストのスタイル適応
      itemsSetStyle();
    }
  });


  // /* jQuery-Ui Checkboxradio */

  /* jQuery-Ui Sortable */
  // 検索条件設定ダイアログのドラッグ移動登録
  $('#saved_search_condition_items').sortable({
    start: function (event, ui) {
      $('#saved_search_condition_items li.selected').removeClass('selected');
    },
    stop: function (event, ui) {
      searchConditionSettingDialogItemsSetStyle()
    }
  }).disableSelection();

  // 表示項目設定ダイアログ 列項目のドラッグ移動登録
  $('#non_display_items, #display_items').sortable({
    connectWith: '.connectedSortable',
    start: function (event, ui) {
      $('#non_display_items li.selected').removeClass('selected');
      $('#display_items li.selected').removeClass('selected');
    },
    stop: function (event, ui) {
      itemsSetStyle()
    }
  }).disableSelection();

  // 検索結果tableのソート、リサイズを登録
  registTableEffect();

  // ダイアログの表示項目リスト/非表示項目リストを設定
  itemsSetListItem();

  // ページング初期化
  initPaging(true);
  // 検索結果初期化
  initResultHeader();
  initResultBody();

  // 言語ボタン
  $('input[name="lang_button"]:radio').on('change', function () {
    langChangeCustSearchPage();
    // WindoiwResize
    resizeMainContainer();
  });

  /* 検索条件詳細ダイアログの言語設定 */
  setSearchDetailDialogLangage(getLanguageType());

  // #Containerのリサイズ処理を登録
  $(window).on('resize', function () {
    resizeMainContainer();
  });

  // Loading解除
  toggleLoading(false);
});

/**
 * #main の高さをWindowサイズに合わせて変更します。
 */
function resizeMainContainer() {
  let bodyHeight = parseFloat($(window).height());
  console.log('windowHeight: ' + bodyHeight);
  let bodyMarginTop = parseFloat($('body').css('margin-top'));
  // body height をヘッダー部分を除いた高さに設定
  $('body').css('height', bodyHeight - bodyMarginTop + 'px');

  // メインコンテナ部分の高さを設定
  bodyHeight = parseFloat($('body').height());
  let containerOffsetHeight = parseFloat($('#containerInner').css('margin-top')) + parseFloat($('#containerInner').css('margin-bottom'));
  containerOffsetHeight += parseFloat($('#containerInner').css('padding-top')) + parseFloat($('#containerInner').css('padding-bottom'));
  let containerHeight = bodyHeight - containerOffsetHeight;
  $('#container').css('height', containerHeight + 'px');
  $('#containerInner').css('height', (containerHeight) + 'px');
}

/**
 * 顧客苦情検索ページ独自の言語設定変更イベントメソッド
 */
function langChangeCustSearchPage() {
  /* 検索条件詳細ダイアログの言語変更 */
  setSearchDetailDialogLangage(getLanguageType());
}

/**
 * 検索条件詳細ダイアログの言語を設定します
 */
function setSearchDetailDialogLangage(lang) {
  let titleStr;
  let searchStr;
  let saveStr;
  let closeStr;
  switch (lang) {
    case 'jp':
      titleStr = '検索条件詳細';
      searchStr = '検索'
      saveStr = '保存';
      closeStr = '閉じる';
      break;
    case 'en':
      titleStr = 'Search Condition';
      searchStr = 'Search'
      saveStr = 'Save';
      closeStr = 'Close';
      break;
    case 'cn':
      titleStr = '(中)検索条件詳細';
      searchStr = '(中)検索'
      saveStr = '(中)保存';
      closeStr = '(中)閉じる';
      break;
    default:
      titleStr = 'Search Condition';
      saveStr = 'Save';
      closeStr = 'Close';
  }
  $('#search_detail_dialog').dialog('option', 'title', titleStr);
  let optButtons = $('#search_detail_dialog').dialog('option', 'buttons');
  optButtons[0].text = searchStr;
  optButtons[1].text = saveStr;
  optButtons[2].text = closeStr;
  $('#search_detail_dialog').dialog('option', 'buttons', optButtons);
}

/**
 * TODO: ファンクション名変更 ダイアログ 非表示項目リスト/表示項目リストのスタイルを設定します。
 */
function itemsSetStyle() {
  // 非表示項目リストのスタイル設定
  $('.connectedSortable li').removeClass('odd');
  $('.connectedSortable li').removeClass('even');
  $('#non_display_items li:even').addClass('odd');
  $('#non_display_items li:odd').addClass('even');
  $('#display_items li:even').addClass('odd');
  $('#display_items li:odd').addClass('even');
};

/**
 * ダイアログ 検索条件設定リストのスタイルを設定します。
 */
function searchConditionSettingDialogItemsSetStyle() {
  // 保存済み検索条件リストのスタイル設定
  $('#saved_search_condition_items li').removeClass('odd');
  $('#saved_search_condition_items li').removeClass('even');
  $('#saved_search_condition_items li:even').addClass('odd');
  $('#saved_search_condition_items li:odd').addClass('even');
};

/**
 * ダイアログ 非表示項目リスト/表示項目リストの値を設定します。
 */
function itemsSetListItem() {
  let lang = getLanguageType();
  $('#non_display_items li').remove();
  $('#display_items li').remove();
  // nodisplay items
  for (let col in allColumns) {
    if (displayColumns.indexOf(col) === -1) {
      $('<li>').prop('id', col).text(getItemDef(allColumns[col].head, lang))
               .appendTo('#non_display_items');
    }
  }
  // displayitems
  for (let i = 0; i < displayColumns.length; i++) {
    let col = displayColumns[i];
    let column = allColumns[col];
    if (!column.fix) {
      $('<li>').prop('id', col).text(getItemDef(column.head, lang))
              .appendTo('#display_items');
    }
  }

  // 項目リストのスタイル適応
  itemsSetStyle();

  // 項目リストクリックイベントの登録
  $('#non_display_items li,#display_items li').on('click', function () {
    let oldSelected = $('#non_display_items li.selected,#display_items li.selected');
    oldSelected.removeClass('selected');
    if (!$(this).is(oldSelected)) {
      $(this).addClass('selected');
    }
  });
};

/**
 * ダイアログ 非表示項目リスト/表示項目リストの値を保存します。
 */
function saveDisplayItemSetting() {
  let saveColumns = [];
  // 固定項目追加
  for (let col in allColumns) {
    if (allColumns[col].fix) {
    	saveColumns.push(col);
    }
  }
  // 表示項目リストの保存
  $('#display_items li').each(function (index) {
    let id = $(this).prop('id');
    saveColumns.push(id);
  });
  displayColumns=saveColumns;
}

/**
 * テーブル表示項目変更
 */
function editedTableCol() {
  // ソート条件の保持等が必要かも？
  $('#table_search_result').tablesorter("destroy");
  $('#table_search_result th').resizable("destroy");

  // ヘッダー列クリア
  $('#table_search_result thead tr th').each(function (index) {
    $(this).remove();
  });
  // データ列クリア
  $('#table_search_result tbody tr').each(function (index) {
    while ($(this).children('td').length > 0) {
      $(this).children('td:last').remove();
    }
  });

  let idInex = 0;
  // 固定列を追加
  // 変動列を追加
  for (let i = 0; i < displayColumns.length; i++) {
    let column = allColumns[displayColumns[i]];
    // ヘッダー追加
    let $appendTh = $('<th>').append(
   $('<div>').addClass('ellipsis').css('width', 'inherit')
     .append($('<span>').addClass('lang_jp hidden').text(getItemDef(column.head, "jp")))
     .append($('<span>').addClass('lang_en hidden').text(getItemDef(column.head, "en")))
     .append($('<span>').addClass('lang_cn hidden').text(getItemDef(column.head, "cn"))));
    $('table#table_search_result thead tr').append($appendTh);

    // 値表示
    $('table#table_search_result tbody tr').each(
    function (row) {
      let $appendTd = $('<td>').addClass('searchResult-' + idInex + '-sizer')
      .append($('<div>').addClass('ellipsis').css('width', 'inherit').text(displayColumns[i] + '-' + column.fld + '-' + row));	// TODO:
																																// 表示が
																																// 3言語あるものはspan3つをappend
      $(this).append($appendTd);
    });
  }

  // 現在表示中の言語のspanのみ表示
  $('table#table_search_result span.lang_' + getLanguageType()).removeClass('hidden');

  // テーブル操作イベント登録
  registTableEffect();
}

})();