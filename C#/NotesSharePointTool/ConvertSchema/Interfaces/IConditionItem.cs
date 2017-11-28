using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    public interface IConditionItem
    {
        /// <summary>
        /// XMLタグ名
        /// </summary>
        string TagName { get; }

        /// <summary>
        /// XMLへ出力
        /// </summary>
        void ToXml(XmlWriter writer);
    }
}
