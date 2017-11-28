using Rex.Tools.Test.DataCheck.Controls;
using Rex.Tools.Test.DataCheck.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rex.Tools.Test.DataCheck
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = System.Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if (RunBatch(args))
                {
                    return;
                }
                else
                {
                    ShowHelp();
                    return;
                }
            }
            string url = System.Web.HttpUtility.UrlEncode("http://z00h801962:m@xz1205@proxy.ricoh.co.jp:8080");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm());

        }

        /// <summary>
        /// バッチ処理
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool RunBatch(string[] args)
        {
            try
            {
                Dictionary<string, string> argList = GetCommandArgs(args);
                if (argList.Count == 0) return false;
                if (!argList.ContainsKey("mode")) return false;
                if (argList.ContainsKey("help"))
                {
                    return false;
                }
                string mode = argList["mode"];
                switch (mode)
                {
                    case "0":
                        if (argList.ContainsKey("path") && argList.ContainsKey("target"))
                        {
                            string path = argList["path"];
                            if (!System.IO.Directory.Exists(path))
                            {
                                return false;
                            }
                            bool isTarget = false;

                            if (!bool.TryParse(argList["target"], out isTarget))
                            {
                                return false;
                            }
                            string pattern = "*.xlsm";
                            if (argList.ContainsKey("pattern"))
                            {
                                pattern = argList["pattern"];
                            }
                            string batchFile = string.Empty;
                            if (argList.ContainsKey("batch"))
                            {
                                batchFile = argList["batch"];
                            }
                            string[] files = System.IO.Directory.GetFiles(path, pattern, System.IO.SearchOption.AllDirectories);
                            foreach (string file in files)
                            {
                                //SQL作成
                                TestDataInitializer initializer = new TestDataInitializer(null);
                                initializer.DoInitlize(file, isTarget, batchFile);
                            }
                            return true;
                        }
                        break;
                    case "1":
                        if (argList.ContainsKey("exceptfile"))
                        {
                            string exceptfile = argList["exceptfile"];
                            if (!System.IO.File.Exists(exceptfile))
                            {
                                return false;
                            }
                            TestDataChecker checker = new TestDataChecker(null);
                            string outputFolder = "";
                            if (argList.ContainsKey("output"))
                            {
                                outputFolder = argList["output"];
                            }
                            checker.CheckDatas(exceptfile, outputFolder);
                            return true;
                        }
                        break;
                    default:
                        break;
                }
                return false;
            }
            catch(Exception ex)
            {
                Logging.Exception("Batch", ex);
                return false;
            }
        }

        private static void ShowHelp()
        {
            MessageBox.Show(Resource.StringTable.Messages.BatchHelp,"ヘルプ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        /// <summary>
        ///１．指定するフォルダ中のExcelファイルからSQLバッチファイルを一括作成します。
        ///DataCheckTool.exe -M 0 -P "Folder" -T [True|False] [-S "Pattern"] [-B "FileName"]
        ///２．指定する期待データと移行結果を比較します。
        ///DataCheckTool.exe -M 1 -F "期待データファイル" [-O "出力フォルダ"]
        ///
        ///-M [0]                処理モード 0:データインサートバッチ作成 1:データチェック
        ///-P "Folder"           対象ファイルのフォルダ
        ///-T [True|False]       移行先DBかどうか True:移行先　False：移行元
        ///-S "Pattern"          対象ファイルの検索パタン(例：*(移行元).xls?)
        ///-B "Bitch File Name"  他のバッチ処理（ある場合）
        ///-F "期待データ"       期待データのファイルパス　
        ///-O "出力フォルダ"     比較結果報告の出力フォルダ
        ///-H                    ヘルプ表示
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetCommandArgs(string[] args)
        {
            string key = string.Empty;
            Dictionary<string, string> argList = new Dictionary<string, string>();
            foreach (string arg in args)
            {
                if (string.IsNullOrEmpty(arg)) continue;
                switch (arg.ToUpper())
                {
                    case "-H":
                        key = "help";
                        argList.Add(key, "");
                        return argList;
                    case "-M":
                        key = "mode";
                        continue;
                    case "-P":
                        key = "path";
                        continue;
                    case "-T":
                        key = "target";
                        continue;
                    case "-S":
                        key = "pattern";
                        continue;
                    case "-B":
                        key = "batch";
                        continue;
                    case "-F":
                        key = "exceptfile";
                        continue;
                    case "-O":
                        key = "output";
                        continue;
                    default:
                        if (!string.IsNullOrEmpty(key))
                        {
                            if (!argList.ContainsKey(key))
                            {
                                argList.Add(key, arg);
                            }
                        }
                        key = string.Empty;
                        continue;
                }
            }
            return argList;
        }
    }
}
