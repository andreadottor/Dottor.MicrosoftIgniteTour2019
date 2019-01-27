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
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = new IgniteTourRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                ddlRegion.DataSource = data.GetRegions();
                ddlRegion.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                var city = new TourCity()
                {
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
                data.InsertCity(city);

                Response.Redirect(ResolveUrl("~/Cities/List"));
            }
        }
    }
}