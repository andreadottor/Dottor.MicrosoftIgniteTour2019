using Dapper;
using Dottor.MicrosoftIgnite.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dottor.MicrosoftIgnite.Data
{
    public class IgniteTourRepository : IIgniteTourRepository
    {
        private string _connectionString;

        public IgniteTourRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DeleteCity(int cityId)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Execute(@"DELETE FROM [dbo].[TourCities WHERE Id = @id", new { id = cityId });
            }
        }

        public IEnumerable<TourCity> GetCities()
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                return connection.Query<TourCity>(@"
SELECT tc.[Id]
      ,tc.[Name]
      ,tc.[StartDate]
      ,tc.[DateDisplayed]
      ,tc.[TourRegionId]
      ,tc.[ImageUrl]
      ,tc.[Visible]
      ,tc.[LastUpdateDate]
      ,tc.[LastUpdateUserId]
	  ,u.[UserName] as [LastUpdateUserName]
  FROM [dbo].[TourCities] tc
  INNER JOIN AspNetUsers u on tc.LastUpdateUserId = u.Id");
            }
        }

        public TourCity GetCity(int cityId)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                return connection.QueryFirstOrDefault<TourCity>(@"
SELECT tc.[Id]
      ,tc.[Name]
      ,tc.[StartDate]
      ,tc.[DateDisplayed]
      ,tc.[TourRegionId]
      ,tc.[ImageUrl]
      ,tc.[Visible]
      ,tc.[LastUpdateDate]
      ,tc.[LastUpdateUserId]
	  ,u.[UserName] as [LastUpdateUserName]
  FROM [dbo].[TourCities] tc
  INNER JOIN AspNetUsers u on tc.LastUpdateUserId = u.Id
  WHERE tc.Id = @id", new { id = cityId });
            }
        }

        public IEnumerable<TourRegion> GetRegions()
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                return connection.Query<TourRegion>(@"
SELECT [Id]
      ,[Name]
  FROM [dbo].[TourRegions]");
            }
        }

        public void InsertCity(TourCity city)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Execute(@"
INSERT INTO [dbo].[TourCities]
           ([Name]
           ,[StartDate]
           ,[DateDisplayed]
           ,[TourRegionId]
           ,[ImageUrl]
           ,[Visible]
           ,[LastUpdateDate]
           ,[LastUpdateUserId])
     VALUES
           (@Name
           ,@StartDate
           ,@DateDisplayed
           ,@TourRegionId
           ,@ImageUrl
           ,@Visible
           ,@LastUpdateDate
           ,@LastUpdateUserId)", city);
            }
        }

        public void UpdateCity(TourCity city)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Execute(@"
UPDATE [dbo].[TourCities]
   SET [Name] = @Name
      ,[StartDate] = @StartDate
      ,[DateDisplayed] = @DateDisplayed
      ,[TourRegionId] = @TourRegionId
      ,[ImageUrl] = @ImageUrl
      ,[Visible] = @Visible
      ,[LastUpdateDate] = getdate()
      ,[LastUpdateUserId] = @LastUpdateUserId
 WHERE Id = @Id", city);
            }
        }
    }
}
