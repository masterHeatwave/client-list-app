using System.Collections.Generic;

namespace myClientListApp.Models
{
    public enum NumberType
    {
        Home = 0,
        Mobile = 1,
        Work = 2
    }

    public class PhoneNumber
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public NumberType Type { get; set; }
        public int ClientId{ get; set; }
        public Client Client { get; set; } = new Client();
        public string TypeAsString => Type.ToString(); 
    }

}
