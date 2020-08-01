using System;
namespace Application.Common.Exceptions
{
    public class QueryParamValidationException : Exception
    {
        private static readonly string DefaultMessage = @"Query parameter 
        validation failed. Please validate query parameters.";

        private string _inputString { get; set; }

        public QueryParamValidationException(string inputString)
            : base(DefaultMessage)
        {
            _inputString = inputString;
        }
    }
}
