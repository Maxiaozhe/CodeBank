using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Resources
{
    public enum FieldNames:int
    {
        /// <summary>
        /// 一般
        /// </summary>
        CommonCategory,
        /// <summary>
        /// 検証
        /// </summary>
        ValidationCaterory,
        /// <summary>
        /// 制御
        /// </summary>
        OtherCategory,
        /// <summary>
        /// 変換元情報
        /// </summary>
        ReferCategory,
        /// <summary>
        /// 名前
        /// </summary>
        Name,
        /// <summary>
        /// タイトル
        /// </summary>
        Title,
        /// <summary>
        /// 説明
        /// </summary>
        Description,
        /// <summary>
        /// デフォルト値
        /// </summary>
        DefaultValue,
        /// <summary>
        /// デフォルト値(数式)
        /// </summary>
        DefaultValueFormula,
        /// <summary>
        /// 入力の確認式
        /// </summary>
        InputValidationFormula,
        /// <summary>
        /// 変換元種別
        /// </summary>
        SourceType,
        /// <summary>
        /// 変換先種別
        /// </summary>
        TargetType,
        /// <summary>
        /// 非表示
        /// </summary>
        Hidden,
        /// <summary>
        /// 必須
        /// </summary>
        Required,
        /// <summary>
        /// 読み取り専用
        /// </summary>
        ReadOnlyField,
        /// <summary>
        /// 計算列
        /// </summary>
        Computed,
        /// <summary>
        /// 変換対象
        /// </summary>
        IsConvert,
        /// <summary>
        /// 最小値
        /// </summary>
        MinimumValue,
        /// <summary>
        /// 最大値
        /// </summary>
        MaximumValue,
        /// <summary>
        /// パーセンテージ
        /// </summary>
        Percentage,
        /// <summary>
        /// 数点以下桁数
        /// </summary>
        Decimals,
        /// <summary>
        /// 通貨の表示形式
        /// </summary>
        CurrencyLocaleId,
        /// <summary>
        /// 最大文字数
        /// </summary>
        MaxLength,
        /// <summary>
        /// 編集対象の行数
        /// </summary>
        NumberOfLines,
        /// <summary>
        /// リッチテキスト
        /// </summary>
        RichText,
        /// <summary>
        /// 日付と時刻の形式
        /// </summary>
        DisplayFormat,
        /// <summary>
        /// UIの種別
        /// </summary>
        keywordUIType,
        /// <summary>
        /// 選択肢
        /// </summary>
        Choices,
        /// <summary>
        /// 選択肢追加を許可
        /// </summary>
        FillInChoice,
        /// <summary>
        /// 選択肢の種別
        /// </summary>
        EditFormat,
        /// <summary>
        /// 複数選択できる
        /// </summary>
        AllowMultipleValues,
        /// <summary>
        /// 選択種別
        /// </summary>
        SelectionMode,
        /// <summary>
        /// 数式
        /// </summary>
        ValidationFormula,
        /// <summary>
        /// データ検証に使用する式を指定してください。検証に合格するには、式の評価が TRUE になる必要があります。
        /// 例: 列の名前が "Company Name" の場合、有効な式は [Company Name]="My Company" となります。 
        /// </summary>
        ValidationFormulaDesc,
        /// <summary>
        /// メッセージ
        /// </summary>
        ValidationMessage,
        /// <summary>
        /// この列の値を有効と判断するために必要な条件の説明を入力してください。
        /// </summary>
        ValidationMessageDesc,
        
    }
}


            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
