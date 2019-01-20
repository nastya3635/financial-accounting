using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace test3.Services
{
    public class DeleteCategory : ODataController, IDeleteCategory
    {
        CostsContext db;
        public DeleteCategory(CostsContext context)
        {
            db = context;
        }

        public IActionResult DeleteCategoryMethod(int key)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == key);
            if (category == null)
            {
                return BadRequest("Запись с таким id не найдена");
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return Ok("Запрос DELETE успешно выполнен");
        }
    }
}
