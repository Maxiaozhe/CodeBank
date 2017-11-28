using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    /// <summary>
    /// ユーザーマッピング情報
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 変換元ユーザー名(Notes User)
        /// </summary>
        string SourceUser
        {
            get;
            set;
        }

        /// <summary>
        /// 変換先ユーザー名(SPUser)
        /// </summary>
        string TargetUser
        {
            get;
            set;
        }

        /// <summary>
        /// 表示名
        /// </summary>
        string DisplayName
        {
            get;
            set;
        }
    }
}
