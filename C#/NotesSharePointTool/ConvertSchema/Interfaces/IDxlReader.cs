using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    /// <summary>
    /// DXLリーダーのインタフェースを定義する
    /// </summary>
    public interface IDxlReader
    {
        /// <summary>
        /// 既定フォーム名を取得する
        /// </summary>
        /// <returns></returns>
        string GetDefaultForm();
        /// <summary>
        /// 指定フォームのフィールドコレクションを取得する
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        List<IField> GetFields(string formName);
        /// <summary>
        /// フォームのDXLファイルを取得する
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        string GetFormDxl(string formName);
        /// <summary>
        /// アイコンのデータを取得する
        /// </summary>
        /// <returns></returns>
        byte[] GetRawIconData();
        /// <summary>
        /// Sharedフィールドコレクションを取得する
        /// </summary>
        /// <returns></returns>
        List<IField> GetSharedFields();
        /// <summary>
        /// 指定フォーム名からSharedフィールド名を取得する
        /// </summary>
        /// <param name="formName">フォーム名</param>
        /// <returns></returns>
        List<string> GetSharedFieldRef(string formName);
        /// <summary>
        /// イメージリソースを出力する
        /// </summary>
        void SaveImageResources(string folder, bool referedOnly);
    }
}
