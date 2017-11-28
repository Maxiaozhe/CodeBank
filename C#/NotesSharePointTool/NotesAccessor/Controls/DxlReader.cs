using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RJ.Tools.NotesTransfer.Engines.Notes.Schema;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Notes.Entity;
using System.Text.RegularExpressions;

namespace RJ.Tools.NotesTransfer.Engines.Notes.Controls
{
    public class DxlReader : IDxlReader
    {
        #region Field
        private XmlDocument xmlDoc = null;
        private XmlNamespaceManager xm = null;
        #endregion

        public DxlReader(string xml)
        {
            this.xmlDoc = new XmlDocument();
            this.xmlDoc.LoadXml(xml);
            this.xm = new XmlNamespaceManager(this.xmlDoc.NameTable);
            xm.AddNamespace("x", XPATHS.DXL_NAMESPACE);
        }
        /// <summary>
        /// アイコン情報を取得する
        /// </summary>
        /// <returns></returns>
        public Byte[] GetRawIconData()
        {
            XmlNode node = xmlDoc.SelectSingleNode(XPATHS.XPATH_DBICON, xm);
            if (node == null)
            {
                return null;
            }
            string buffer = node.Value;
            buffer = System.Text.RegularExpressions.Regex.Replace(buffer, @"\n", "");
            byte[] iconData = Convert.FromBase64String(buffer);
            return iconData;
        }
        /// <summary>
        /// 列情報を取得する
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public List<IField> GetFields(string formName)
        {
            List<IField> fields = new List<IField>();
            string xpath = string.Format(XPATHS.XPATH_FORM_FIELDS, formName);
            XmlNodeList nodes = xmlDoc.SelectNodes(xpath, xm);
            foreach (XmlNode node in nodes)
            {
                Field field = new Field(node, xm);
                fields.Add(field);
            }
            return fields;
        }

        /// <summary>
        /// 列情報を取得する
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public List<string> GetSharedFieldRef(string formName)
        {
            List<string> fieldrefs = new List<string>();
            string xpath = string.Format(XPATHS.XPATH_SHARED_FIELDREF, formName);
            XmlNodeList nodes = xmlDoc.SelectNodes(xpath, xm);
            foreach (XmlNode node in nodes)
            {
                string fieldName = GetAttribute(node, "name");
                fieldrefs.Add(fieldName);
            }
            return fieldrefs;
        }


        /// <summary>
        /// 列情報を取得する
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public List<IField> GetSharedFields()
        {
            List<IField> fields = new List<IField>();
            string xpath = string.Format(XPATHS.XPATH_SHARED_FIELDS);
            XmlNodeList nodes = xmlDoc.SelectNodes(xpath, xm);
            foreach (XmlNode node in nodes)
            {
                Field field = new Field(node, xm);
                fields.Add(field);
            }
            return fields;
        }

        /// <summary>
        /// デフォールトフォーム名を取得する
        /// </summary>
        /// <returns></returns>
        public string GetDefaultForm()
        {
            XmlNode defaultNode = xmlDoc.SelectSingleNode(XPATHS.XPATH_DEFAULT_FORM, xm);
            if (defaultNode == null)
            {
                return string.Empty;
            }
            string name = GetAttribute(defaultNode, "name");
            return name;
        }

        public string GetFormDxl(string formName)
        {
            string xpath = string.Format(XPATHS.XPATH_SUBFORMREF, formName);
            XmlNodeList subformRefs = xmlDoc.SelectNodes(xpath, xm);
            int maxPardefId = GetMaxPardefId(formName);

            foreach (XmlNode subref in subformRefs)
            {
                string subName = GetAttribute(subref, "name");
                if (string.IsNullOrEmpty(subName))
                {
                    continue;
                }
                int pos = subName.IndexOf("|");
                if (pos > 0)
                {
                    subName = subName.Substring(0, pos).Trim();
                }
                string subformPath = string.Format(XPATHS.XPATH_SUBFORM, subName);
                XmlElement subformSrc = (XmlElement)xmlDoc.SelectSingleNode(subformPath, xm);
                if (subformSrc == null)
                {
                    continue;
                }
                XmlElement subform = (XmlElement)subformSrc.Clone();
                Dictionary<string, string> idmap = new Dictionary<string, string>();
                XmlNodeList pardefs = subform.GetElementsByTagName("pardef");
                for (int i = 0; i < pardefs.Count; i++)
                {
                    string newId = (i + maxPardefId + 1).ToString();
                    string oldid = this.GetAttribute(pardefs[i], "id");
                    idmap.Add(oldid, newId);
                    pardefs[i].Attributes["id"].Value = newId;
                }
                XmlNodeList pars = subform.GetElementsByTagName("par");
                foreach (XmlNode par in pars)
                {
                    string oldId = GetAttribute(par, "def");
                    if (idmap.ContainsKey(oldId))
                    {
                        string newid = idmap[oldId];
                        par.Attributes["def"].Value = newid;
                    }
                }
                XmlNodeList sectiontitleList = subform.GetElementsByTagName("sectiontitle");
                foreach (XmlNode sectiontitle in sectiontitleList)
                {
                    string oldId = GetAttribute(sectiontitle, "pardef");
                    if (idmap.ContainsKey(oldId))
                    {
                        string newid = idmap[oldId];
                        sectiontitle.Attributes["pardef"].Value = newid;
                    }
                }
                maxPardefId += pardefs.Count;
                subref.ParentNode.ReplaceChild(subform, subref);
            }
            //for (int i = subformRefs.Count - 1; i >= 0; i--)
            //{
            //    XmlNode parent = subformRefs[i].ParentNode;
            //    parent.RemoveChild(subformRefs[i]);
            //}
            xpath = string.Format(XPATHS.XPATH_FORM, formName);
            XmlNode formNode = xmlDoc.SelectSingleNode(xpath, xm);
            return formNode.OuterXml;
        }

