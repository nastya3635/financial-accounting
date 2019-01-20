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
using Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test3.Controllers
{
    public class CostsController : ODataController
    {
        private readonly IGetCost _getCost;
        private readonly IGetCostWithId _getCostWithId;
        private readonly IPostCost _postCost;
        private readonly IPutCost _putCost;
        private readonly IDeleteCost _deleteCost;

        public CostsController(IGetCost getCost,
                               IGetCostWithId getCostWithId,
                               IPostCost postCost,
                               IPutCost putCost,
                               IDeleteCost deleteCost)
        {
            _getCost = getCost;
            _getCostWithId = getCostWithId;
            _postCost = postCost;
            _putCost = putCost;
            _deleteCost = deleteCost;
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

        [EnableQuery]
        public IActionResult Post([FromBody]Cost cost)
        {
            return _postCost.PostCostMethod(cost);
        }

        [EnableQuery]
        public IActionResult Put(int key, [FromBody]PutCostModel putCostModel)
        {
            return _putCost.PutCostMethod(key, putCostModel);
        }

        [EnableQuery]
        public IActionResult Delete(int key)
        {
            return _deleteCost.DeleteCostMethod(key);
        }
    }
}
