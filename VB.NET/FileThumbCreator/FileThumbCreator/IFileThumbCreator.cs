using System;
using System.Collections.Generic;
using System.Text;

namespace FileThumbCreator
{
    public interface IFileThumbCreator
    {
        String FileName{get;set;}
        System.Drawing.Bitmap GetThumbnail();
    }

    public class FileThumbController
    {

        public static IFileThumbCreator GetCreator(string file)
        {
            IFileThumbCreator creator = null;
            string Ext = System.IO.Path.GetExtension(file);
            switch (Ext.ToLower())
            {
                case ".dwg":
                    creator = new dwgThumbCreator(file);
                    break;
                default:
                    creator = new ThumbnailExtractor(file);
                    break;
            }

            return creator;

        }

    }
}
