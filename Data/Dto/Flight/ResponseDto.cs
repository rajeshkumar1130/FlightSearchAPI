using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSearch.API.Data.Dto.Flight
{
    public class ResponseDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departs { get; set; }
        public DateTime Arrives { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
