using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
namespace RJ.Tools.NotesTransfer.Engines.Common
{
    /// <summary>
    /// コンボボックス、リストボックスデータ項目データを格納用クラスを実装する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListItem<T>
    {
        private string _displayName;
        private T _value;

        public string DisplayName
        {
            get { return this._displayName; }
        }
      

        public T Value
        {
            get { return this._value; }
        }

        public ListItem(string name, T value)
        {
            this._displayName = name;
            this._value = value;
        }

        /// <summary>
        /// EnumのListItemコレクションを取得する
        /// </summary>
        /// <typeparam name="T">Enumタイプ</typeparam>
        /// <param name="enumType"></param>
        /// <remarks>
        ///  注意：
        ///  表示名はStringTableに追加する必要があります。
        ///  StringTableのリソース項目の名前は"Enum Type name" + "_" + "Name"
        /// </remarks>
        /// <returns></returns>
        public static List<ListItem<T>> GetEnumItem()        {
            Type enumType = typeof(T);
            if (!enumType.IsSubclassOf(typeof(Enum)))
            {
                return null;
            }
            var values = Enum.GetValues(enumType).Cast<T>();
            List<ListItem<T>> items = new List<ListItem<T>>();
            foreach (T value in values)
            {
                string key = enumType.Name + "_" + value.ToString();
                string name = RSM.GetStringByKey(key, typeof(RS.StringTable));
                items.Add(new ListItem<T>(name, value));
            }
            return items;
        }
    }
}
