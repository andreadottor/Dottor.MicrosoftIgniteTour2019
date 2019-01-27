using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dottor.MicrosoftIgnite.Data;
using Dottor.MicrosoftIgnite.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dottor.NewCoreApplication.Web.Pages
{
    public class IndexModel : PageModel
    {
        private IIgniteTourRepository _igniteTourRepository;

        public IEnumerable<TourRegion> Regions { get; private set; }
        public IEnumerable<TourCity> Cities { get; private set; }


        public IndexModel(IIgniteTourRepository igniteTourRepository)
        {
            _igniteTourRepository = igniteTourRepository;
        }

        public void OnGet()
        {
            this.Regions = _igniteTourRepository.GetRegions();
            this.Cities = _igniteTourRepository.GetCities();
        }
    }
}
