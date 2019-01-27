using Dottor.MicrosoftIgnite.Data;
using Dottor.MicrosoftIgnite.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dottor.WebFormApplication.Web.Cities
{
    public partial class Edit : System.Web.UI.Page
    {
        public int CityId { get { return int.Parse(Request.QueryString["id"] ?? "0"); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = new IgniteTourRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                ddlRegion.DataSource = data.GetRegions();
                ddlRegion.DataBind();

                var city = data.GetCity(CityId);
                if(city != null)
                {
                    txtName.Text = city.Name;
                    txtDateDisplayed.Text = city.DateDisplayed;
                    txtImage.Text = city.ImageUrl;
                    txtName.Text = city.Name;
                    dtDate.Date = city.StartDate;
                    ddlRegion.SelectedValue = city.TourRegionId.ToString();
                    cbVisible.Checked = city.Visible;

                    txtUserLastEdit.Text = city.LastUpdateUserName;
                    txtDateLastEdit.Text = city.LastUpdateDate.ToString();
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                var city = new TourCity()
                {
                    Id = CityId,
                    DateDisplayed = txtDateDisplayed.Text,
                    ImageUrl = txtImage.Text,
                    LastUpdateDate = DateTime.Now,
                    LastUpdateUserId = User.Identity.GetUserId(),
                    Name = txtName.Text,
                    StartDate = dtDate.Date,
                    TourRegionId = int.Parse(ddlRegion.SelectedValue),
                    Visible = cbVisible.Checked
                };
                var data = new IgniteTourRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                data.UpdateCity(city);

                Response.Redirect(ResolveUrl("~/Cities/List"));
            }
        }
    }
}