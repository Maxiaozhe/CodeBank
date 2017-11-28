using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;

namespace RJ.Tools.NotesTransfer.Engines.Entity
{
  
    [Serializable]
    public class LogicItem : IConditionItem
    {
        private List<IConditionItem> _nodes = null;

        public LogicItem(LogicType type)
        {
            this.Type = type;
            this._nodes = new List<IConditionItem>();
        }

        /// <summary>
        /// ロジック種別
        /// </summary>
        public LogicType Type { get; set; }

        /// <summary>
        /// ロジックのノードを追加する
        /// </summary>
        public List<IConditionItem> Nodes
        {
            get
            {
               return this._nodes;
            }
        }

        public string TagName
        {
            get {
                return this.Type.ToString();
            }
        }

        /// <summary>
        /// フィールド参照を更新する
        /// </summary>
        /// <param name="findField"></param>
        public void RefreshFieldRef(Func<string, IFieldRef> findField)
        {
            foreach (IConditionItem item in this.Nodes)
            {
                if (item is ConditionItem)
                {
                    ConditionItem condiItem=((ConditionItem)item);
                    condiItem.FieldRef = findField(condiItem.ItemName);
                }
                else if(item is LogicItem)
                {
                    LogicItem logicItem = (LogicItem)item;
                    logicItem.RefreshFieldRef(findField);
                }
            }
        }


        public void ToXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement(this.TagName);
            if (this.Nodes.Count > 0)
            {
                foreach (IConditionItem item in this.Nodes)
                {
                    item.ToXml(writer);
                }
            }
            writer.WriteEndElement();
        }
    }
}
