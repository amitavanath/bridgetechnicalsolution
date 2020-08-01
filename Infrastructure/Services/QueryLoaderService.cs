using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Application.Common.Validators;
using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class QueryLoaderService : IQueryLoaderService
    {
        private string _routes;
        private QueryParam _queryParam;
        public QueryType queryType { get; private set; }

        public QueryLoaderService(string routes, QueryType type)
        {
            _queryParam = new QueryParam(routes);
            QueryParamValidator queryParamValidator = new QueryParamValidator();
            if (!queryParamValidator.Validate(_queryParam).IsValid)
                throw new QueryParamValidationException(routes);

            _routes = routes;
            queryType = type;
        }

        public QueryParam RequestedRoutesParser()
        {
            //ToDo:validate the query
            //QueryParam queryParam = new QueryParam();
            //queryParam.RoutePoints = _routes;

            string[] tempArr = _queryParam.RoutePoints.Split('-');

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
