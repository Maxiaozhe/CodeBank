using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    /// <summary>
    /// 処理状態
    /// </summary>
    public enum TaskState
    {
        /// <summary>
        /// 未実行
        /// </summary>
        NotExecute=0,
        /// <summary>
        /// 実行済み
        /// </summary>
        Executed=1,
        /// <summary>
        /// 実行失敗
        /// </summary>
        ExecutFailed=2
    }
}
