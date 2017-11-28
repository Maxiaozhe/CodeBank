using RJ.Tools.NotesTransfer.Engines.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    [Editor(typeof(EnumUIEditor), typeof(UITypeEditor)), TypeConverter(typeof(EnumNameConverter))]
    public enum SPFieldType
    {
        [EnumName("変換しない", SPFieldType.Invalid)]
        Invalid = 0,
        Integer = 1,
        [EnumName("1 行テキスト", SPFieldType.Text)]
        Text = 2,
        [EnumName("複数行テキスト", SPFieldType.Note)]
        Note = 3,
        [EnumName("日付と時刻", SPFieldType.DateTime)]
        DateTime = 4,
        Counter = 5,
        [EnumName("選択肢", SPFieldType.Choice)]
        Choice = 6,
        Lookup = 7,
        Boolean = 8,
        [EnumName("数値", SPFieldType.Number)]
        Number = 9,
        [EnumName("通貨", SPFieldType.Currency)]
        Currency = 10,
        URL = 11,
        Computed = 12,
        Threading = 13,
        Guid = 14,
        [EnumName("選択肢", SPFieldType.MultiChoice)]
        MultiChoice = 15,
        GridChoice = 16,
        Calculated = 17,
        File = 18,
        Attachments = 19,
        [EnumName("ユーザーまたはグループ", SPFieldType.User)]
        User = 20,
        Recurrence = 21,
        CrossProjectLink = 22,
        ModStat = 23,
        Error = 24,
        ContentTypeId = 25,
        PageSeparator = 26,
        ThreadIndex = 27,
        WorkflowStatus = 28,
        AllDayEvent = 29,
        WorkflowEventType = 30,
        Geolocation = 31,
        OutcomeChoice = 32,
        MaxItems = 33,
    }
}
