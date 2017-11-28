using System;
using System.Collections.Generic;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Notes.Entity;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;

namespace RJ.Tools.NotesTransfer.Engines.Notes.Controls
{
    public class NotesAccessor
    {
        #region Enum
        public enum ExportMode
        {
            Forms,
            Icon,
            Views,
            Resources,
            All
        }

        #endregion
        #region Field
        private Domino.NotesSession _session;
        private bool _isInitialized = false;
        #endregion

        #region Contructor
        /// <summary>
        /// インスタンス生成する
        /// </summary>
        /// <returns></returns>
        public static NotesAccessor CreateInstance()
        {
            NotesAccessor accessor = new NotesAccessor();
            return accessor;
        }
        #endregion

        /// <summary>
        /// Notes Sessionを初期化されたかどうか
        /// </summary>
        public bool IsInitialized
        {
            get { return this._isInitialized; }
        }

        private NotesAccessor()
        {
        }

        private void EnsureSession()
        {
            if (!this.IsInitialized)
            {
                throw RSM.GetException(RS.Exceptions.SessionNotInitialized);
            }
        }

        public string GetEnvironmentString(string pName)
        {
            EnsureSession();
            return this._session.GetEnvironmentString(pName);
        }

        public string GetCurrentUser()
        {
            EnsureSession();
            string userFullId = this._session.UserName;
            if (string.IsNullOrEmpty(userFullId))
            {
                return string.Empty;
            }
            return this._session.CreateName(userFullId).Abbreviated;
        }

        /// <summary>
        /// ノーツへ接続する
        /// （接続できない場合、Falseを返す）
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool TryConnect(string password)
        {
            try
            {
                this._session = new Domino.NotesSession();
                this._session.Initialize(password);
                this._isInitialized = true;
                return true;
            }
            catch
            {
                this._isInitialized = false;
                return false;
            }
        }



        public IDatabase GetDataBase(string fileName, string server)
        {
            EnsureSession();
            Domino.NotesDatabase ndb = this._session.GetDatabase(server, fileName, false);
            if (ndb == null) return null;
            return new Database(this, ndb);
        }

        internal List<IForm> GetForms(IDatabase db)
        {
            string defaultForm = db.DxlReader.GetDefaultForm();
            List<IForm> forms = new List<IForm>();
            Domino.NotesDatabase ndb = db.InnerObject as  Domino.NotesDatabase;
            object[] notesForms = (object[])ndb.Forms;
            int formNo = 0;
            foreach (Domino.NotesForm nsform in notesForms)
            {
                if (nsform.IsSubForm)
                {
                    continue;
                }
                formNo++;
                Form form = new Form(formNo,nsform, db);
                if (form.Name.Equals(defaultForm))
                {
                    form.IsDefault = true;
                    form.IsTarget = true;
                }
                forms.Add(form);
            }
            forms.Sort(CompaireForm);
            return forms;
        }

        private int CompaireForm(IForm x, IForm y)
        {
            if (x == null || y == null) return -1;
            string xName = string.IsNullOrEmpty(x.Name) ? "" : x.Name;
            return xName.CompareTo(y.Name);
        }

        private int CompaireView(IView x, IView y)
        {
            if (x == null || y == null) return -1;
            string xName = string.IsNullOrEmpty(x.Name) ? "" : x.Name;
            return xName.CompareTo(y.Name);
        }

        internal List<IView> GetViews(IDatabase db)
        {
            Domino.NotesDatabase ndb = db.InnerObject as Domino.NotesDatabase;
            List<IView> views = new List<IView>();
            object[] notesViews = (object[])ndb.Views;
            foreach (Domino.NotesView view in notesViews)
            {
                views.Add(new View(view,db));
            }
            views.Sort(CompaireView);
            return views;
        }
        /// <summary>
        /// DXLへ出力
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public string ExportDxl(IDatabase db,ExportMode mode)
        {
            
            EnsureSession();
            bool isColned = false;
            Domino.NotesDXLExporter exporter = this._session.CreateDXLExporter();
            exporter.ForceNoteFormat = false;
            exporter.OutputDOCTYPE = false;
            exporter.ConvertNotesbitmapsToGIF = true;
            Domino.NotesDatabase ndb = db.InnerObject as Domino.NotesDatabase;
            if (!string.IsNullOrEmpty(ndb.Server))
            {
                //Server中のファイルをコピーする
                ndb = this.CloneDatabase(ndb);
                isColned = true;
            }
            try
            {
                Domino.NotesNoteCollection coll = ndb.CreateNoteCollection(false);
                switch (mode)
                {
                    case ExportMode.Forms:
                        coll.SelectSharedFields = true;
                        coll.SelectForms = true;
                        coll.SelectSubforms = true;
                        break;
                    case ExportMode.Icon:
                        coll.SelectIcon = true;
                        break;
                    case ExportMode.Views:
                        coll.SelectViews = true;
                        break;
                    case ExportMode.Resources:
                        coll.SelectImageResources = true;
                        break;
                    case ExportMode.All:
                        coll.SelectAllDesignElements(true);
                        break;
                    default:
                        break;
                }
                coll.BuildCollection();
                string xml = exporter.Export(coll);
                return xml;

            }
            finally
            {
                if (isColned && ndb != null)
                {
                    try
                    {
                        string tempfile = ndb.FilePath;
                        if (System.IO.File.Exists(tempfile))
                        {
                            System.IO.File.Delete(tempfile);
                        }
                    }
                    catch
                    {
                        //一時ファイル削除できない
                    }
                }
            }
        }

