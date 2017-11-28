using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines.Enums;
namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    public interface IDatabase
    {
        /// <summary>
        /// タイトル
        /// </summary>
        string Title { get; }

        /// <summary>
        /// 変換元種別(Notes DataBase Type)
        /// </summary>
        NotesDbType SourceType
        {
            get;
        }

        /// <summary>
        /// 変換先種別（SPListType）
        /// </summary>
        SPListType TargetType
        {
            get;
            set;
        }

        string Server
        {
            get;
        }

        /// <summary>
        /// DB名前
        /// </summary>
        string FileName
        {
            get;
        }

        /// <summary>
        /// 変換元DBファイルパス
        /// </summary>
        string FilePath
        {
            get;
        }

        /// <summary>
        /// DXLファイルパス
        /// </summary>
        string DxlPath
        {
            get;
            set;
        }

      
        /// <summary>
        /// ノーツURL
        /// </summary>
        string NotesUrl
        {
            get;
        }
        /// <summary>
        /// レプリカID
        /// </summary>
        string ReplicaId
        {
            get;
        }

        /// <summary>
        /// フォームコレクション
        /// </summary>
        List<IForm> Forms
        {
            get;
        }
        /// <summary>
        /// ビュー
        /// </summary>
        List<IView> Views
        {
            get;
        }
        /// <summary>
        /// 内部オブジェクト（NotesDatabase）
        /// </summary>
        Object InnerObject
        {
            get;
        }

        IForm DefaultForm
        {
            get;
        }

        IView DefaultNotesView
        {
            get;
        }

        List<IField> SharedFields
        {
            get;
        }

        IDxlReader DxlReader { get; set; }
        /// <summary>
        /// データベースなかのフィールドを取得する
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        IFieldRef FindField(string fieldName);
    }
}