        private int GetMaxPardefId(string formName)
        {
            string xpath = string.Format(XPATHS.XPATH_PARDEF_ID, formName);
            XmlNodeList pardefIds = xmlDoc.SelectNodes(xpath, xm);
            if (pardefIds == null || pardefIds.Count == 0)
            {
                return 0;
            }
            int maxId = pardefIds.Cast<XmlNode>().Max(node =>
            {
                int id = 0;
                if (int.TryParse(node.Value, out id))
                {
                    return id;
                }
                return 0;
            });
            if (maxId == 0) maxId = 1;
            return maxId;
        }

        /// <summary>
        /// 属性の値を取得する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attrName"></param>
        /// <returns></returns>
        private string GetAttribute(XmlNode node, string attrName)
        {
            var attr = node.Attributes[attrName];
            if (attr == null)
            {
                return string.Empty;
            }
            return attr.Value;
        }
        /// <summary>
        /// 整数の値を取得する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attrName"></param>
        /// <returns></returns>
        private int? GetInteger(XmlNode node, string attrName)
        {
            string attr = GetAttribute(node, attrName);
            int value = 0;
            if (int.TryParse(attr, out value))
            {
                return value;
            }
            return null;
        }
        /// <summary>
        /// ブールの値を取得
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attrName"></param>
        /// <returns></returns>
        private bool GetBoolean(XmlNode node, string attrName)
        {
            string attr = GetAttribute(node, attrName);
            bool value = false;
            if (bool.TryParse(attr, out value))
            {
                return value;
            }
            return false;
        }

        /// <summary>
        /// イメージリソースを
        /// </summary>
        public void SaveImageResources(string folder,bool referedOnly)
        {
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }
            //参照されたイメージのみを出力する
            ResetImageRef(folder);

            //添付ファイル参照を出力する
            ResetAttachmentRef(folder);

            //参照されたイメージのみを出力する場合処理完了
            if (referedOnly) return;

            //参照されないイメージも出力する
            XmlNodeList imageResours = xmlDoc.SelectNodes(XPATHS.XPATH_IMG_RESOURCE, xm);
            List<XmlNode> removeNodes = new List<XmlNode>();
            foreach (XmlNode imgNode in imageResours)
            {
                string imageType = imgNode.LocalName;
                XmlNode parentNode = imgNode.ParentNode;
                //名前を取得する
                string fileName = GetImageName(imageType, parentNode);
                //ファイルを保存する
                SaveImageFile(folder, imgNode, fileName);

                //この場合imagerefへ変更
                if (parentNode.LocalName.Equals("picture"))
                {
                    XmlElement imageref = this.xmlDoc.CreateElement("imageref", imgNode.NamespaceURI);
                    imageref.SetAttribute("name", fileName);
                    parentNode.AppendChild(imageref);
                    removeNodes.Add(imgNode);
                }
            }
            //Inlineイメージを削除する
            for (int i = removeNodes.Count - 1; i >= 0; i--)
            {
                XmlNode parent = removeNodes[i].ParentNode;
                parent.RemoveChild(removeNodes[i]);
            }
        }

