using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using test3.Services;
using test3.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test3.Controllers
{
    public class CostsController : ODataController
    {
        private readonly IGetCost _getCost;
        private readonly IGetCostWithId _getCostWithId;

        public CostsController(IGetCost getCost,
                               IGetCostWithId getCostWithId)
        {
            _getCost = getCost;
            _getCostWithId = getCostWithId;
        }

        [EnableQuery]
        public List<GetCostModel> Get()
        {
            return _getCost.GetCostMethod();
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return _getCostWithId.GetCostWithIdMethod(key);
        }
    }
}
