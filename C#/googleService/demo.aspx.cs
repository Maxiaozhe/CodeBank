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
    public partial class Demo : System.Web.UI.Page
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
                SetViewUrl(service,data);
            }
        }

        private void SetViewUrl(GooglePlaceService service,TextSearch result)
        {
            if (result.Results.Length == 0)
            {
                return;
            }
            this.lblLocation.Text = result.Results[0].Geometry.Location.ToString();
            this.lblPlaceId.Text = result.Results[0].PlaceId;
            var detail = service.GetDetail(result.Results[0].PlaceId);
            
            string url= detail.Result.Url;
            this.lnkMap.NavigateUrl=this.lnkMap.Text = url;
            this.content.Visible = true;
        }


       
    }
}