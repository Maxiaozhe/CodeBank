using Rex.Tools.Test.DataCheck.Controls.SqlServer;
using Rex.Tools.Test.DataCheck.Entity;
using Rex.Tools.Test.DataCheck.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Tools.Test.DataCheck.Common
{
    /// <summary>
    /// 配置情報を取得するためクラスを実装する
    /// </summary>
    public class Config
    {
        #region Const
        private const string KEY_CONFIG_FILE_NAME = "CheckPartten.xml";
        private const string KEY_COMMAND_TIMEOUT = "CommandTimeout";
        private const string KEY_TARGET_DATABASE = "TargetDatabase";
        private const string KEY_SOURCE_DATABASE = "SourceDatabase";
        private const string KEY_DENSHOW_DATABASE = "DenshowDatabase";
        private const string KEY_MAX_DATA_COUNT = "MaxDataCount";

        private const string KEY_EXPORT_FOLDER = "ExportFolder";
        #endregion

        private static CheckInfoSet InfoSet = null;

        private static void EnsureInstance()
        {
            if (InfoSet == null)
            {
                InfoSet = LoadConfig();
            }
        }

        private static CheckInfoSet LoadConfig()
        {
            string configPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase, KEY_CONFIG_FILE_NAME);
            CheckInfoSet infoSet = new CheckInfoSet();
            infoSet.ReadXml(configPath, System.Data.XmlReadMode.Auto);
            return infoSet;
        }

        public static CheckInfoSet.CheckParttenDataTable CheckPartten
        {
            get
            {
                EnsureInstance();
                return InfoSet.CheckPartten;
            }
        }

        /// <summary>
        /// データベース接続文字列
        /// </summary>
        public static string TargetDbConnection
        {
            get
            {
                var conn = System.Configuration.ConfigurationManager.ConnectionStrings[KEY_TARGET_DATABASE];
                return conn.ConnectionString;
            }
        }

        /// <summary>
        /// データベース接続文字列
        /// </summary>
        public static string SourceDbConnection
        {
            get
            {
                var conn = System.Configuration.ConfigurationManager.ConnectionStrings[KEY_SOURCE_DATABASE];
                return conn.ConnectionString;
            }
        }


        /// <summary>
        /// データベース接続文字列
        /// </summary>
        public static string DenshowDbConnection
        {
            get
            {
                var conn = System.Configuration.ConfigurationManager.ConnectionStrings[KEY_DENSHOW_DATABASE];
                return conn.ConnectionString;
            }
        }


        /// <summary>
        /// データベース接続文字列
        /// </summary>
        public static string DenshowDbSchema
        {
            get
            {
                string schema = System.Configuration.ConfigurationManager.AppSettings["DenshowDbSchema"];
                return schema;
            }
        }

        /// <summary>
        /// CommondTimeout設定
        /// </summary>
        public static int CommandTimeout
        {
            get
            {
                string value = System.Configuration.ConfigurationManager.AppSettings[KEY_COMMAND_TIMEOUT];
                int timeout = 0;
                if (string.IsNullOrEmpty(value) || !int.TryParse(value, out timeout))
                {
                    return 60;
                }
                return timeout;
            }
        }
        /// <summary>
        /// テンプレートファイル名
        /// </summary>
        public static string TemplateFile
        {
            get
            {
                string tempFile = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                        @"Template\DataCheckTemplate.xlsm");
                return tempFile;
            }
        }
        /// <summary>
        /// テンプレートファイル名
        /// </summary>
        public static string PostgreSqlTemplateFile
        {
            get
            {
                string tempFile = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                        @"Template\NpgDataCheckTemplate.xlsm");
                return tempFile;
            }
        }

        /// <summary>
        /// 移行設定ファイル名
        /// </summary>
        /// <param name="isTarget">移行先DBかどうか</param>
        public static string GetTransferSettingFile(bool isTargetDB)
        {
            string fileName = isTargetDB ? @"Template\LiveDBSetting.xlsm" : @"Template\SeedDBSetting.xlsm";
            string filePath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase, fileName);
            return filePath;
        }

        /// <summary>
        /// 伝匠設定ファイル名
        /// </summary>
        /// <param name="isTarget">移行先DBかどうか</param>
        public static string GetDenshowSettingFile()
        {
            string fileName =  @"Template\DenshowDBSetting.xlsm" ;
            string filePath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase, fileName);
            return filePath;
        }

        /// <summary>
        /// テーブルリスト設定ファイル名
        /// </summary>
        public static string DbTableListSettingFile
        {
            get
            {
                string fileName = @"Template\DatabaseLayouts.xlsm";
                string filePath = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.SetupInformation.ApplicationBase, fileName);
                return filePath;
            }
        }

        /// <summary>
        /// データ確認結果報告テンプレート
        /// </summary>
        public static string ReportTemplateFile
        {
            get
            {
                string tempFile = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                        @"Template\DataCheckReport.xlsx");
                return tempFile;
            }
        }


        /// <summary>
        /// 生産計画・実績データ作成シート
        /// </summary>
        public static string ProductDataSheet
        {
            get
            {
                string folder = System.IO.Path.Combine(ExportFolder, "Template");
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                string fileName = string.Format("ProductData_{0}", DateTime.Now.ToString("yyMMdd_HHmm")) + ".xlsm";
                return System.IO.Path.Combine(folder, fileName);
            }
        }

        /// <summary>
        /// 設備計画・実績データ作成シート
        /// </summary>
        public static string OperatDataSheet
        {
            get
            {
                string folder = System.IO.Path.Combine(ExportFolder, "Template");
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                string fileName = string.Format("OprateData_{0}", DateTime.Now.ToString("yyMMdd_HHmm")) + ".xlsm";
                return System.IO.Path.Combine(folder, fileName);
            }
        }

        /// <summary>
        ///Live初期化データ作成シート
        /// </summary>
        public static string LiveInitDataSheet
        {
            get
            {
                string folder = System.IO.Path.Combine(ExportFolder, "Template");
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                string fileName = string.Format("LiveDB_InitData_{0}", DateTime.Now.ToString("yyMMdd_HHmm")) + ".xlsm";
                return System.IO.Path.Combine(folder, fileName);
            }
        }

        /// <summary>
        ///Seed初期化データ作成シート
        /// </summary>
        public static string SeedInitDataSheet
        {
            get
            {
                string folder = System.IO.Path.Combine(ExportFolder, "Template");
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                string fileName = string.Format("SeedDB_InitData_{0}", DateTime.Now.ToString("yyMMdd_HHmm")) + ".xlsm";
                return System.IO.Path.Combine(folder, fileName);
            }
        }
        /// <summary>
        ///Excelファイルの保存パスを取得する
        /// </summary>
        public static string GetDataSheetSavePath(string name)
        {
         
                string folder = System.IO.Path.Combine(ExportFolder, "Template");
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                string fileName = name + "_" + DateTime.Now.ToString("yyMMddHHmm") + ".xlsm";
                return System.IO.Path.Combine(folder, fileName);
        }



        /// <summary>
        /// データ比較結果出力フォルダ
        /// </summary>
        public static string ReportExportFolder
        {
            get
            {
                string folder = System.IO.Path.Combine(ExportFolder, "Report");
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                return folder;
            }
        }


        /// <summary>
        /// データ比較結果出力フォルダ
        /// </summary>
        public static string ExportFolder
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[KEY_EXPORT_FOLDER];
            }
        }

        /// <summary>
        /// 期待データの最大件数
        /// </summary>
        public static int MaxDataCount
        {
            get
            {
                int retValue = 0;
                if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings[KEY_MAX_DATA_COUNT], out retValue))
                {
                    return retValue;
                }
                else
                {
                    return 1000;
                }
            }
        }

        /// <summary>
        /// テストデータ作成用データシートのファイルパスを取得する
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static string GetDataSheetPath(DataKind kind)
        {
            switch (kind)
            {
                case DataKind.ProductionData:
                    return ProductDataSheet;
                case DataKind.OperationData:
                    return OperatDataSheet;
                case DataKind.SeedInitData:
                    return SeedInitDataSheet;
                case DataKind.LiveInitData:
                    return LiveInitDataSheet;
                default:
                    return string.Empty;
            }
        }
     
    }
}
