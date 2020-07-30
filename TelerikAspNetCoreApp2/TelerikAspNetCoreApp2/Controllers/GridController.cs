using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using TelerikAspNetCoreApp2.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using RegionModel;

namespace TelerikAspNetCoreApp2.Controllers
{
    
    public class GridController : Controller
    {
        private UserApi _uapi = new UserApi();
           public async Task<IActionResult> Data_Read([DataSourceRequest]DataSourceRequest request)
        {
            List<RegionVModel> regions = new List<RegionVModel>();
            HttpClient client = _uapi.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Region/GetRegionTotalData/2/0");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                regions = JsonConvert.DeserializeObject<List<RegionVModel>>(result);
            }

            var dsResult = regions.ToDataSourceResult(request);
            return Json(dsResult);
        }

        public async Task<ActionResult> HierarchyData_Read(int parentId, [DataSourceRequest] DataSourceRequest request)
        {
            List<RegionVModel> regions = new List<RegionVModel>();
            HttpClient client = _uapi.Initial();
            //HttpResponseMessage res = await client.GetAsync($"api/Region/GetByParentId/{parentId}");
            HttpResponseMessage res = await client.GetAsync($"api/Region/GetRegionTotalData/3/{parentId}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                regions = JsonConvert.DeserializeObject<List<RegionVModel>>(result);
            }

            var dsResult = regions.ToDataSourceResult(request);
            return Json(dsResult);
        }

        public async Task<ActionResult> RouteData_Read(int regionId, [DataSourceRequest] DataSourceRequest request)
        {
            List<RouteVModel> routs = new List<RouteVModel>();
            HttpClient client = _uapi.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Route/GetRouteTotalData/{regionId}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                routs = JsonConvert.DeserializeObject<List<RouteVModel>>(result);
            }

            var dsResult = routs.ToDataSourceResult(request);
            return Json(dsResult);
        }
    }
}
