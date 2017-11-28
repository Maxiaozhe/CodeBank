using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJ.Tools.NotesTransfer.UI.Component;
using RJ.Tools.NotesTransfer.UI.Component.Desgin;
using System.Drawing.Design;
namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class FormBase : Form,IControlStyle
    {
        public FormBase()
        {
            InitializeComponent();
        }
        [Editor(typeof(FormStyleEditor), typeof(UITypeEditor))]
        public string StyleName{get;set;}

        public string CategoryName{get;set;}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyStyles(this);
        }

        public void ApplyStyles(Control parent)
        {
            if (parent is IControlStyle)
            {
                ControlStyleHelper.SetStyle((IControlStyle)parent);
            }
            if (parent.Controls.Count > 0)
            {
                foreach (Control ctrl in parent.Controls)
                {
                    ApplyStyles(ctrl);
                }
            }
        }

    }
}
