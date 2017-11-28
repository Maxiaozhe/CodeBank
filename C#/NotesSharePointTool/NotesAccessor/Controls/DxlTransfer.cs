using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace RJ.Tools.NotesTransfer.Engines.Notes.Controls
{
    public class DxlTransfer
    {

        public bool TransformDxl(string dxlPath, XslCompiledTransform xslt, string outputPath, XsltArgumentList args)
        {
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.DtdProcessing = DtdProcessing.Ignore;
            readerSettings.ValidationType = ValidationType.None;
            readerSettings.ConformanceLevel = ConformanceLevel.Fragment;
            XmlWriterSettings writeSetting = new XmlWriterSettings();
            writeSetting.Indent = true;
            writeSetting.OmitXmlDeclaration = false;
            writeSetting.ConformanceLevel = ConformanceLevel.Fragment;


            using (XmlReader inStream = XmlReader.Create(dxlPath, readerSettings))
            {
                using (XmlWriter writer = XmlWriter.Create(outputPath, writeSetting))
                {
                    if (args != null)
                    {
                        xslt.Transform(inStream, args, writer);
                    }
                    else
                    {
                        xslt.Transform(inStream, writer);
                    }
                }
            }
            return true;
        }

        public string TransfromToAspx(string dxlPath, string cssUri, string xsltPath)
        {
            //XslTransferのインスタンスを生成する
            if (string.IsNullOrEmpty(xsltPath) || !System.IO.File.Exists(xsltPath))
            {
                string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
                xsltPath = System.IO.Path.Combine(basePath, @"xslt\form.xsl");
            }
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltPath);
            string outputFile = System.IO.Path.ChangeExtension(dxlPath, ".html");
            //cssfile引数を追加
            XsltArgumentList arguments = new XsltArgumentList();
            arguments.AddParam("cssfile", "", cssUri);
            TransformDxl(dxlPath, xslt, outputFile, arguments);
            string result = string.Empty;
            using (StreamReader reader = new StreamReader(new FileStream(outputFile, FileMode.Open)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public void TransfromToCss(string dxlPath, string cssFileName)
        {
            //XslTransferのインスタンスを生成する
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string xsltPath = System.IO.Path.Combine(basePath, @"xslt\css.xsl");
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltPath);
            //引数なし
            TransformDxl(dxlPath, xslt, cssFileName,null);
        }

        private string GetCssForDesigen(string dxlData)
        {
            byte[] dxldata = System.Text.Encoding.UTF8.GetBytes(dxlData); 
            //Css
            MemoryStream dxlStream = new MemoryStream(dxldata);
            MemoryStream cssStream = new MemoryStream();
            //XslTransferのインスタンスを生成する
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string xsltPath = System.IO.Path.Combine(basePath, @"xslt\css.xsl");
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltPath);
            TransformDxl(dxlStream, xslt, cssStream,null);
            string result = "";
            cssStream.Position = 0;
            using (System.IO.StreamReader reader = new StreamReader(cssStream))
            {
               result = reader.ReadToEnd();
            }
            dxlStream.Close();
            cssStream.Close();
            return result;
        }

        private string GetHtmlForDesigen(string dxlData)
        {
            byte[] dxldata = System.Text.Encoding.UTF8.GetBytes(dxlData);
            //Css
            MemoryStream dxlStream = new MemoryStream(dxldata);
            MemoryStream htmlStream = new MemoryStream();
            //XslTransferのインスタンスを生成する
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string xsltPath = System.IO.Path.Combine(basePath, @"xslt\form.xsl");
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltPath);
            TransformDxl(dxlStream, xslt, htmlStream, null);
            string result = "";
            htmlStream.Position = 0;
            using (System.IO.StreamReader reader = new StreamReader(htmlStream))
            {
                result = reader.ReadToEnd();
            }
            dxlStream.Close();
            htmlStream.Close();
            return result;
        }

        public string GetFormHtml(string dxlData,string formName)
        {
            StringBuilder sb = new StringBuilder();
           // sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine(@"    <meta charset=""utf-8"" />");
            sb.AppendLine("    <title>" + formName + "</title>");
            sb.AppendLine(" <style>");
            sb.AppendLine(GetCssForDesigen(dxlData));
            sb.AppendLine(" </style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine(GetHtmlForDesigen(dxlData));
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
            return sb.ToString();
        }

        public bool TransformDxl(Stream dxlStream, XslCompiledTransform xslt, Stream outputStream, XsltArgumentList args)
        {
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.DtdProcessing = DtdProcessing.Ignore;
            readerSettings.ValidationType = ValidationType.None;
            readerSettings.ConformanceLevel = ConformanceLevel.Fragment;
            XmlWriterSettings writeSetting = new XmlWriterSettings();
            writeSetting.Indent = true;
            writeSetting.OmitXmlDeclaration = false;
            writeSetting.ConformanceLevel = ConformanceLevel.Fragment;


            using (XmlReader inStream = XmlReader.Create(dxlStream, readerSettings))
            {
                using (XmlWriter writer = XmlWriter.Create(outputStream, writeSetting))
                {
                    if (args != null)
                    {
                        xslt.Transform(inStream, args, writer);
                    }
                    else
                    {
                        xslt.Transform(inStream, writer);
                    }
                }
            }
            return true;
        }
    }
}
