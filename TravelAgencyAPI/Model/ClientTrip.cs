using System.Text.Json.Serialization;

namespace TravelAgencyAPI.Model;

public class ClientTrip
{
    public int IdClient { get; set; }
    [JsonIgnore]
    public Client Client { get; set; }
    public int IdTrip { get; set; }
    public Trip Trip { get; set; }
    public int RegisteredAt { get; set; }
    public int PaymentDate { get; set; }

    public ClientTrip(int idClient, int idTrip, int registeredAt, int paymentDate, Client client, Trip trip)
    {
        IdClient = idClient;
        IdTrip = idTrip;
        RegisteredAt = registeredAt;
        PaymentDate = paymentDate;
        Client = client;
        Trip = trip;
    }
}