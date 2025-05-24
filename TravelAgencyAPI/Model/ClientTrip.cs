namespace TravelAgencyAPI.Model;

public class ClientTrip
{
    public int IdClient { get; set; }
    public int IdTrip { get; set; }
    public int RegisteredAt { get; set; }
    public int PaymentDate { get; set; }

    public ClientTrip(int idClient, int idTrip, int registeredAt, int paymentDate)
    {
        IdClient = idClient;
        IdTrip = idTrip;
        RegisteredAt = registeredAt;
        PaymentDate = paymentDate;
    }
}