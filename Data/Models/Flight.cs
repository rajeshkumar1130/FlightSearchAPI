using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using CsvHelper.Configuration;

namespace FlightSearch.API.Data.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departs { get; set; }
        public DateTime Arrives { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}