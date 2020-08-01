using System;
using Infrastructure.Services;
using Xunit;

namespace UnitTestProjectAll
{
    public class UnitTest1
    {
        [Fact]
        public void TestCalculateRouteDistance()
        {
            RouteLoaderService routeLoaderService =
                new RouteLoaderService("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

            QueryLoaderService queryLoaderService =
                new QueryLoaderService("A-B-C-D", Domain.Enum.QueryType.routedistance);

            RouteRetrievalService routeRetrievalService =
                new RouteRetrievalService(routeLoaderService, queryLoaderService);

            routeRetrievalService.GetAnswer();

        }

        [Fact]
        public void TestQueryLoaderParam()
        {
            QueryLoaderService queryLoaderService =
                new QueryLoaderService("A-", Domain.Enum.QueryType.numberoftrips);
            queryLoaderService.RequestedRoutesParser();

            //routeLoaderService.GetInitialRouteData("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
        }

        [Fact]
        public void TestRouteLoaderInitialRouteData()
        {
            RouteLoaderService routeLoaderService =
                new RouteLoaderService("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

            routeLoaderService.LoadInitialRouteData();
        }
    }
}
