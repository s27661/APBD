namespace TravelAgencyAPI.Model;

public class CountryTrip
{
    public int IdCountry { get; set; }
    public int IdTrip { get; set; }

    public CountryTrip(int idCountry, int idTrip)
    {
        IdCountry = idCountry;
        IdTrip = idTrip;
    }
}