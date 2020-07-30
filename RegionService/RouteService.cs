using System;
using System.Collections.Generic;
using System.Text;
using RegionContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegionModel;

namespace RegionService
{
    public class RouteService : Interfaces.IRouteService
    {
        private readonly BackUpDB2Context _rcxt;

        public RouteService(BackUpDB2Context rcxt)
        {
            _rcxt = rcxt;
        }
        public List<Route> GetRouts()
        {
            return _rcxt.Route.ToList();
        }

        public List<RouteVModel> GetRouteTotalData(int regionId)
        {
            var res = new List<RouteVModel>();

            var query = (from s in _rcxt.Route
                         join cs in _rcxt.City on s.FromCityId equals cs.Id
                         join fs in _rcxt.City on s.ToCityId equals fs.Id
                         join rs in _rcxt.Region on cs.RegionId equals rs.RegionId
                         join us in _rcxt.Users on s.UserId equals us.Id
                         //where cs.RegionId == regionId
                         where (rs.RegionId == regionId)
                         select new
                         {
                             s.Id,
                             FromCity = cs.CityName,
                             ToCity = fs.CityName,
                             M18 = (us.Gender == "M" && us.Age <= 18) ? 1 : 0,
                             M60 = (us.Gender == "M" && us.Age > 18 && us.Age <= 60) ? 1 : 0,
                             MOver = (us.Gender == "M" && us.Age > 60) ? 1 : 0,
                             F18 = (us.Gender == "F" && us.Age <= 18) ? 1 : 0,
                             F60 = (us.Gender == "F" && us.Age > 18 && us.Age <= 60) ? 1 : 0,
                             FOver = (us.Gender == "F" && us.Age > 60) ? 1 : 0,
                         }).ToList();


            //var summaryRoute = query.GroupBy(x => new { x.ParentRegionId, x.ParentRegionName })
            var summaryRoute = query.GroupBy(x => new { x.FromCity, x.ToCity })
                           .Select(t => new RouteVModel
                           {
                               Id = 1,
                               from_city = t.Key.FromCity,
                               to_city = t.Key.ToCity,
                               m18 = t.Sum(ta => ta.M18),
                               m60 = t.Sum(ta => ta.M60),
                               m_over = t.Sum(ta => ta.MOver),
                               f18 = t.Sum(ta => ta.F18),
                               f60 = t.Sum(ta => ta.F60),
                               f_over = t.Sum(ta => ta.FOver),
                               total = t.Sum(ta => ta.M18 + ta.M60 + ta.MOver + ta.F18 + ta.F60 + ta.FOver)
                           }).ToList();

            return summaryRoute;
        }
    }
}
