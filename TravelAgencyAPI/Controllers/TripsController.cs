using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TravelAgencyAPI.Model;

namespace TravelAgencyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTripsAsync(CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        await using var com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "select " +
                          "T.IdTrip, T.Name AS  TripName, T.Description, T.DateFrom, T.DateTo, T.MaxPeople" +
                          ", C.IdCountry, C.Name AS CountryName " +
                          "FROM Trip T inner join s27661.Country_Trip CT on T.IdTrip = CT.IdTrip " +
                          "inner join s27661.Country C on C.IdCountry = CT.IdCountry";

        await con.OpenAsync(cancellationToken);
        SqlDataReader reader = await com.ExecuteReaderAsync();

        var trips = new List<Trip>();
        while (await reader.ReadAsync())
        {
            int Id = (int)reader["IdTrip"];
            var trip = trips.FirstOrDefault(tr => tr.Id == Id);
            if (trip == null)
            {
                trip = new Trip((int)reader["IdTrip"]
                    , (string)reader["TripName"]
                    , (string)reader["Description"]
                    , (DateTime)reader["DateFrom"]
                    , (DateTime)reader["DateTo"]
                    , (int)reader["MaxPeople"]);
                trips.Add(trip);
            }
            trip.Countries.Add(new Country((int)reader["IdCountry"], (string)reader["CountryName"]));
        }
        return Ok(trips);
    }
}