using System;
using System.Collections.Generic;
using System.Text;
using RegionContext;

namespace RegionService.Interfaces
{
    public interface IRegionService
    {
        List<Region> GetRegions();
        List<Region> GetRegionsByLevel(int level);

        Region GetRegionById(int id);

        List<Region> GetRegionsByParentId(int parentId);

        List<RegionModel.RegionVModel> GetRegionTotalData(int regionId, int regionLevel);
    }
}