        private Domino.NotesDatabase CloneDatabase(Domino.NotesDatabase srcDb)
        {
            EnsureSession();
            string tempDbPath = System.IO.Path.GetTempFileName();
            string newDbName = System.IO.Path.ChangeExtension(tempDbPath, ".nsf");
            Domino.NotesDatabase dstDB = srcDb.CreateCopy("", newDbName);
            return dstDB;
        }

        public void LoadDxl(string path)
        {
            throw new NotImplementedException();
        }

        public System.Xml.XPath.XPathNavigator GetElement(string xpath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// データベースのアイコンを出力する
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public Image ExportIcon(IDatabase db)
        {
            EnsureSession();
            string xml = "";
            Domino.NotesDXLExporter exporter = this._session.CreateDXLExporter();
            exporter.OutputDOCTYPE = false;
            exporter.ConvertNotesbitmapsToGIF = true;
            Domino.NotesDatabase ndb = db.InnerObject as Domino.NotesDatabase;
            if (!string.IsNullOrEmpty(ndb.Server))
            {
                //Server中のファイルをコピーする
                ndb = this.CloneDatabase(ndb);
            }
            try
            {
                Domino.NotesDocument iconDoc = ndb.GetDocumentByID("FFFF0010");
                xml = exporter.Export(iconDoc);
            }
            catch (Exception)
            {
                Domino.NotesNoteCollection notes = ndb.CreateNoteCollection(false);
                notes.SelectIcon = true;
                notes.BuildCollection();
                xml = exporter.Export(notes);
            }
            byte[] rawData = GetRawIconData(xml);
            IconCreator creator = new IconCreator();
            Image rawIcon = creator.getRawIconImage(rawData);
            return rawIcon;
        }

        public Image GetSmallIcon(Image rawIcon)
        {
            IconCreator creator = new IconCreator();
            return creator.GetSmallIcon(rawIcon);
        }

        public Image GetLargeMonoIcon(Image rawIcon)
        {
            IconCreator creator = new IconCreator();
            return creator.GetLargeMonoIcon(rawIcon);
        }

        public Image GetLargeNotesIcon(Image rawIcon, string title)
        {
            IconCreator creator = new IconCreator();
            return creator.GetLargeIcon(rawIcon, title);
        }


        private Byte[] GetRawIconData(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNamespaceManager xm = new XmlNamespaceManager(xmlDoc.NameTable);
            xm.AddNamespace("x", "http://www.lotus.com/dxl");
            var node = xmlDoc.SelectSingleNode("//x:item[@name='IconBitmap']/x:rawitemdata", xm);
            if (node != null)
            {
                string buffer = node.InnerText;
                buffer = System.Text.RegularExpressions.Regex.Replace(buffer, @"\n", "");
                byte[] iconData = Convert.FromBase64String(buffer);
                return iconData;
            }
            return null;
        }

        /// <summary>
        /// すべて設計要素を出力する
        /// </summary>
        /// <param name="task"></param>
        /// <param name="nsAccessor"></param>
        /// <param name="db"></param>
        /// <param name="databaseDir"></param>
        public DxlReader ExportDatabaseDxl(IDatabase db, string databaseDir)
        {
            string dxlFileName =  db.Title;
            if (string.IsNullOrEmpty(dxlFileName))
            {
                dxlFileName = System.IO.Path.GetFileNameWithoutExtension(db.FileName);
            }
            dxlFileName = System.IO.Path.Combine(databaseDir, dxlFileName + ".dxl");
            string dxlFile = this.ExportDxl(db, NotesAccessor.ExportMode.All);
            //ファイルを保存する
            System.IO.File.WriteAllText(dxlFileName, dxlFile, System.Text.Encoding.UTF8);
            DxlReader dxlreader = new DxlReader(dxlFile);
            return dxlreader;
        }
    }
}
