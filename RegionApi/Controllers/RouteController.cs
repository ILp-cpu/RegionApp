using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegionService.Interfaces;
using RegionContext;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegionApi.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        private IRouteService _service;
        public RouteController(IRouteService service)
        {
            //_ctx = ctx;
            _service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Route> Get()
        {
            return _service.GetRouts();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("[action]/{regionId}")]
        [HttpGet("{regionId}")]
        public IEnumerable<RegionModel.RouteVModel> GetRouteTotalData(int regionId)
        {
            return _service.GetRouteTotalData(regionId);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
