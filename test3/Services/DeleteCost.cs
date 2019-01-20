using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Microsoft.AspNet.OData;

namespace test3.Services
{
    public class DeleteCost : ODataController, IDeleteCost
    {
        CostsContext db;
        public DeleteCost(CostsContext context)
        {
            db = context;
        }

        public IActionResult DeleteCostMethod(int key)
        {
            Cost cost = db.Costs.FirstOrDefault(x => x.Id == key);
            if (cost == null)
            {
                return BadRequest("Запись с таким id не найдена");
            }
            db.Costs.Remove(cost);
            db.SaveChanges();
            return Ok("Запрос DELETE успешно выполнен");
        }
    }
}
