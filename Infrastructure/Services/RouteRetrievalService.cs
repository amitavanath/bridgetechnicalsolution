﻿using Application.Common.Interfaces;
using Domain.Enum;
using System;

namespace Infrastructure.Services
{
    public class RouteRetrievalService : IRouteRetrievalService
    {
        private readonly IQueryLoaderService _queryLoaderService;
        private readonly IRouteLoaderService _routeLoaderService;

        public RouteRetrievalService(IRouteLoaderService routeLoaderService,
                                     IQueryLoaderService queryLoaderService)
        {
            _queryLoaderService = queryLoaderService;
            _routeLoaderService = routeLoaderService;
        }

        public string GetAnswer()
        {
            if (_queryLoaderService.queryType == QueryType.routedistance)
            {
                return CalculateRouteDistance();
            }
            else if(_queryLoaderService.queryType == QueryType.numberoftrips)
            {
                return CalculateDifferentRoutes();
            }
            else if(_queryLoaderService.queryType == QueryType.shortestroute)
            {
                return CalculateShortestRoute();
            }

            return null;
        }
        public string CalculateDifferentRoutes()
        {
            throw new NotImplementedException();
        }

        public string CalculateRouteDistance()
        {
            int totalRouteDistance = 0;
            int value;

            foreach(var routeRequest in _queryLoaderService
                                        .RequestedRoutesParser()
                                        .RequestedRoutes)
            {

                if(_routeLoaderService
                    .LoadInitialRouteData()
                    .routeDictionary
                    .TryGetValue(routeRequest, out value))
                {
                    totalRouteDistance = totalRouteDistance + value;
                }
                else
                {
                    return "NO SUCH ROUTE EXISTS";
                }
            }

            if(totalRouteDistance == 0)
            {
                return "NO SUCH ROUTE EXISTS";
            }

            return totalRouteDistance.ToString();

        }

        public string CalculateShortestRoute()
        {
            throw new NotImplementedException();
        }
    }
}
