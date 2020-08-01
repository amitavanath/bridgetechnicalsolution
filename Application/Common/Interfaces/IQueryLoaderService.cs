using Domain.Entities;
using Domain.Enum;
using System;
namespace Application.Common.Interfaces
{
    public interface IQueryLoaderService
    {
        QueryType QueryType { get; }
        QueryParam RequestedRoutesParser();
    }
}
