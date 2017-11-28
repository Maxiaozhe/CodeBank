using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using RJ.Tools.NotesTransfer.UI.Component.Desgin;

namespace RJ.Tools.NotesTransfer.UI.Component
{
    public class StylePanel:Panel,IControlStyle
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
