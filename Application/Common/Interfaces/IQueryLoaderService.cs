using Domain.Entities;
using Domain.Enum;
using System;
namespace Application.Common.Interfaces
{
    public interface IQueryLoaderService
    {
        QueryType queryType { get; }
        QueryParam RequestedRoutesParser();
    }
}
