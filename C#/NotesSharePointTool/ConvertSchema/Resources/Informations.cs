
namespace RJ.Tools.NotesTransfer.Engines.Resources
{
    public enum Informations
    {

        #region ConfigSetting
        /// <summary>
        /// 設定を保存しました。
        /// </summary>
        ConfigSaved,
        /// <summary>
        ///　接続が成功しました。
        /// </summary>
        TryConnectOK,
        #endregion
        #region NotesExports
        /// <summary>
        /// データベース「{0}」の設計情報の変換処理を開始します。
        /// </summary>
        ConvertStart,
        /// <summary>
        /// データベース「{0}」を接続しています。
        /// </summary>
        NotesDbConnecting,
        /// <summary>
        /// データベース「{0}」の設計情報を出力しています。
        /// </summary>
        NotesDbExporting,
        /// <summary>
        /// イメージリソースを出力しています。
        /// </summary>
        ImageResourceExporting,
        /// <summary>
        /// フォームの設計情報を出力しています。
        /// </summary>
        FormDesignExportStart,
        /// <summary>
        /// フォーム「{0}」の設計情報を出力しています。
        /// </summary>
        FormDesignExporting,
        /// <summary>
        /// フォーム「{0}」の設計情報を変換しています。
        /// </summary>
        FormDesignConverting,
        /// <summary>
        /// ノーツ設計情報出力を完了しました。
        /// </summary>
        ExportCompleted,
        #endregion
        #region SharePointImport,
        /// <summary>
        /// Sharepointサイト「{0}」を接続しています。
        /// </summary>
        SPConnecting,
        /// <summary>
        /// リスト「{0}」を作成しています。
        /// </summary>
        ListCreating,
        /// <summary>
        /// アイコンを作成しています。
        /// </summary>
        ListIconUploading,
        /// <summary>
        /// 列を作成しています。
        /// </summary>
        FieldCreatStart,
        /// <summary>
        /// 列「{0}」を作成しました。
        /// </summary>
        FieldCreated,
        /// <summary>
        /// ビューを作成しています。
        /// </summary>
        ViewCreateStart,
        /// <summary>
        /// ビュー「{0}」を作成しています。
        /// </summary>
        ViewCreated,
        /// <summary>
        /// リソースファイルをアップロードしています。
        /// </summary>
        ImageResUploaded,
        /// <summary>
        /// フォームを作成しています。
        /// </summary>
        FormCreateStart,
        /// <summary>
        /// フォーム「{0}」を作成しています。
        /// </summary>
        FormCreated,
        /// <summary>
        /// リスト「{0}」を更新しています。
        /// </summary>
        ListUpdateing,
        /// <summary>
        /// データベース「{0}」の取り込みを完了しました。
        /// </summary>
        ConvertCompleted,
        /// <summary>
        /// データベース「{0}」の取り込みが失敗しました。
        /// </summary>
        ConvertFailed,
        #endregion
        #region OperateLog
        /// <summary>
        /// データベース「{0}」を設定しました。(ID:{1})
        /// </summary>
        DataBaseSetted,
        /// <summary>
        /// データベース「{0}」の設定を削除しました。(ID:{1})
        /// </summary>
        DatabaseDeleted,
        /// <summary>
        /// フォーム「{0}」の設定を変更しました。
        /// </summary>
        FormSetted,
        /// <summary>
        /// ビュー「{0}」の設定を変更しました。
        /// </summary>
        ViewSetted,
        /// <summary>
        /// ログデータを削除しました。
        /// </summary>
        LogDataDeleted,
        #endregion

    }
}
