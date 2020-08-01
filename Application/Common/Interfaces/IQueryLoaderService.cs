using Domain.Entities;
using Domain.Enum;

namespace Application.Common.Interfaces
{
    public interface IQueryLoaderService
    {
        QueryType GetQueryType();
        QueryParam RequestedRoutesParser();
    }
}
