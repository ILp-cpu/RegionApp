using RegionService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegionContext;
using RegionModel;

namespace RegionService
{
    public class RegionService : IRegionService
    {
        //private readonly RegionContext.RegionDBContext _rcxt;
        private readonly BackUpDB2Context _rcxt;

        public RegionService(BackUpDB2Context rcxt)
        {
            _rcxt = rcxt;
        }

        public Region GetRegionById(int id)
        {
            return _rcxt.Region.Where(c => c.RegionId == id).FirstOrDefault();
        }

        public List<Region> GetRegions()
        {
            return _rcxt.Region.ToList();
        }

        public List<Region> GetRegionsByLevel(int level)
        {
            return _rcxt.Region.Where(c=>c.RegionLevel==level).ToList();
        }

        public List<Region> GetRegionsByParentId(int parentId)
        {
            return _rcxt.Region.Where(c => c.ParentRegionId == parentId).ToList();
        }

        public List<RegionVModel> GetRegionTotalData(int parentId, int regionLevel)
        {
            var res = new List<RegionVModel>();
            
                        var query = (from s in _rcxt.Route
                                     join cs in _rcxt.City on s.FromCityId equals cs.Id
                                     join rs in _rcxt.Region on cs.RegionId equals rs.RegionId
                                     join fo in _rcxt.Region on rs.ParentRegionId equals fo.RegionId
                                     join us in _rcxt.Users on s.UserId equals us.Id
                                     //where cs.RegionId == regionId
                                     where (parentId == 0 || rs.ParentRegionId == parentId)
                                     select new 
                                     {
                                         s.Id,
                                         RegionId = (parentId == 0)? rs.ParentRegionId:cs.RegionId,
                                         //rs.ParentRegionId,
                                         NameRegion = (parentId == 0) ? fo.RegionName:rs.RegionName,
                                         //ParentRegionName = fo.RegionName,
                                         M18 = (us.Gender == "M" && us.Age <= 18) ? 1 : 0,
                                         M60 = (us.Gender == "M" && us.Age > 18 && us.Age <= 60) ? 1 : 0,
                                         MOver = (us.Gender == "M" && us.Age > 60) ? 1 : 0,
                                         F18 = (us.Gender == "F" && us.Age <= 18) ? 1 : 0,
                                         F60 = (us.Gender == "F" && us.Age > 18 && us.Age <= 60) ? 1 : 0,
                                         FOver = (us.Gender == "F" && us.Age > 60) ? 1 : 0,
                                     }).ToList();


            //var summaryRoute = query.GroupBy(x => new { x.ParentRegionId, x.ParentRegionName })
            var summaryRoute = query.GroupBy(x => new { x.RegionId, x.NameRegion })
                           .Select(t => new 
                            {
                                region_id = t.Key.RegionId,
                                region_name = t.Key.NameRegion,
                                m18 = t.Sum(ta => ta.M18),
                                m60 = t.Sum(ta => ta.M60),
                                m_over = t.Sum(ta => ta.MOver),
                                f18 = t.Sum(ta => ta.F18),
                                f60 = t.Sum(ta => ta.F60),
                                f_over = t.Sum(ta => ta.FOver),
                                total = t.Sum(ta=> ta.M18+ta.M60+ta.MOver+ta.F18+ta.F60+ta.FOver)
                            }).ToList();



            res = (from r in _rcxt.Region
                              join s in summaryRoute
                              on r.RegionId equals s.region_id
                              
                              into RSGroup
                              from summary in RSGroup.DefaultIfEmpty()
                   where (r.RegionLevel == regionLevel && (parentId == 0 || r.ParentRegionId == parentId))
                   select new RegionVModel
                              {
                                  region_id = r.RegionId,
                                  region_name = r.RegionName,
                                  m18 = (summary == null) ? 0 : summary.m18,
                                  m60 = (summary == null) ? 0 : summary.m60,
                                  m_over = (summary == null) ? 0 : summary.m_over,
                                  f18 = (summary == null) ? 0 : summary.f18,
                                  f60 = (summary == null) ? 0 : summary.f60,
                                  f_over = (summary == null) ? 0 : summary.f_over,
                                  total = (summary == null) ? 0 : summary.total,
                              }).ToList();

           
            return res;
        }
    }
}
