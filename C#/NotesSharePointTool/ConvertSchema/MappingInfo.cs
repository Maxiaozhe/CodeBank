using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    /// <summary>
    /// Notes->SPへ型変換マッピング情報
    /// </summary>
    public class MappingInfo
    {
        #region 内部変数
        private const string _MappingFileName = "Mapping.xml";
        private static string _XmlFilePath;
        private static Mappings _MappingSetting;
        private static object Locker = new object();
        #endregion

        #region プロパティ
        /// <summary>
        /// DataBaseマッピング設定
        /// </summary>
        private static Mappings.DbTypeMapDataTable DbTypeMap
        {
            get
            {
                EnsureInstance();
                return _MappingSetting.DbTypeMap;
            }
        }
        /// <summary>
        /// Viewのマッピング設定
        /// </summary>
        private static Mappings.ViewTypeMapDataTable ViewTypeMap
        {
            get
            {
                EnsureInstance();
                return _MappingSetting.ViewTypeMap;
            }
        }
        /// <summary>
        /// Fieldのマッピング設定
        /// </summary>
        private static Mappings.FieldTypeMapDataTable FieldMap
        {
            get
            {
                EnsureInstance();
                return _MappingSetting.FieldTypeMap;
            }
        }

        /// <summary>
        /// NotesDateBaseの変換先のSPListタイプを取得する
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static SPListType GetTagetDbType( NotesDbType dbType)
        {
            string typeName = dbType.ToString();
            var result = DbTypeMap.Where(row => row.NotesDbType == typeName);
            if (result.Count()==0)
            {
                result = DbTypeMap.Where(row => row.NotesDbType == "DEFAULT");
            }
            SPListType type= SPListType.InvalidType;
            if (result.Count()>0 && result.First().CanConvert )
            {

                if (Enum.TryParse(result.First().SPListType, out type))
                {
                    return type;
                }
            }
            return SPListType.InvalidType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        public static SPFieldType GetTargetFieldType(NotesFieldType fieldType)
        {
            string typeName = fieldType.ToString();
            var result = FieldMap.Where(row => row.NotesFieldType == typeName);
            if (result.Count()==0)
            {
                result = FieldMap.Where(row => row.NotesFieldType == "DEFAULT");
            }
            SPFieldType type = SPFieldType.Invalid;
            if (result.Count()>0 && result.First().CanConvert)
            {
                if (Enum.TryParse(result.First().SPFieldType, out type))
                {
                    return type;
                }
            }
            return SPFieldType.Invalid;
        }

        public static SPViewType GetTargetViewType(NotesViewType viewType)
        {
            string typeName = viewType.ToString();
            var result = ViewTypeMap.Where(row => row.NotesViewType == typeName);
            SPViewType type = SPViewType.None;
            if (result.Count()>0 && result.First().CanConvert)
            {
                if (Enum.TryParse(result.First().SPViewType, out type))
                {
                    return type;
                }
            }
            return SPViewType.None;
        }



        #endregion

        #region メソッド
        /// <summary>
        /// ドメインリストを確保する
        /// </summary>
        private  static void EnsureInstance()
        {
            lock (Locker)
            {
                if (_MappingSetting != null) return;
                string basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                _XmlFilePath = Path.Combine(basePath, _MappingFileName);
                if (File.Exists(_XmlFilePath))
                {
                    _MappingSetting = new Mappings();
                    _MappingSetting.ReadXml(_XmlFilePath);
                }
                else
                {
                    _MappingSetting = new Mappings();
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(Properties.Resources.Mappings);
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        _MappingSetting.ReadXml(stream, System.Data.XmlReadMode.Auto);
                    }
                }
            }
        }
        #endregion

     
    }
}
