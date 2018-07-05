using System.Data;
namespace TableDesignInfo.Entity {
    
    
    public partial class TemplateInfo {

        public static DocumentTemplateRow LoadTemplateRow(string templateFilePath)
        {
            string templateFileName = System.IO.Path.GetFileName(templateFilePath);
            string basePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string xmlfile = System.IO.Path.Combine(basePath, @"Template\TemplateInfo.xml");

            TemplateInfo info = new TemplateInfo();
            info.ReadXml(xmlfile);
            DataRow[] rows = info.DocumentTemplate.Select("TemplateFileName='" + templateFileName + "'");
            if (rows != null && rows.Length > 0)
            {
                return (DocumentTemplateRow)rows[0];
            }
            return null;
        }

        public static TemplateInfo.DocumentTemplateDataTable LoadTemplate()
        {
            string basePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string xmlfile = System.IO.Path.Combine(basePath, @"Template\TemplateInfo.xml");

            TemplateInfo info = new TemplateInfo();
            info.ReadXml(xmlfile);
            return info.DocumentTemplate;
        }
    }
}
