using System;
using FluentValidation;
using Domain.Entities;

namespace Application.Common.Validators
{
    public class QueryParamValidator : AbstractValidator<QueryParam>
    {
        public QueryParamValidator()
        {
            RuleFor(queryParam => queryParam.RoutePoints).NotEmpty();

            RuleFor(queryParam => queryParam.RoutePoints)
                .Custom((routepoints, context) =>
            {
                if(routepoints.Split('-',
                    StringSplitOptions.RemoveEmptyEntries).Length < 2)
                {
                    context.AddFailure("Bad Input");
                }
            });
        }
    }
}
