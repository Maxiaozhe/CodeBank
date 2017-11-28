using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    public interface IForm 
    {

        int FormNo
        {
            get;
        }

        string TaskId
        {
            get;
        }

        /// <summary>
        /// 名前
        /// </summary>
         string Name
        {
            get;
        }

         string DisplayName
         {
             get;
             set;
         }

        /// <summary>
        /// 別名
        /// </summary>
        List<string> Aliases
        {
            get;
        }

        /// <summary>
        /// フィールド一覧
        /// </summary>
        List<IField> Fields
        {
            get;
        }

        bool IsDefault
        {
            get;
        }

        bool IsDefaultNewForm
        {
            get;
            set;
        }
        bool IsDefaultEditForm
        {
            get;
            set;
        }

        bool IsDefaultDispForm
        {
            get;
            set;
        }

        bool HasNewForm
        {
            get;
            set;
        }
        bool HasEditForm
        {
            get;
            set;
        }
        bool HasDispForm
        {
            get;
            set;
        }
        string NewFormName
        {
            get;
            set;
        }
        string EditFormName
        {
            get;
            set;
        }
        string DispFormName
        {
            get;
            set;
        }

        string FormDxl
        {
            get;
            set;
        }

        bool IsTarget
        {
            get;
            set;
        }

        string NotesUrl
        {
            get;
        }
        /// <summary>
        /// SharePoint側生成されたGUID
        /// </summary>
        string SpId
        {
            get;
            set;
        }
        /// <summary>
        /// SharePoint側のServerRelativeUrl
        /// </summary>
        string SpUrl
        {
            get;
            set;
        }
        /// <summary>
        /// フォームレイアウト
        /// </summary>
        string FormLayout { get; set; }
        string GetAliasesString();

        string SerializFields();

        List<IField> DeSerializFields(string serializeStr);
    }
}
