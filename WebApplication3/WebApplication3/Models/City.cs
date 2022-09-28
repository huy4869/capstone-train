using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class City
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public string district { get; set; }
        public int population { get; set; }

    }
}
