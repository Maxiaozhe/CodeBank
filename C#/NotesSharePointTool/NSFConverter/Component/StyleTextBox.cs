using RJ.Tools.NotesTransfer.UI.Component.Desgin;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace RJ.Tools.NotesTransfer.UI.Component
{
    public class StyleTextBox: TextBox,IControlStyle
    {
        [Editor(typeof(FormStyleEditor), typeof(UITypeEditor))]
        public string StyleName
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }
    }
}
