using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FlightSearch.API.Data.Dto.Flight;
using FlightSearch.API.Data.Interfaces;
using FlightSearch.API.Data.Models;
using System;

namespace FlightSearch.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public FlightController(IFlightService productService, IMapper mapper, ILoggerManager logger)
        {
            _flightService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Search flights
        /// </summary>
        [HttpGet("{origin}/{destination}/{date}")]
        public async Task<ActionResult<List<Flight>>> Get([FromRoute] string origin, [FromRoute] string destination, [FromRoute] DateTime date)
        {
            _logger.LogInfo("Searching flights");

            var flights = await _flightService.GetFlights(origin, destination, date);
            if (flights == null)
                return NotFound();

            _logger.LogInfo($"Returning flights");

            return Ok(flights);
        }
    }
}
