using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.AspNet.OData;

namespace test3.Services
{
    public class GetCategoryWithId : ODataController, IGetCategoryWithId
    {
        CostsContext db;
        public GetCategoryWithId(CostsContext context)
        {
            db = context;
        }

        public List<Category> GetCategoryWithIdMethod(int key)
        {
            return db.Categories.Where(p => p.Id == key).ToList();
        }
    }
}
