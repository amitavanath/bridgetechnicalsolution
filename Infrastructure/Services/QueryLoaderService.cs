using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Application.Common.Validators;
using Application.Common.Exceptions;
using System;

namespace Infrastructure.Services
{
    public class QueryLoaderService : IQueryLoaderService
    {
        private readonly QueryParam _queryParam;
        public QueryType queryType { get; private set; }

        public QueryLoaderService(string routes, QueryType type)
        {
            _queryParam = new QueryParam(routes);
            QueryParamValidator queryParamValidator = new QueryParamValidator();

            if (!queryParamValidator.Validate(_queryParam).IsValid)
            {
                throw new QueryParamValidationException(routes);
            }

            queryType = type;
        }

        public QueryParam RequestedRoutesParser()
        {
            string[] tempArr = _queryParam.RoutePoints.Trim().Split('-',
                                    StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            foreach(string letter in tempArr)
            {  
                if(i < tempArr.Length - 1)
                {
                    string route = letter + tempArr[i + 1];
                    _queryParam.RequestedRoutes.Add(route);
                }
                i++;       
            }
                
            return _queryParam;
        }
    }
}
