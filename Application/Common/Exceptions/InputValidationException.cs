using System;
namespace Application.Common.Exceptions
{
    public class InputValidationException : Exception
    {
        private static readonly string DefaultMessage = @"Input validation 
        failed. The input to the program should consist of tuples, consisting 
        of the starting academy, ending academy, and the directed distance 
        between the academies. A given route should never appear more than once,
        and for a given route, the starting and ending academy will not be the 
        same academy.";        

        public InputValidationException(string inputString) 
            : base(DefaultMessage)
        {

        }
    }
}
