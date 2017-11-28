using RJ.Tools.NotesTransfer.Engines.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    public enum LogType:int
    {
        /// <summary>
        /// 操作ログ
        /// </summary>
        [EnumName("操作ログ", LogType.Operation)]
        Operation=0,
        /// <summary>
        /// 処理ログ
        /// </summary>
         [EnumName("処理ログ", LogType.Process)]
        Process=1,
        /// <summary>
        /// システムログ
        /// </summary>
         [EnumName("システムログ", LogType.System)]
        System=2,

    }
}
