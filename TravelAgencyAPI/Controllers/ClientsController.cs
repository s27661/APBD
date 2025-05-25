using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TravelAgencyAPI.Model;
using TravelAgencyAPI.Model.DTOs;

namespace TravelAgencyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetClientsAsync(CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        await using var com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "SELECT * FROM Client";

        await con.OpenAsync(cancellationToken);
        SqlDataReader reader = await com.ExecuteReaderAsync();

        var clients = new List<Client>();
        while (await reader.ReadAsync())
        {
            int Id = (int)reader["IdClient"];
            string FirstName = (string)reader["FirstName"];
            string LastName = (string)reader["LastName"];
            string Email = (string)reader["Email"];
            string Phone = (string)reader["Telephone"];
            string Pesel = (string)reader["Pesel"];

            var c = new Client(Id, FirstName, LastName, Email, Phone, Pesel);
            clients.Add(c);
        }
        return Ok(clients);
    }
    
    [HttpGet("{id:int}/trips")]
    public async Task<IActionResult> GetClientTripsByClientIdAsync(int id, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        await using var com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "select C.IdClient AS IdKlienta, C.FirstName, C.LastName, C.Email, C.Telephone, C.Pesel, " +
                          "CT.IdClient, CT.IdTrip, CT.RegisteredAt, ISNULL(CT.PaymentDate,0) AS PaymentDate, " +
                          "T.IdTrip, T.Name AS NazwaTripa, T.Description, T.DateFrom, T.DateTo, T.MaxPeople " +
                          "from Client C " +
                          "inner join s27661.Client_Trip CT on C.IdClient = CT.IdClient " +
                          "inner join s27661.Trip T on T.IdTrip = CT.IdTrip " +
                          "where C.IdClient = @id";
        com.Parameters.AddWithValue("@id", id);

        await con.OpenAsync(cancellationToken);
        SqlDataReader reader = await com.ExecuteReaderAsync(cancellationToken);

        Client client = null;
        while (await reader.ReadAsync(cancellationToken))
        {
            if (client == null)
            {
                client = new Client(
                    (int)reader["IdKlienta"]
                    , (string)reader["FirstName"]
                    , (string)reader["LastName"]
                    , (string)reader["Email"]
                    , (string)reader["Telephone"]
                    , (string)reader["Pesel"]
                );
            }
            var trip = new Trip((int)reader["IdTrip"]
                , (string)reader["NazwaTripa"]
                , (string)reader["Description"]
                , (DateTime)reader["DateFrom"]
                , (DateTime)reader["DateTo"]
                , (int)reader["MaxPeople"]
            );
            
            var CT = new ClientTrip(client.Id, trip.Id, (int)reader["RegisteredAt"], (int)reader["PaymentDate"], client, trip);
            client.ClientTrips.Add(CT);
            
        }
        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> AddClientAsync([FromBody] ClientDto client, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        await using var com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "INSERT INTO Client (FirstName, LastName, Email, Telephone, Pesel) VALUES\n    (@FirstName, @LastName, @Email, @Telephone, @Pesel)";
        com.Parameters.AddWithValue("@FirstName", client.FirstName);
        com.Parameters.AddWithValue("@LastName", client.LastName);
        com.Parameters.AddWithValue("@Email", client.Email);
        com.Parameters.AddWithValue("@Telephone", client.Telephone);
        com.Parameters.AddWithValue("@Pesel", client.Pesel);

        await con.OpenAsync(cancellationToken);
        SqlDataReader reader = await com.ExecuteReaderAsync(cancellationToken);
        
        
        return Ok();
    }
    
}