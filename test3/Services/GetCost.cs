using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using test3.Models;

namespace test3.Services
{
    public class GetCost : IGetCost
    {
        CostsContext db;
        public GetCost(CostsContext context)
        {
            db = context;
        }

        public List<GetCostModel> GetCostMethod()
        {
            var costs = db.Costs.Include(p => p.Category)
            .Select(x => new GetCostModel() { Name = x.Name, Value = x.Value, Date = x.Date, CategoryName = x.Category.Name });
            return costs.ToList();
        }
    }
}
