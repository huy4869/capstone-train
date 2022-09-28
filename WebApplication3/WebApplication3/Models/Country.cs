using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Country
    {
        [Key]
        [Column("Code")]
        public string countryCode { get; set; }
        public string name { get; set; }
        public string continent { get; set; }
        public string region { get; set; }
        public double? surfaceArea { get; set; }
        public int? indepYear { get; set; }
        public int? population { get; set; }
        public double? lifeExpectancy { get; set; }
        public double? GNP { get; set; }
        public double? GNPOld { get; set; }
        public string localName { get; set; }
        public string governmentForm { get; set; }
        public string headOfState { get; set; }
        public int? capital { get; set; }
        public string code2 { get; set; }

    }
}
