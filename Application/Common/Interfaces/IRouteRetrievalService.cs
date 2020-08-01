namespace Application.Common.Interfaces
{
    public interface IRouteRetrievalService
    {
        string CalculateRouteDistance();

        string CalculateDifferentRoutes();

        string CalculateShortestRoute();
    }
}
