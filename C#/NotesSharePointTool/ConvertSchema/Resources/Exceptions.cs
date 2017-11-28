
namespace RJ.Tools.NotesTransfer.Engines.Resources
{
    public enum Exceptions
    {
        #region Common
        /// <summary>
        /// 引数({0})のインスタンスが初期化されていません。
        /// </summary>
        ArgumentIsNull,
        /// <summary>
        /// システムの設定がありません。
        /// </summary>
        NotConfiged,
        #endregion
        #region Config
        /// <summary>
        /// 指定されたパス「{0}」が見つかりません。
        /// </summary>
        PathNotExists,
        #endregion
        #region SPAccessor
        /// <summary>
        /// リスト"{0}"が既に存在します。
        /// </summary>
        ListIsExists,
        #endregion
        #region NotesAccessor
        /// <summary>
        /// セッションが初期化されていません。
        /// </summary>
        SessionNotInitialized,
        /// <summary>
        /// ドミノサーバーの初期化が失敗しました。{0}
        /// </summary>
        DominoInitError,
        /// <summary>
        /// ドミノデータベース「{0}」が見つかりません。
        /// </summary>
        NotFoundDB,
        /// <summary>
        /// ドミノデータベース「{0}」を開くことができません。
        /// </summary>
        DominoDBOpenFailed,
        /// <summary>
        /// パスワードが違います。
        /// </summary>
        PasswordIncorrected,
        /// <summary>
        /// 読み取り専用フィールドです。
        /// </summary>
        ReadOnlyFieldCantRequired,
        #endregion
    
    }
}
