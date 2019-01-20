using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;

namespace test3.Services
{
    public class PostCategory : ODataController, IPostCategory
    {
        CostsContext db;
        public PostCategory(CostsContext context)
        {
            db = context;
        }

        public IActionResult PostCategoryMethod([FromBody]Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            db.Categories.Add(category);
            db.SaveChanges();
            return Created(category);
        }
    }
}