        /// <summary>
        /// 添付ファイル参照をリセットする
        /// </summary>
        /// <param name="folder"></param>
        public void ResetAttachmentRef(string folder)
        {
            XmlNodeList attachRefs = xmlDoc.SelectNodes(XPATHS.XPATH_ATTACHMENTREF, xm);
            foreach (XmlNode fileRef in attachRefs)
            {
                string name = this.GetAttribute(fileRef, "name");
                string path = string.Format(XPATHS.XPATH_ATTACHMENTREF_SEARCH, name);
                XmlNode fileRes = xmlDoc.SelectSingleNode(path, xm);
                if (fileRes == null)
                {
                    continue;
                }
                //ファイル名前
                XmlNode fileDataNode = fileRes.SelectSingleNode(XPATHS.XPATH_FILEDATA_NODE, xm);
                if (fileDataNode == null)
                {
                    continue;
                }
                //ファイルを保存する
                string fileName = GetAttribute(fileRes, "name");
                fileName = System.IO.Path.Combine(folder, fileName);
                SaveAttachmentFile(fileName, fileDataNode);
                //ファイルタグを削除する
                XmlNode parent = fileRes.ParentNode;
                parent.RemoveChild(fileRes);
            }
        }

        /// <summary>
        /// イメージ参照を変更する
        /// </summary>
        public void ResetImageRef(string folder)
        {
            XmlNodeList imageRefs = xmlDoc.SelectNodes(XPATHS.XPATH_IMAGEREF, xm);
            foreach (XmlNode imgRef in imageRefs)
            {
                string name = this.GetAttribute(imgRef, "name");
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }
                string path =string.Format(XPATHS.XPATH_IMAGEREF_SEARCH,name);
                XmlNode imgRes = xmlDoc.SelectSingleNode(path, xm);
                if (imgRes == null)
                {
                    continue;
                }
                XmlNode imgNode = imgRes.SelectSingleNode(XPATHS.XPATH_IMG_NODE, xm);
                if (imgNode == null)
                {
                    continue;
                }
                string imageType = imgNode.LocalName;
                //名前を取得する
                string fileName = GetImageName(imageType, imgRes);
                //ファイルを保存する
                SaveImageFile(folder, imgNode, fileName);
                imgRef.Attributes["name"].Value = fileName;
                XmlNode parent = imgRes.ParentNode;
                parent.RemoveChild(imgRes);
            }
        }

        /// <summary>
        /// イメージファイルを保存する
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="imgNode"></param>
        /// <param name="fileName"></param>
        private static void SaveImageFile(string folder, XmlNode imgNode, string fileName)
        {
            string imageSource = imgNode.InnerText;
            imageSource = Regex.Replace(imageSource, @"\n", "");
            byte[] imgData = Convert.FromBase64String(imageSource);
            string filePath = System.IO.Path.Combine(folder, fileName);
            System.IO.File.WriteAllBytes(filePath, imgData);
        }

        /// <summary>
        /// 添付ファイルを保存する
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="imgNode"></param>
        /// <param name="fileName"></param>
        private static void SaveAttachmentFile(string filePath, XmlNode fileDataNode)
        {
            string fileSource = fileDataNode.InnerText;
            fileSource = Regex.Replace(fileSource, @"\n", "");
            byte[] fileData = Convert.FromBase64String(fileSource);
            System.IO.File.WriteAllBytes(filePath, fileData);
        }

        /// <summary>
        /// イメージファイル名を取得する
        /// </summary>
        /// <param name="imageType"></param>
        /// <param name="parentNode"></param>
        private string GetImageName(string imageType, XmlNode parentNode)
        {
            //名前
            string name = this.GetAttribute(parentNode, "name");
            //別名
            string alias = this.GetAttribute(parentNode, "alias");
            //name属性ない時、imagename属性を使用する
            string imagename = this.GetAttribute(parentNode, "imagename");
            string aliaName = string.Empty;
            //複数別名使用
            if (alias.Contains("|"))
            {
                string[] aliaNames = alias.Split("|".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                if (aliaNames.Length > 0)
                {
                    aliaName = aliaNames[0].ToLower().Trim();
                    if (!aliaName.EndsWith("." + imageType))
                    {
                        aliaName = aliaName + "." + imageType;
                    }
                }
            }
            //name -> alias -> imagenameの順でイメージ名を決める
            string fileName = (!string.IsNullOrEmpty(name)) ? name :
                                (!string.IsNullOrEmpty(aliaName) ? aliaName : imagename);
            //無名の場合、GUID名を付ける
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Guid.NewGuid().ToString("D") + "." + imageType;
            }
            if (!fileName.ToLower().EndsWith("." + imageType))
            {
                fileName = fileName + "." + imageType;
            }
            return fileName;
        }
    }
}
