using Application.Common.Interfaces;
using Domain.Entities;
using Application.Common.Validators;
using Application.Common.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class RouteLoaderService : IRouteLoaderService
    {
        private Route _route { get; set; }
        private RouteList _routeList { get; set; }

        public RouteLoaderService(string input)
        {
            _route = new Route(input);
            InputDataValidator inputValidator = new InputDataValidator();
            if (!inputValidator.Validate(_route).IsValid)
                throw new InputValidationException(input);
            
            _routeList = new RouteList();
        }

        public RouteList LoadInitialRouteData()
        {
            //ToDo: validate the input and load the routes

            List<string> inputArr = _route
                                    .RouteString
                                    .Trim()
                                    .Split(',')
                                    .Select(x => x.Trim())
                                    .ToList();
            
            _routeList.routeDictionary = inputArr
                                         .ToDictionary(x => x.Substring(0, 2),
                                            x => int.Parse(x.Substring(2)));

            return _routeList;
        }
    }
}
