using Domain.Enum;
using Application.Common.Exceptions;
using Infrastructure.Services;
using Xunit;

namespace UnitTestProjectAll
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7",
                    "A-B-C-D",
                    QueryType.routedistance,
                    "17")]
        [InlineData("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7",
                    "A-E-B-C-D",
                    QueryType.routedistance,
                    "22")]
        [InlineData("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7",
                    "A-E-D",
                    QueryType.routedistance,
                    "NO SUCH ROUTE EXISTS")]
        public void TestCalculateRouteDistance(string routes,
                                                string querystring,
                                                QueryType querytype,
                                                string expected)
        {
            RouteLoaderService routeLoaderService =
                new RouteLoaderService(routes);

            QueryLoaderService queryLoaderService =
                new QueryLoaderService(querystring, querytype);

            RouteRetrievalService routeRetrievalService =
                new RouteRetrievalService(routeLoaderService, queryLoaderService);

            string result = routeRetrievalService.GetAnswer();

            Assert.Equal(expected, result);

        }

        [Fact]
        public void TestQueryLoaderParamValidationException()
        {           
            Assert.Throws<QueryParamValidationException>(() =>
                new QueryLoaderService("A-",
                        Domain.Enum.QueryType.numberoftrips));
        }

        [Fact]
        public void TestRouteLoaderInputDataValidationException()
        {
            Assert.Throws<InputValidationException>(() =>
                new RouteLoaderService(""));
        }

        [Theory]
        [InlineData("A-B", 1)]
        [InlineData("A-B-C", 2)]
        public void TestQueryLoaderParserForInputs(string input,
                                                    int expectedLength)
        {
            Assert.Equal(expectedLength,
                            new QueryLoaderService(input,
                                           Domain.Enum.QueryType.numberoftrips)
                                                .RequestedRoutesParser()
                                                .RequestedRoutes.Count);
        }

        [Theory]
        [InlineData("AB5", 1)]
        [InlineData("AB5, AC6", 2)]
        public void TestRouteLoaderForInputs(string input,
                                                int expectedLength)
        {
            Assert.Equal(expectedLength,
                new RouteLoaderService(input)
                    .LoadInitialRouteData()
                    .RouteDictionary
                    .Count);
        }
    }
}
