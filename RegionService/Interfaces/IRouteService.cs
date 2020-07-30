using System;
using System.Collections.Generic;
using System.Text;
using RegionContext;

namespace RegionService.Interfaces
{
    public interface IRouteService
    {
        List<Route> GetRouts();
        List<RegionModel.RouteVModel> GetRouteTotalData(int regionId);
    }
}
