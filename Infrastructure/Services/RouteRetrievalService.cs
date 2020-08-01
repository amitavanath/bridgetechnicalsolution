using Application.Common.Interfaces;
using Domain.Enum;
using System;
namespace Infrastructure.Services
{
    public class RouteRetrievalService : IRouteRetrievalService
    {
        private IQueryLoaderService _queryLoaderService;
        private IRouteLoaderService _routeLoaderService;

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
                CalculateRouteDistance();
            }
            else if(_queryLoaderService.queryType == QueryType.numberoftrips)
            {
                CalculateDifferentRoutes();
            }
            else if(_queryLoaderService.queryType == QueryType.shortestroute)
            {
                CalculateShortestRoute();
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
