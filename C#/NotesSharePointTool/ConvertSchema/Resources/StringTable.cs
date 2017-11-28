using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Resources
{
    public enum StringTable
    {
        /// <summary>
        /// NSPコンバート
        /// </summary>
        ToolCaption,
        /// <summary>
        /// Sql Server認証
        /// </summary>
        AuthenticateMode_SqlServer,
        /// <summary>
        /// Windows認証
        /// </summary>
        AuthenticateMode_Windows,
        /// <summary>
        /// 未実行
        /// </summary>
        TaskState_NotExecute,
        /// <summary>
        /// 実行済み
        /// </summary>
        TaskState_Executed,
        /// <summary>
        /// 実行失敗
        /// </summary>
        TaskState_ExecutFailed,
        /// <summary>
        /// Listアイコンファイル名
        /// </summary>
        DBIconName,
        /// <summary>
        /// List小さいアイコンファイル名
        /// </summary>
        DBSmallIconName,
        /// <summary>
        /// List大きいアイコンファイル名
        /// </summary>
        DBLargeIconName,
    }
}
