namespace TravelAgencyAPI.Model;

public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Pesel { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";

    public Client(int id, string firstName, string lastName, string email, string phone, string pesel)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Pesel = pesel;
    }
}