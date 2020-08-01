using Application.Common.Interfaces;
using Domain.Entities;
using Application.Common.Validators;
using Application.Common.Exceptions;
using System.Linq;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class RouteLoaderService : IRouteLoaderService
    {
        private Route Route { get; set; }
        private RouteList RouteList { get; set; }

        public RouteLoaderService(string input)
        {
            Route = new Route(input);
            InputDataValidator inputValidator = new InputDataValidator();

            if (!inputValidator.Validate(Route).IsValid)
            {
                throw new InputValidationException(input);
            }

            RouteList = new RouteList();
        }

        public RouteList LoadInitialRouteData()
        {
            List<string> inputArr = Route
                                    .RouteString
                                    .Trim()
                                    .Split(',')
                                    .Select(x => x.Trim())
                                    .ToList();
            
            RouteList.routeDictionary = inputArr
                                         .ToDictionary(x => x.Substring(0, 2),
                                            x => int.Parse(x.Substring(2)));

            return RouteList;
        }
    }
}
