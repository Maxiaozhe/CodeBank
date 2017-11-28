
namespace RJ.Tools.NotesTransfer.Engines.Resources
{
    public enum Exclamations
    {
        #region SPSetting
        /// <summary>
        /// ユーザーIDを入力してください。
        /// </summary>
        NotSPUserID,
        /// <summary>
        /// パースワードを入力してください。
        /// </summary>
        NotSPPassword,
        /// <summary>
        /// SharePointのWebサイトを入力してください。
        /// </summary>
        NotSPWebSite,
        /// <summary>
        /// SharePointサーバーへ接続できません。接続情報を確認してください。
        /// </summary>
        SPConnectFailed,
        #endregion

        #region NotesSetting
        /// <summary>
        /// パスワードが違います。（大文字小文字を正しく指定してください）
        /// </summary>
        InvalidNotesPassword,
        /// <summary>
        /// パースワードを入力してください。
        /// </summary>
        NotNotesPassword,
        /// <summary>
        /// 出力先フォルダを設定してください。
        /// </summary>
        NotExportFolder,
        /// <summary>
        /// 出力先フォルダがありません。
        /// </summary>
        ExportFolderNotExists,


        #endregion
        
        #region SqlServer
        /// <summary>
        /// ユーザーIDを入力してください。
        /// </summary>
        NotDBUserID,
        /// <summary>
        /// パースワードを入力してください。
        /// </summary>
        NotDBPassword,
        /// <summary>
        /// サーバー名を入力してください。
        /// </summary>
        NotServer,
        /// <summary>
        /// 認証モードを選択してください。
        /// </summary>
        NotAuthMode,
        /// <summary>
        /// データベース名を選択してください。
        /// </summary>
        NotDataBase,
        /// <summary>
        /// SQLサーバーへ接続できません。接続情報を確認してください。
        /// </summary>
        DbConnectFailed,
        #endregion
        
        #region DataBaseSetting
        /// <summary>
        /// 変換名を入力してください。
        /// </summary>
        NotTaskName,
        /// <summary>
        /// 変換対象を選択してください。
        /// </summary>
        NotTagetDatabase,
        /// <summary>
        /// 変換対象データベース種別が存在しないかアクセスができません。
        /// </summary>
        CantOpenDatabase,
        /// <summary>
        /// 移行先リスト名を入力してください。
        /// </summary>
        NotListName,
        /// <summary>
        /// 有効な移行先リスト名（半角英数）を入力してください。
        /// </summary>
        InvalidateListName,
        /// <summary>
        /// タイトル名を入力してください。
        /// </summary>
        NotTitleName,
        /// <summary>
        /// 移行先Webサイト名を入力してください。
        /// </summary>
        NotWebSiteName,
        /// <summary>
        /// 対象フォームを選択してください。
        /// </summary>
        NotTargetForm,
        /// <summary>
        /// 対象ビューを選択してください。
        /// </summary>
        NotTargetView,
        /// <summary>
        /// 参照フォーム"{0}"を追加してください。
        /// </summary>
        NotReferForm,
        #endregion
        
        #region FormSetting
        /// <summary>
        /// フォームタイトルを入力してください。
        /// </summary>
        NotFormName,
        /// <summary>
        /// アイテム作成フォームのファイル名を入力してください。
        /// </summary>
        NotNewFormName,
        /// <summary>
        /// アイテム編集フォームのファイル名を入力してください。
        /// </summary>
        NotEditFormName,
        /// <summary>
        /// アイテム表示フォームのファイル名を入力してください。
        /// </summary>
        NotDispFormName,
        /// <summary>
        /// 有効な作成フォームのファイル名（半角英数）を入力してください。
        /// </summary>
        InvalidateNewFormName,
        /// <summary>
        /// 有効な編集フォームのファイル名（半角英数）を入力してください。
        /// </summary>
        InvalidateEditFormName,
        /// <summary>
        /// 有効な表示フォームのファイル名（半角英数）を入力してください。
        /// </summary>
        InvalidateDispFormName,
        #endregion

        #region ViewSetting
        /// <summary>
        /// ビュータイトルを入力してください。
        /// </summary>
        NotViewTitle,
        /// <summary>
        /// 表示列を追加してください。
        /// </summary>
        NotDisplayColumn,
        #endregion
        #region LogAdmin
        /// <summary>
        /// 1000件の最大表示件数を超えました。
        /// </summary>
        MaxDisplayNumOvered,
        /// <summary>
        /// ログ種別を選択してください。
        /// </summary>
        NotSelectLogType,
        /// <summary>
        /// 正しい日付範囲を入力してください。
        /// </summary>
        InvalidateDateRang,
        #endregion

    }
}
