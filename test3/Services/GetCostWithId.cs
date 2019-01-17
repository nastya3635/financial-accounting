using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test3.Models;

namespace test3.Services
{
    public class GetCostWithId : ControllerBase, IGetCostWithId 
    {
        CostsContext db;
        public GetCostWithId(CostsContext context)
        {
            db = context;
        }

        public IActionResult GetCostWithIdMethod(int key)
        {
            if (!db.Costs.Any(x => x.Id == key))
            {
                return BadRequest("Такой записи не существует");
            }
            var costs = db.Costs.Include(p => p.Category)
            .Where(p => p.CategoryId == key)
            .Select(x => new GetCostModel() { Name = x.Name, Value = x.Value, Date = x.Date, CategoryName = x.Category.Name });
            return Ok(costs); 
        }
    }
}
