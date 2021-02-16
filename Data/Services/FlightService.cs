using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightSearch.API.Data.Interfaces;
using FlightSearch.API.Data.Models;
using System.Linq;
using Microsoft.Data.SqlClient;
using System;
using FlightSearch.API.Data.Dto.Flight;

namespace FlightSearch.API.Data.Services
{
    public class FlightService : IFlightService
    {
        private readonly AppDbContext _appDbContext;

        public FlightService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Flight>> GetFlights(string origin, string destination, DateTime date)
        {
            var originParameter = new SqlParameter("@origin", origin);
            var destinationParameter = new SqlParameter("@destination", destination);
            var dateParameter = new SqlParameter("@date", date);

            var result = await _appDbContext.Set<Flight>().FromSqlRaw("FlightSearch @origin, @destination, @date", originParameter, destinationParameter, dateParameter).ToListAsync();
            return result;
        }
    }
}
