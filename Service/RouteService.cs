using Core.Models;
using Service.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class RouteService : IRouteService
    {
        public IEnumerable<RouteDetails> FlattenedData(IEnumerable<Route> route)
        {
            List<RouteDetails> routeDetails = new List<RouteDetails>();
            ToFlatData(route, routeDetails);

            //Dictionary<string, object> objects = new Dictionary<string, object>();
            ////BigOnConversion(route);

            //foreach (var item in route)
            //{
            //    objects.Union(BigOnConversion(item));
            //}

            return routeDetails;
        }

        private static void ToFlatData(IEnumerable<Route> route, List<RouteDetails> routeDetails)
        {
            foreach (var item in route)
            {
                foreach (var stop in item.Stops)
                {
                    foreach (var objectDetails in stop.Objects)
                    {
                        var routeDetail = new RouteDetails { RouteName = item.RouteName };
                        routeDetail.StopName = stop.StopName;
                        routeDetail.ObjectType = objectDetails.ObjectType;
                        routeDetail.ObjectName = objectDetails.ObjectName;

                        routeDetails.Add(routeDetail);
                    }
                }
            }
        }

        //Need some more time to resolve this :)
        private static Dictionary<string, object> UsingReflection(object item)
        {
            Dictionary<string, object> objects = new Dictionary<string, object>();            

            var properties = item.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    objects.Add(property.Name, property.GetValue(item));
                }
                else if (property.PropertyType == typeof(List<object>))
                {
                    objects.Union(UsingReflection(property.GetValue(item, null)));
                }
            }

            return objects;
        }
    }
}
