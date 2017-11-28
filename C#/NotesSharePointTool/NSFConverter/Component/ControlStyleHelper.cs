using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RJ.Tools.NotesTransfer.UI.Component
{
    public class ControlStyleHelper
    {
        private static XmlDocument xdom = null;
        private static object domLocker = new object();
        public ControlStyleHelper()
        {
            ReadFormStyleXml();
        }

        private static void ReadFormStyleXml()
        {
            if (xdom != null) return;
            lock (domLocker)
            {
                string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "FormStyle.xml");
                if (System.IO.File.Exists(path))
                {
                    using (XmlReader reader = XmlReader.Create(path))
                    {
                        xdom = new System.Xml.XmlDocument();
                        xdom.Load(reader);
                    }
                }
                else
                {
                    xdom = new System.Xml.XmlDocument();
                    xdom.LoadXml(Properties.Resources.FormStyle);
                }
            }
        }
        /// <summary>
        /// スタイル名前リストを取得する
        /// </summary>
        /// <returns></returns>
        public static string[] GetStyleNames()
        {
            ReadFormStyleXml();
            string xpath = @"//style/@name";
            XmlNodeList nodes = xdom.SelectNodes(xpath);
            List<string> styleNames = new List<string>();
            foreach (XmlNode node in nodes)
            {
                styleNames.Add(node.Value);
            }
            return styleNames.ToArray();

        }

        public static void SetStyle(IControlStyle style)
        {
            try
            {
                if (!(style is Control)) return;
                Control control = (Control)style;
                if (string.IsNullOrEmpty(style.StyleName)) return;
                ReadFormStyleXml();
                string xpath = "";
                if (!string.IsNullOrEmpty(style.CategoryName))
                {
                    xpath = string.Format(@"//style[@name='{0}' and @category='{1}']", style.StyleName, style.CategoryName);
                }
                else
                {
                    xpath = string.Format(@"//style[@name='{0}']", style.StyleName);
                }
                XmlNode node = xdom.SelectSingleNode(xpath);
                if (node == null) return;
                //Normal
                XmlNode styleNode = node.SelectSingleNode("./normal");
                if (styleNode != null)
                {
                    StyleInfo normalStyle = GetStyle(styleNode, control);
                    SetNormalStyle(normalStyle, control);
                }
                //Hover
                styleNode = node.SelectSingleNode("./hover");
                if (styleNode != null)
                {
                    StyleInfo activeStyle = GetStyle(styleNode, control);
                    SetHoverStyle(activeStyle, control);
                }
                //Focus
                styleNode = node.SelectSingleNode("./focus");
                if (styleNode != null)
                {
                    StyleInfo activeStyle = GetStyle(styleNode, control);
                    SetFocusStyle(activeStyle, control);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private static void SetNormalStyle(StyleInfo info, Control control)
        {
            SetStyle(info, control);
        }
        private static void SetHoverStyle(StyleInfo hoverStyle, Control control)
        {
            StyleInfo beforeStyle = GetBeforeStyle(control);
            control.MouseHover += (sender, e) =>
            {
                SetStyle(hoverStyle, control);
            };
            control.MouseLeave += (sender, e) =>
            {
                SetStyle(beforeStyle, control);
            };
        }

        private static void SetFocusStyle(StyleInfo hoverStyle, Control control)
        {
            StyleInfo beforeStyle = GetBeforeStyle(control);
            control.GotFocus += (sender, e) =>
            {
                SetStyle(hoverStyle, control);
            };
            control.LostFocus += (sender, e) =>
            {
                SetStyle(beforeStyle, control);
            };
        }

        private static void SetStyle(StyleInfo style, Control control) 
        {
            if (style.Font != null) { control.Font = style.Font; }
            if (style.ForeColor.HasValue) { control.ForeColor = style.ForeColor.Value; }
            if (style.BackColor.HasValue) { control.BackColor = style.BackColor.Value; }
            if (style.HasBackImage) { control.BackgroundImage = style.BackImage; }
            if (style.Widht.HasValue || style.Height.HasValue)
            {
                if (control is Label)
                {
                    ((Label)control).AutoSize = false;
                }
            }
            if (style.Widht.HasValue) { control.Width = style.Widht.Value; }
            if (style.Height.HasValue) { control.Height = style.Height.Value; }
            if (style.TextAlign.HasValue)
            {
                PropertyInfo prop = control.GetType().GetProperty("TextAlign", typeof(ContentAlignment));
                if (prop != null)
                {
                    prop.SetValue(control, style.TextAlign.Value);
                }
            }
            if (style.HasImage)
            {
                PropertyInfo prop = control.GetType().GetProperty("Image", typeof(Image));
                if (prop != null)
                {
                    prop.SetValue(control, style.Image);
                }
            }
            if (style.ImageAlign.HasValue)
            {
                PropertyInfo prop = control.GetType().GetProperty("ImageAlign", typeof(ContentAlignment));
                if (prop != null)
                {
                    prop.SetValue(control, style.ImageAlign.Value);
                }
            }
          
        }

        private static StyleInfo GetBeforeStyle(Control control)
        {
            StyleInfo style = new StyleInfo();
            style.ForeColor = control.ForeColor;
            style.BackColor = control.BackColor;
            style.Font = control.Font;
            style.BackImage = control.BackgroundImage;
            PropertyInfo prop = control.GetType().GetProperty("TextAlign", typeof(ContentAlignment));
            if (prop != null)
            {
                style.TextAlign = (ContentAlignment)prop.GetValue(control);
            }
            prop = control.GetType().GetProperty("Image", typeof(Image));
            if (prop != null)
            {
                style.Image = (Image)prop.GetValue(control);
            }
            prop = control.GetType().GetProperty("ImageAlign", typeof(ContentAlignment));
            if (prop != null)
            {
                style.ImageAlign = (ContentAlignment)prop.GetValue(control);
            }
            return style;
        }

        private static StyleInfo GetStyle(XmlNode styleNode, Control control)
        {
            XmlNode node=null;
            StyleInfo style = new StyleInfo();
            //width
            node = styleNode.SelectSingleNode("./width");
            int width=0;
            if (node != null && int.TryParse(node.InnerText, out width))
            {
                style.Widht = width;
            }
            //height
            int height = 0;
            node = styleNode.SelectSingleNode("./height");
            if (node != null && int.TryParse(node.InnerText, out height))
            {
                style.Height = height;
            }
            //font-size
            Font font = null;
            node = styleNode.SelectSingleNode("./font-size");
            float size = 0.0F;
            if (node != null && float.TryParse(node.InnerText, out size))
            {
                font = new Font(control.Font.FontFamily, size);
            }
            node = styleNode.SelectSingleNode("./font-name");
            //font-name
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                font = (font==null) ? control.Font:font;
                font = new Font(font.FontFamily, font.Size, font.Style);
            }
            //font-style
            node = styleNode.SelectSingleNode("./font-style");
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                font = (font == null) ? control.Font : font;
                FontStyle fstyle = font.Style;
                switch (node.InnerText)
                {
                    case "Bold":
                        fstyle = fstyle | FontStyle.Bold;
                        break;
                    case "Italic":
                        fstyle = fstyle | FontStyle.Italic;
                        break;
                    case "Underline":
                        fstyle = fstyle | FontStyle.Underline;
                        break;
                    default:
                        break;
                }
                font = new Font(font, fstyle);
            }
            if (font != null)
            {
                style.Font = font;
            }
            //forecolor
            node = styleNode.SelectSingleNode("./forecolor");
            Color? foreColor=null;
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                try {
                    foreColor = ColorTranslator.FromHtml(node.InnerText);
                    style.ForeColor = foreColor;
                }
                finally
                {

                }
            }
            //backcolor
            node = styleNode.SelectSingleNode("./backcolor");
            Color? backColor = null;
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                try
                {
                    backColor = ColorTranslator.FromHtml(node.InnerText);
                    style.BackColor = backColor;
                }
                finally
                {

                }
            }
            //backImage
            node = styleNode.SelectSingleNode("./backimage");
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                try
                {
                    Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(node.InnerText);
                    style.BackImage = bmp;
                }
                finally { }
            }
            //TextAlign
            node = styleNode.SelectSingleNode("./textalign");
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                style.TextAlign = ParseAlignment(node.InnerText);
            }
            //image
            node = styleNode.SelectSingleNode("./image");
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                try
                {
                    Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(node.InnerText);
                    style.Image = bmp;
                }
                finally { }
            }
            //imagealign
            node = styleNode.SelectSingleNode("./imagealign");
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                style.ImageAlign = ParseAlignment(node.InnerText);
            }
            return style;
        }

        private static ContentAlignment? ParseAlignment(string align)
        {
            ContentAlignment? alignType = null;
            switch (align)
            {
                case "MiddleCenter":
                    alignType= ContentAlignment.MiddleCenter;
                    break;
                case "MiddleLeft":
                    alignType = ContentAlignment.MiddleLeft;
                    break;
                case "MiddleRight":
                    alignType = ContentAlignment.MiddleRight;
                    break;
                case "BottomCenter":
                    alignType = ContentAlignment.BottomCenter;
                    break;
                case "BottomLeft":
                    alignType = ContentAlignment.BottomLeft;
                    break;
                case "BottomRight":
                    alignType = ContentAlignment.BottomRight;
                    break;
                case "TopCenter":
                    alignType = ContentAlignment.TopCenter;
                    break;
                case "TopLeft":
                    alignType = ContentAlignment.TopLeft;
                    break;
                case "TopRight":
                    alignType = ContentAlignment.TopRight;
                    break;
                default:
                    break;
            }
            return alignType;
        }
    }

    public class StyleInfo
    {
        private Image _image=null;
        private bool _hasImage=false;
        private Image _backImage = null;
        private bool _hasBackImage = false;

        public int? Widht { get; set; }
        public int? Height { get; set; }
        public Font Font { get; set; }
        public Image BackImage
        {
            get
            {
                return this._backImage;
            }
            set
            {
                this._backImage = value;
                this._hasBackImage = true;
            }
        }
        public Color? ForeColor { get; set; }
        public Color? BackColor { get; set; }
        public ContentAlignment? TextAlign { get; set; }
        public Image Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this._image = value;
                this._hasImage = true;
            }
        }
        public ContentAlignment? ImageAlign { get; set;}
        public bool HasImage
        {
            get
            {
                return this._hasImage;
            }
        }

        public bool HasBackImage
        {
            get
            {
                return this._hasBackImage;
            }
        }

    }

    public interface IControlStyle
    {
        string StyleName { get; set; }
        string CategoryName { get; set; }
    }
}
