using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;

namespace test3.Services
{
    public class PutCost : ODataController, IPutCost
    {
        CostsContext db;
        public PutCost(CostsContext context)
        {
            db = context;
        }

        public IActionResult PutCostMethod(int key, [FromBody]PutCostModel putCostModel)
        {
            if (!db.Costs.Any(x => x.Id == key))
            {
                return BadRequest("Такой записи не существует");
            }

            if (!db.Categories.Any(x => x.Id == putCostModel.CategoryId))
            {
                return BadRequest("Такой категории не существует");
            }

            var oldCost = db.Costs.First(p => p.Id == key);
            oldCost.Name = putCostModel.Name;
            oldCost.Value = putCostModel.Value;
            oldCost.Date = putCostModel.Date;
            oldCost.CategoryId = putCostModel.CategoryId;
            db.SaveChanges();

            return Ok("Запрос UPDATE успешно выполнен");

        }
    }
}
