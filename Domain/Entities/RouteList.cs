using System.Collections.Generic;

namespace Domain.Entities
{
    public class RouteList
    {
        public RouteList()
        {
            RouteDictionary = new Dictionary<string, int>();
        }

        public Dictionary<string, int> RouteDictionary { get; set; }
    }
}
