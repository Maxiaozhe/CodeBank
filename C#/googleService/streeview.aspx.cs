using GoogleService.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleService
{
    public partial class streeview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string location = this.Request.QueryString["location"];
                if (string.IsNullOrEmpty(location))
                {
                    this.streeviewFrame.Visible = false;
                    return;
                }
                this.streeviewFrame.Src = GooglePlaceService.GetStreeViewUrl(location);
                this.streeviewFrame.Visible = true;
            }
        }
    }
}