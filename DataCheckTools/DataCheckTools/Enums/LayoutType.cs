using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Tools.Test.DataCheck.Enums
{
    /// <summary>
    /// データベース設計書のレイアウト種別
    /// </summary>
    public enum LayoutType
    {
        /// <summary>
        /// 新LIVEデータベース設計書
        /// </summary>
        Live,
        /// <summary>
        /// 旧SEEDデータベース設計書
        /// </summary>
        Seed
    }

    /// <summary>
    /// SQLスクリプト作成オプション
    /// </summary>
    [Flags]
    public enum ScriptOptions
    {
        /// <summary>
        /// Drop Table作成
        /// </summary>
        DropTables = 2,
        /// <summary>
        /// テーブル説明文をドロップする
        /// </summary>
        DropDropDescriptions = 4,
        /// <summary>
        /// Create Table作成
        /// </summary>
        CreateTables = 8,
        /// <summary>
        /// テーブル説明文を作成
        /// </summary>
        CreateDropDescriptions = 16
    }

}
