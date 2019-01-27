using Dottor.MicrosoftIgnite.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dottor.WebFormApplication.Web.Cities
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = new IgniteTourRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var cities = data.GetCities();
            lvCities.DataSource = cities.OrderBy(c => c.StartDate).ToArray();
            lvCities.DataBind();
        }
    }
}