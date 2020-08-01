using Domain.Entities;
using System;
namespace Application.Common.Interfaces
{
    public interface IRouteLoaderService
    {
        RouteList LoadInitialRouteData();
    }
}
