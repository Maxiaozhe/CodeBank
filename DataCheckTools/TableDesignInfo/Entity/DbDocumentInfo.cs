using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDesignInfo.Entity
{
   public class DbDocumentInfo
    {
       private List<string> _tableNames;

       public DbDocumentInfo()
       {
           this._tableNames = new List<string>();
       }

       /// <summary>
       /// ファイル名
       /// </summary>
       public string FileName
       {
           get;
           set;
       }
       /// <summary>
       /// システム名
       /// </summary>
       public string SystemName
       {
           get;
           set;
       }
       /// <summary>
       /// サブシステム名
       /// </summary>
       public string SubSystemName
       {
           get;
           set;
       }
       /// <summary>
       /// 生成するテーブル一覧
       /// </summary>
       public List<string> TableNames
       {
           get
           {
               return this._tableNames;
           }
       }
       /// <summary>
       /// テンプレート情報
       /// </summary>
       public TemplateInfo.DocumentTemplateRow TemplateInfo
       {
           get;
           set;
       }
    }
}
