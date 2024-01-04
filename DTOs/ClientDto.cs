using myClientListApp.Models;

namespace myClientListApp.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public List<PhoneNumberDto>? PhoneNumbers { get; set; }

        public ClientDto(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
            Address = client.Address;
            Email = client.Email;
            PhoneNumbers = client.PhoneNumbers?.Select(p => new PhoneNumberDto(p)).ToList();
        }

        // Default constructor for model binding in the controller
        public ClientDto()
        {
        }

        // Method to convert ClientDto to Client
        public Client ToClient()
        {
            return new Client
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                Address = Address,
                Email = Email,
                PhoneNumbers = PhoneNumbers?.Select(p => p.ToPhoneNumber()).ToList()
            };
        }
    }
}

