using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IRouteLoaderService
    {
        RouteList LoadInitialRouteData();
    }
}
