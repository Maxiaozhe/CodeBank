using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Common
{
    public static class Config
    {
        private static Properties.Settings settings = Properties.Settings.Default;
      

        #region Notes
        /// <summary>
        /// ノーツパスワード
        /// </summary>
        public static string NotesPassword
        {
            get
            {
                string enValue = settings.NotesPassword;
                if (string.IsNullOrEmpty(enValue)) return string.Empty;
                return Security.Encryptor.Decode(enValue);
            }
            set
            {
                string enValue = Security.Encryptor.Encode(value);
                settings["NotesPassword"] = enValue;
            }
        }

        public static string ExportFolder
        {
            get
            {
                return settings.ExportFolder;
            }
            set
            {
                settings["ExportFolder"] = value;
            }
        }
        #endregion

        #region SharePoint
        /// <summary>
        /// SP既定のWebサイト
        /// </summary>
        public static string SPDefaultWebSite
        {
            get
            {

                return settings.SPDefaultWebSite;
            }
            set
            {
                settings["SPDefaultWebSite"] = value;
            }
        }


        public static string SPUserId
        {
            get
            {
                return settings.SPUserId;
            }
            set
            {
                settings["SPUserId"] = value;
            }
        }

        public static string SPPassword
        {
            get
            {
                string enValue = settings.SPPassword;
                if(string.IsNullOrEmpty(enValue)) return string.Empty;
                return Security.Encryptor.Decode(enValue);
            }
            set
            {
                string enValue = Security.Encryptor.Encode(value);
                settings["SPPassword"] = enValue;
            }
        }
        #endregion

        #region SqlServer
        /// <summary>
        /// SQLサーバー名
        /// </summary>
        public static string SqlServer
        {
            get
            {
                return settings.SqlServer;
            }
            set
            {
                settings["SqlServer"] = value;
            }
        }
        /// <summary>
        /// SQLサーバー認証モード
        /// </summary>
        public static int DBAuthenticateMode
        {
            get
            {
                return settings.DBAuthenticateMode;
            }
            set
            {
                settings["DBAuthenticateMode"] = value;
            }
        }

        /// <summary>
        /// SQLServer認証ユーザーID
        /// </summary>
        public static string DBUserId
        {
            get
            {
                return settings.DBUserId;
            }
            set
            {
                settings["DBUserId"] = value;
            }
        }
        /// <summary>
        /// SQLServer認証パスワード
        /// </summary>
        public static string DBPassWord
        {
            get
            {
                string enValue = settings.DBPassWord;
                if (string.IsNullOrEmpty(enValue)) return string.Empty;
                return Security.Encryptor.Decode(enValue);
            }
            set
            {
                string enValue = Security.Encryptor.Encode(value);
                settings["DBPassWord"] = enValue;
            }
        }
        /// <summary>
        /// SQLサーバーのデータベース名
        /// </summary>
        public static string DataBaseName
        {
            get
            {
                return settings.DataBaseName;
            }
            set
            {
                settings["DataBaseName"] = value;
            }
        }
        /// <summary>
        /// データベース接続のタイムアウト時間
        /// </summary>
        public static int ConnectTimeout
        {
            get
            {
                return settings.ConnectionTimeout;
            }
        }
        /// <summary>
        /// データベースコマンド実行の待機時間
        /// </summary>
        public static int CommandTimeout
        {
            get
            {
                return settings.CommandTimeout;
            }
        }
        #endregion
        /// <summary>
        /// 表示フォーム用テンプレート
        /// </summary>
        private static string DispFormTemplate
        {
            get
            {
                return Properties.Resources.DispFormTemplate;
            }
        }

        /// <summary>
        /// 作成フォーム用テンプレート
        /// </summary>
        private static string NewFormTemplate
        {
            get
            {
                return Properties.Resources.NewFormTemplate;
            }
        }

        /// <summary>
        /// 編集フォーム用テンプレート
        /// </summary>
        private static string EditFormTemplate
        {
            get
            {
                return Properties.Resources.EditFormTemplate;
            }
        }
        /// <summary>
        /// 表示フォームフィールド用テンプレート
        /// </summary>
        private static string DispFieldTemplate
        {
            get
            {
                return Properties.Resources.DispFieldTemplate;
            }
        }
        /// <summary>
        /// 編集フォームフィールド用テンプレート
        /// </summary>
        private static string EditFieldTemplate
        {
            get
            {
                return Properties.Resources.EditFieldTemplate;
            }
        }

        /// <summary>
        /// 作成フォームフィールド用テンプレート
        /// </summary>
        private static string NewFieldTemplate
        {
            get
            {
                return Properties.Resources.NewFieldTemplate;
            }
        }

        #region Method
        /// <summary>
        /// フォームテンプレート
        /// </summary>
        public static string GetFormTemplate(SPFormType formMode)
        {
            switch (formMode)
            {
                case SPFormType.NewForm:
                    return Config.NewFormTemplate;
                case SPFormType.EditForm:
                    return Config.EditFormTemplate;
                case SPFormType.DispForm:
                    return Config.DispFormTemplate;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// フィールド用テンプレート
        /// </summary>
        public static string GetFieldTemplate(SPFormType formMode)
        {
            switch (formMode)
            {
                case SPFormType.NewForm:
                    return Config.NewFieldTemplate;
                case SPFormType.EditForm:
                    return Config.EditFieldTemplate;
                case SPFormType.DispForm:
                    return Config.DispFieldTemplate;
                default:
                    return string.Empty;
            }

        }

       

        /// <summary>
        /// 設定を保存する
        /// </summary>
        public static void Save()
        {

            Configuration manager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            ClientSettingsSection section = (ClientSettingsSection)manager.GetSectionGroup("applicationSettings")
                                            .Sections[Properties.Settings.Default.GetType().ToString()];
            section.Settings.Get("NotesPassword").Value.ValueXml.InnerText = settings.NotesPassword;
            section.Settings.Get("ExportFolder").Value.ValueXml.InnerText = ExportFolder;
            section.Settings.Get("SPDefaultWebSite").Value.ValueXml.InnerText = SPDefaultWebSite;
            section.Settings.Get("SPUserId").Value.ValueXml.InnerText = SPUserId;
            section.Settings.Get("SPPassword").Value.ValueXml.InnerText = settings.SPPassword;
            section.Settings.Get("DBAuthenticateMode").Value.ValueXml.InnerText = DBAuthenticateMode.ToString();
            section.Settings.Get("SqlServer").Value.ValueXml.InnerText = SqlServer;
            section.Settings.Get("DBUserId").Value.ValueXml.InnerText = DBUserId;
            section.Settings.Get("DBPassWord").Value.ValueXml.InnerText = settings.DBPassWord;
            section.Settings.Get("DataBaseName").Value.ValueXml.InnerText = DataBaseName;
            section.SectionInformation.ForceSave = true;
            manager.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(section.SectionInformation.SectionName);
        }
        #endregion
    

    }
}
