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
        }
    }
}
