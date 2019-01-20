using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.AspNet.OData;

namespace test3.Services
{
    public class GetCategory : ODataController, IGetCategory
    {
        CostsContext db;
        public GetCategory(CostsContext context)
        {
            db = context;
        }

        public List<Category> GetCategoryMethod()
        {
            return db.Categories.ToList();
        }
    }
}
