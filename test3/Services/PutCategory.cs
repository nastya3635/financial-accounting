using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test3.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace test3.Services
{
    public class PutCategory : ODataController, IPutCategory
    {
        CostsContext db;
        public PutCategory(CostsContext context)
        {
            db = context;
        }

        public IActionResult PutCategoryMethod(int key, [FromBody]PutCategoryModel putCategoryModel)
        {
            if (!db.Categories.Any(x => x.Id == key))
            {
                return BadRequest("Такой записи не существует");
            }
            var oldCategory = db.Categories.First(p => p.Id == key);
            oldCategory.Name = putCategoryModel.Name;
            db.SaveChanges();
            return Ok("Запрос UPDATE успешно выполнен");
        }
    }
}
