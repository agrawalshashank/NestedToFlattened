using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contract
{
    public interface IRouteService
    {
        IEnumerable<RouteDetails> FlattenedData(IEnumerable<Route> routeDetails);
    }
}
