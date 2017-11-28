using RJ.Tools.NotesTransfer.Engines.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    /// <summary>
    /// ノーツフィールド種別
    /// </summary>
    [Editor(typeof(EnumUIEditor), typeof(UITypeEditor)), TypeConverter(typeof(EnumNameConverter))]
    public enum NotesFieldType
    {
        ///// <summary>
        ///// 不明
        ///// </summary>
        [EnumName("不明", NotesFieldType.Unknow)]
        Unknow,
        ///// <summary>
        ///// テキスト　text
        ///// </summary>
        [EnumName("テキスト", NotesFieldType.Text)]
        Text,
        ///// <summary>
        ///// 数値　number
        ///// </summary>
        [EnumName("数値", NotesFieldType.Number)]
        Number,
        /// <summary>
        /// 日付
        /// </summary>
        [EnumName("日付", NotesFieldType.Datetime)]
        Datetime,
        /// <summary>
        /// リッチテキスト
        /// </summary>
        [EnumName("リッチテキスト", NotesFieldType.Richtext)]
        Richtext,
        /// <summary>
        /// 選択
        /// </summary>
        [EnumName("キーワード", NotesFieldType.KeyWord)]
        KeyWord,
        /// <summary>
        /// 名前
        /// </summary>
        [EnumName("ユーザー名", NotesFieldType.Names)]
        Names,
        /// <summary>
        /// 作成者
        /// </summary>
        [EnumName("作成者", NotesFieldType.Authors)]
        Authors,
        /// <summary>
        /// 読者
        /// </summary>
        [EnumName("読者", NotesFieldType.Readers)]
        Readers,
        /// <summary>
        /// パスワード
        /// </summary>
        [EnumName("パスワード", NotesFieldType.Password)]
        Password,
        /// <summary>
        /// 式
        /// </summary>
        [EnumName("式", NotesFieldType.Formula)]
        Formula,
        /// <summary>
        /// タイムゾーン
        /// </summary>
        [EnumName("タイムゾーン", NotesFieldType.Timezone)]
        Timezone,
        /// <summary>
        /// リッチテキストライト
        /// </summary>
        [EnumName("リッチテキストライト", NotesFieldType.Richtextlite)]
        Richtextlite,
        /// <summary>
        /// 色
        /// </summary>
        [EnumName("色", NotesFieldType.Richtextlite)]
        Color
    }

    /// <summary>
    /// KeyWordタイプのUI種別
    /// </summary>
    [Editor(typeof(EnumUIEditor), typeof(UITypeEditor)), TypeConverter(typeof(EnumNameConverter))]
    public enum KeywordUIType
    {
        /// <summary>
        /// ダイアログリスト
        /// </summary>
        [EnumName("ダイアログリスト", KeywordUIType.dialoglist)]
        dialoglist,
        /// <summary>
        /// チェックボックスリスト
        /// </summary>
        [EnumName("チェックボックスリスト", KeywordUIType.checkbox)]
        checkbox,
        /// <summary>
        /// ラジオボタン
        /// </summary>
        [EnumName("ラジオボタン", KeywordUIType.radiobutton)]
        radiobutton,
        /// <summary>
        /// コンボボックス
        /// </summary>
        [EnumName("コンボボックス", KeywordUIType.radiobutton)]
        combobox,
        /// <summary>
        /// リストボックス
        /// </summary>
        [EnumName("リストボックス", KeywordUIType.listbox)]
        listbox,
    }

    [Editor(typeof(EnumUIEditor), typeof(UITypeEditor)), TypeConverter(typeof(EnumNameConverter))]
    public enum DateTimeFormatType
    {
        /// <summary>
        /// 日付のみ
        /// </summary>
        [EnumName("日付のみ", DateTimeFormatType.DateOnly)]
        DateOnly,
        /// <summary>
        /// 日付と時刻
        /// </summary>
        [EnumName("日付と時刻", DateTimeFormatType.DateTime)]
        DateTime
    }

    [Editor(typeof(EnumUIEditor), typeof(UITypeEditor)), TypeConverter(typeof(EnumNameConverter))]
    public enum ChoiceUIType
    {
        /// <summary>
        /// ドロップダウン メニュー
        /// </summary>
        [EnumName("ドロップダウン メニュー", ChoiceUIType.Dropdown)]
        Dropdown,
        /// <summary>
        /// ラジオ ボタン
        /// </summary>
        [EnumName("ラジオボタン", ChoiceUIType.RadioButtons)]
        RadioButtons,
        /// <summary>
        /// チェックボックス（複数選択）
        /// </summary>
        [EnumName("チェックボックス（複数選択）", ChoiceUIType.CheckBox)]
        CheckBox
    }

    /// <summary>
    /// ユーザー選択モード
    /// </summary>
    [Editor(typeof(EnumUIEditor), typeof(UITypeEditor)), TypeConverter(typeof(EnumNameConverter))]
    public enum UserSelectionMode
    {
        /// <summary>
        /// ユーザーのみ 
        /// </summary>
        [EnumName("ユーザーのみ", UserSelectionMode.PeopleOnly)]
        PeopleOnly,
        /// <summary>
        /// ユーザーとグループ
        /// </summary>
        [EnumName("ユーザーとグループ", UserSelectionMode.PeopleAndGroups)]
        PeopleAndGroups
    }

}
