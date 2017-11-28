
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines.Common;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Notes.Controls;
using RJ.Tools.NotesTransfer.Engines.Sharepoint.Controls;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using RJ.Tools.NotesTransfer.Engines.Enums;
using System.IO;

namespace RJ.Tools.NotesTransfer.UI.Accessor
{
    public class Convertor
    {

        #region Field
        private NotesAccessor _notesAccessor;
        private ProgressReporter _reporter;
        #endregion
        #region Property
        private ProgressReporter Reporter
        {
            get
            {
                return this._reporter;
            }
        }
        #endregion

        /// <summary>
        /// 変換を実行する
        /// </summary>
        /// <param name="task"></param>
        public void DoConvert(IMigrateTask task, ProgressReporter reporter)
        {
            try
            {
                this._reporter = reporter;
                reporter.Report(RS.Informations.ConvertStart, task.NotesDbTitle);
                ExportNotesInfo(task);
                reporter.Report(RS.Informations.ListCreating, task.DisplayName);
                ImportToSharepoint(task);
                reporter.Report(RS.Informations.ConvertCompleted, task.DisplayName);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// リストを作成する
        /// </summary>
        /// <param name="task"></param>
        private void ImportToSharepoint(IMigrateTask task)
        {
            SpAccessor spAccessor = AccessorFactory.GetSpAccessor(task.SPSiteUrl, Config.SPUserId, Config.SPPassword);
            spAccessor.ImportList(task, this.Reporter);
        }

        /// <summary>
        /// /ノーツ設計情報を出力する
        /// </summary>
        /// <param name="task"></param>
        private void ExportNotesInfo(IMigrateTask task)
        {
            //データベース接続
            Reporter.SetStep(5,1,RS.Informations.NotesDbConnecting, task.NotesDbTitle);
            NotesAccessor nsAccessor = GetNotesAccessor();
            IDatabase db = null;
            if (task.CurrentDb == null && !string.IsNullOrEmpty(task.NotesFilePath))
            {
                db = nsAccessor.GetDataBase(task.NotesFilePath, task.NotesServer);
                task.CurrentDb = db;
            }
            //出力フォルダ
            Reporter.SetStep(10, 2, RS.Informations.NotesDbExporting, task.NotesDbTitle);
            string baseDir = System.IO.Path.Combine(Config.ExportFolder, task.TaskId);
            if (System.IO.Directory.Exists(baseDir))
            {
                System.IO.Directory.Delete(baseDir, true);
            }
            System.IO.Directory.CreateDirectory(baseDir);
            //データベースフォルダ
            string databaseDir = System.IO.Path.Combine(baseDir, "Database");
            if (!System.IO.Directory.Exists(databaseDir))
            {
                System.IO.Directory.CreateDirectory(databaseDir);
            }
            //アイコン出力する
            Reporter.ReportStep(RS.Informations.NotesDbExporting, true, task.NotesDbTitle);
            ExportDBIcon(nsAccessor, task, databaseDir);
            //DXLファイルを出力する
            Reporter.ReportStep(RS.Informations.NotesDbExporting, true, task.NotesDbTitle);
            IDxlReader dxlReader = nsAccessor.ExportDatabaseDxl(db, databaseDir);

            //イメージソースを出力する
            Reporter.SetStep(10, 1, RS.Informations.ImageResourceExporting);
            string imageDir = System.IO.Path.Combine(baseDir, "ImageResource");
            dxlReader.SaveImageResources(imageDir, false);

            //フォームDXLを出力する
            Reporter.SetStep(5, task.TargetForms.Count*2, RS.Informations.FormDesignExportStart);
            ExportFormDxl(task, dxlReader, baseDir);
        }

        /// <summary>
        /// フォームDXLを出力する
        /// </summary>
        /// <param name="task"></param>ｑ
        /// <param name="dxlReader"></param>
        private void ExportFormDxl(IMigrateTask task, IDxlReader dxlReader, string baseDir)
        {
            string formDir = System.IO.Path.Combine(baseDir, "form");
            if (!System.IO.Directory.Exists(formDir))
            {
                System.IO.Directory.CreateDirectory(formDir);
            }
            foreach (IForm form in task.TargetForms)
            {
                string fileName = CheckFileName(form.DisplayName) ? form.DisplayName : "form" + form.FormNo;
                string dxlFileName = System.IO.Path.Combine(formDir, fileName + ".dxl");
                string formDxl = dxlReader.GetFormDxl(form.Name);
                System.IO.File.WriteAllText(dxlFileName, formDxl, System.Text.Encoding.UTF8);
                Reporter.ReportStep(RS.Informations.FormDesignExporting, true, form.DisplayName);
                TransferFormDxl(task,form, dxlFileName);
                Reporter.ReportStep(RS.Informations.FormDesignConverting, true, form.DisplayName);
            }
        }
        /// <summary>
        /// ファイル名に禁則文字があるかどうかをチェックする
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool CheckFileName(string fileName)
        {
            foreach (char chr in Path.GetInvalidFileNameChars())
            {
                if (fileName.Contains(chr))
                {
                    return false;
                }
            }
            return true;
        }

        private string FilterInvalidChars(string fileName)
        {
            foreach (char chr in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(Convert.ToString( chr), "");
            }
            return fileName;
        }

        private void TransferFormDxl(IMigrateTask task,IForm form, string dxlFileName)
        {
            string folder = task.GetResourceFilePath(ResourceType.StyleSheet);
            string cssName = "form" + form.FormNo + ".css";
            string cssfile = Path.Combine(folder, cssName);
            DxlTransfer transfer = new DxlTransfer();
            transfer.TransfromToCss(dxlFileName, cssfile);
            form.FormLayout = transfer.TransfromToAspx(dxlFileName, cssName, "");
        }

 
        /// <summary>
        /// アイコンを出力する
        /// </summary>
        /// <param name="nsAccessor"></param>
        /// <param name="task"></param>
        /// <param name="databaseDir"></param>
        private void ExportDBIcon(NotesAccessor nsAccessor, IMigrateTask task, string databaseDir)
        {
            Image rawIcon = nsAccessor.ExportIcon(task.CurrentDb);
            Image smallIcon = nsAccessor.GetSmallIcon(rawIcon);
            Image LargeIcon = nsAccessor.GetLargeNotesIcon(rawIcon, task.NotesDbTitle);
            //元アイコン
            string iconFile = System.IO.Path.Combine(databaseDir, RSM.GetMessage(RS.StringTable.DBIconName));
            rawIcon.Save(iconFile, ImageFormat.Png);
            //Smallアイコン
            iconFile = System.IO.Path.Combine(databaseDir, RSM.GetMessage(RS.StringTable.DBSmallIconName));
            smallIcon.Save(iconFile, ImageFormat.Png);
            //大きいアイコン
            iconFile = System.IO.Path.Combine(databaseDir, RSM.GetMessage(RS.StringTable.DBLargeIconName));
            LargeIcon.Save(iconFile, ImageFormat.Png);
        }

        private NotesAccessor GetNotesAccessor()
        {
            if (this._notesAccessor == null)
            {
                this._notesAccessor = Accessor.AccessorFactory.GetNotesAccessor();
                this._notesAccessor.TryConnect(Config.NotesPassword);
            }
            return this._notesAccessor;
        }

    }
}
