using GoogleService.Control;
using GoogleService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GoogleService
{
    public partial class ServiceApiTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.content.Visible = false;
            }
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            string key = this.autocomplete.Value;
            GooglePlaceService service = new GooglePlaceService();
            TextSearch data = service.DoTextSearch(key);
            if (data.Status.Equals("OK"))
            {
                SetViewUrl(data);
            }
        }

        private void SetViewUrl(TextSearch result)
        {
            if (result.Results.Length == 0)
            {
                return;
            }
            this.map.Src = GooglePlaceService.GetMapUrl(result);
            this.streeview.Src = GooglePlaceService.GetStreeViewUrl(result);
            this.lblLocation.Text = result.Results[0].Geometry.Location.ToString();
            this.lblPlaceId.Text = result.Results[0].PlaceId;
            string url= "mapview.aspx?id=" + result.Results[0].PlaceId;
            this.lnkMap.NavigateUrl=this.lnkMap.Text = url;
            url = "streeview.aspx?location=" + result.Results[0].Geometry.Location.ToString();
            this.lnkStreeView.NavigateUrl = this.lnkStreeView.Text = url;
            this.content.Visible = true;
        }


       
    }
}