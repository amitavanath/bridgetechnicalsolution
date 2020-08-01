using System.Collections.Generic;

namespace Domain.Entities
{
    public class QueryParam
    {
        public QueryParam(string input)
        {
            RoutePoints = input;
            RequestedRoutes = new List<string>();
        }

        public string RoutePoints { get; private set; }

        public List<string> RequestedRoutes { get; set; }


    }
}
