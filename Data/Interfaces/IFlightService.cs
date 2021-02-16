using System.Collections.Generic;
using System.Threading.Tasks;
using FlightSearch.API.Data.Models;
using System;
using FlightSearch.API.Data.Dto.Flight;

namespace FlightSearch.API.Data.Interfaces
{
    public interface IFlightService
    {
        Task<List<Flight>> GetFlights(string origin, string destination, DateTime date);
    }
}
