using System.Collections.Generic;

namespace Domain.Entities
{
    public class RouteList
    {
        public RouteList()
        {
            routeDictionary = new Dictionary<string, int>();
        }

        public Dictionary<string, int> routeDictionary { get; set; }
    }
}
