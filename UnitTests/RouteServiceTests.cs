using Core.Models;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class RouteServiceTests
    {
        [Fact]
        public void FlattenedData_EmptyList_ProvideEmptyList()
        {
            var routeService = new RouteService();

            var routeDetails = routeService.FlattenedData(new List<Route>());

            Assert.Equal(new List<RouteDetails>(), routeDetails.ToList());
        }

        [Fact]
        public void FlattenedData_InputRouteData_ProvideFlattenedData()
        {
            var routeService = new RouteService();

            List<Route> routes = new List<Route>
            {
                new Route
                {
                    RouteName = "Test",
                    Stops = new List<Stop>{
                        new Stop { StopName ="StopName",
                        Objects = new List<ObjectDetails>{
                            new ObjectDetails { ObjectName = "ObjectName", ObjectType = "ObjectType" } }
                    } }
                }
            };

            var routeDetails = routeService.FlattenedData(routes);

            Assert.Equal(JsonConvert.SerializeObject(RouteOutput()), JsonConvert.SerializeObject(routeDetails.ToList()));
        }

        private List<RouteDetails> RouteOutput()
        {
            return new List<RouteDetails>{
                new RouteDetails
                {
                    RouteName = "Test",
                    StopName = "StopName",
                    ObjectName = "ObjectName",
                    ObjectType = "ObjectType"
                }
            };
        }
    }
}
