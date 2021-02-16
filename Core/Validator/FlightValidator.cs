using FluentValidation;
using FlightSearch.API.Data.Dto.Flight;
using FlightSearch.API.Data.Models;

namespace FlightSearch.API.Core.Validator
{
    public class FlightValidator : AbstractValidator<Flight>
    {
        public FlightValidator()
        {
            RuleFor(product => product.Origin).NotEmpty();
            RuleFor(product => product.Destination).NotEmpty();
        }
    }
}
