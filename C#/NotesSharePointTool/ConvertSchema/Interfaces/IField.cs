using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Design;
using RS=RJ.Tools.NotesTransfer.Engines.Resources;
using System.ComponentModel;
namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    public interface IField : IFieldRef
    {
        #region Common
        /// <summary>
        /// 説明
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// 既定値
        /// </summary>
        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.DefaultValue)]
        string DefaultValue { get; set; }
        /// <summary>
        /// 既定値の計算式
        /// </summary>
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.DefaultValueFormula)]
        string DefaultValueFormula
        {
            get;
        }
        /// <summary>
        /// 検証数式
        /// </summary>
        string ValidationFormula
        {
            get;
            set;
        }
        /// <summary>
        /// 検証メッセージ
        /// </summary>
        string ValidationMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 入力確認式
        /// </summary>
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.InputValidationFormula)]
        string InputValidationFormula
        {
            get;
        }

        /// <summary>
        /// Notesフィールド種別
        /// </summary>
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.SourceType)]
        NotesFieldType SourceType { get; }
 
        /// <summary>
        /// 表示フォームに表示するか
        /// </summary>
         [Browsable(false)]
        bool ShowInDisplayForm { get; set; }
        /// <summary>
        /// 編集フォームに表示するか
        /// </summary>
         [Browsable(false)]
        bool ShowInEditForm { get; set; }
        /// <summary>
        /// 新規フォームに表示するか
        /// </summary>
         [Browsable(false)]
        bool ShowInNewForm { get; set; }
        /// <summary>
        /// 非表示するかどうか
        /// </summary>
        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.Hidden)]
        bool Hidden { get; set; }
        /// <summary>
        /// 必須かどうか
        /// </summary>
        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.Required)]
        bool Required { get; set; }
        /// <summary>
        /// 読み取り専用
        /// </summary>
        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.ReadOnlyField)]
        bool ReadOnlyField { get; set; }
        /// <summary>
        /// 計算列かどうか
        /// </summary>
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.Computed)]
        bool Computed { get;}
        #endregion
        
        #region Text
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.MaxLength)]
        int MaxLength { get; set; }
        #endregion        
        
        #region Number
        /// <summary>
        /// 最大値
        /// </summary>
         [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.MaximumValue)]
        double? MaximumValue { get; set; }
        /// <summary>
        /// 最小値
        /// </summary>
         [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.MinimumValue)]
        double? MinimumValue { get; set; }
        /// <summary>
        /// パーセンテージ
        /// </summary>
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.Percentage)]
        bool Percentage { get; set; }
        /// <summary>
        /// 小数点以下桁数
        /// </summary>
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.Decimals)]
        int Decimals { get; set; }
        #endregion
        
        #region DateTime
        /// <summary>
        /// 日付と時刻の形式
        /// </summary>
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.DisplayFormat)]
        DateTimeFormatType DisplayFormat { get; set; }
        #endregion

        #region Currency
         [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.CurrencyLocaleId)]
        int CurrencyLocaleId { get; set; }
        #endregion

        #region Choice
        /// <summary>
        /// 選択肢の表示形式
        /// </summary>
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.EditFormat)]
        ChoiceUIType EditFormat { get; set; }
        /// <summary>
        /// 選択肢
        /// </summary>
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.Choices)]
        string[] Choices { get; set; }
        /// <summary>
        /// 選択肢を追加できるようにする
        /// </summary>
         [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.FillInChoice)]
        bool FillInChoice { get; set; }
        /// <summary>
        /// キーワードのUI種別
        /// </summary>
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.keywordUIType)]
        KeywordUIType keywordUIType { get; }
        #endregion

        #region MultiLineText
        /// <summary>
        /// 編集対象の行数
        /// </summary>
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.NumberOfLines)]
        int NumberOfLines { get; set; }
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.RichText)]
        bool RichText { get; set; }
        #endregion

        #region User
        /// <summary>
        /// 表示するかどうか
        /// </summary>
        [Browsable(false)]
        bool AllowDisplay { get; set; }
        /// <summary>
        /// 複数選択を許可
        /// </summary>
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.AllowMultipleValues)]
        bool AllowMultipleValues { get; set; }

        /// <summary>
        /// 選択モード
        /// </summary>
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.SelectionMode)]
        UserSelectionMode SelectionMode { get; set; }

        #endregion

        IViewColumn ToViewColumn();
        
    }
}
