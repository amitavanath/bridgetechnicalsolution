using System;

namespace Domain.Entities
{
    public class Route
    {
        public string RouteString { get; set; }

        public Route(string input)
        {
            RouteString = input;
        }
    }
}
