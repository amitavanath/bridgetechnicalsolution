using System;
using FluentValidation;
using Domain.Entities;

namespace Application.Common.Validators
{
    public class InputDataValidator : AbstractValidator<Route>
    {
        public InputDataValidator()
        {
            RuleFor(route => route.RouteString).NotEmpty();            
        }    
    }
}
