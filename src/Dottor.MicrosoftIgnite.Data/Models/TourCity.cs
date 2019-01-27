using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.MicrosoftIgnite.Data.Models
{
    public class TourCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateDisplayed { get; set; }
        public DateTime StartDate { get; set; }
        public string ImageUrl { get; set; }

        public bool Visible { get; set; }
        public int TourRegionId { get; set; }

        public DateTime LastUpdateDate { get; set; }
        public string LastUpdateUserId { get; set; }
        public string LastUpdateUserName { get; set; }

    }
}
