using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    /// <summary>
    /// SQLサーバーの認証モード
    /// </summary>
    public enum AuthenticateMode : int
    {
        /// <summary>
        /// Windows認証
        /// </summary>
        Windows=0,
        /// <summary>
        /// SQL Server認証
        /// </summary>
        SqlServer=1
    }
}
