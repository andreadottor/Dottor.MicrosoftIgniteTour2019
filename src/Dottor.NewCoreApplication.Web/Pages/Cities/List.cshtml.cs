using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dottor.MicrosoftIgnite.Data;
using Dottor.MicrosoftIgnite.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dottor.NewCoreApplication.Web.Pages.Cities
{
    [Authorize]
    public class ListModel : PageModel
    {
        private IIgniteTourRepository _igniteTourRepository;

        public IEnumerable<TourCity> Cities { get; private set; }

        public ListModel(IIgniteTourRepository igniteTourRepository)
        {
            _igniteTourRepository = igniteTourRepository;
        }

        public void OnGet()
        {
            this.Cities = this._igniteTourRepository
                                        .GetCities()
                                        .OrderBy(c => c.StartDate)
                                        .ToArray();
        }
    }
}