using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Microsoft.AspNet.OData;

namespace test3.Services
{
    public class PostCost : ODataController, IPostCost
    {
        CostsContext db;
        public PostCost(CostsContext context)
        {
            db = context;
        }

        public IActionResult PostCostMethod([FromBody]Cost cost)
        {
            if (cost == null)
            {
                return BadRequest();
            }

            cost.Created = DateTime.UtcNow;
            db.Costs.Add(cost);
            db.SaveChanges();
            return Created(cost);
        }
    }
}