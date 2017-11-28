using GoogleService.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleService
{
    public partial class mapview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string placeid = this.Request.QueryString["id"];
                if (string.IsNullOrEmpty(placeid))
                {
                    this.mapviewFrame.Visible = false;
                    return;
                }
                this.mapviewFrame.Src = GooglePlaceService.GetMapUrl(placeid);
                this.mapviewFrame.Visible = true;
            }
        }
    }
}