using myClientListApp.Models;

namespace myClientListApp.DTOs
{
    public class PhoneNumberDto
    {
        public int Id { get; set; }
        public string? Number { get; set; }

        public PhoneNumberDto(PhoneNumber phoneNumber)
        {
            Id = phoneNumber.Id;
            Number = phoneNumber.Number;
        }

        // Default constructor for model binding in the controller
        public PhoneNumberDto()
        {
        }

        // Method to convert PhoneNumberDto to PhoneNumber
        public PhoneNumber ToPhoneNumber()
        {
            return new PhoneNumber
            {
                Id = Id,
                Number = Number
            };
        }
    }
}

