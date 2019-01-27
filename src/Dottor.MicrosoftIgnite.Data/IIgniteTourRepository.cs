using Dottor.MicrosoftIgnite.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.MicrosoftIgnite.Data
{
    public interface IIgniteTourRepository
    {

        IEnumerable<TourRegion> GetRegions();

        IEnumerable<TourCity> GetCities();

        TourCity GetCity(int cityId);
        void InsertCity(TourCity city);
        void UpdateCity(TourCity city);
        void DeleteCity(int cityId);
    }
}
