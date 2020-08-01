using System;
namespace Application.Common.Exceptions
{
    public class QueryParamValidationException : Exception
    {
        private static readonly string DefaultMessage = @"Query parameter 
        validation failed. Please validate query parameters.";

        public QueryParamValidationException(string inputString)
            : base(DefaultMessage)
        {

        }
    }
}
