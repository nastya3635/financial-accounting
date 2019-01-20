using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using test3.Services;
using test3.Models;
using Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test3.Controllers
{
    public class CategoriesController : ODataController
    {
        private readonly IGetCategory _getCategory;
        private readonly IGetCategoryWithId _getCategoryWithId;
        private readonly IPostCategory _postCategory;
        private readonly IPutCategory _putCategory;
        private readonly IDeleteCategory _deleteCategory;

        public CategoriesController(IGetCategory getCategory,
                                    IGetCategoryWithId getCategoryWithId,
                                    IPostCategory postCategory,
                                    IPutCategory putCategory,
                                    IDeleteCategory deleteCategory)
        {
            _getCategory = getCategory;
            _getCategoryWithId = getCategoryWithId;
            _postCategory = postCategory;
            _putCategory = putCategory;
            _deleteCategory = deleteCategory;
        }

        [EnableQuery]
        public List<Category> Get()
        {
            return _getCategory.GetCategoryMethod();
        }

        [EnableQuery]
        public List<Category> Get(int key)
        {
            return _getCategoryWithId.GetCategoryWithIdMethod(key);
        }

        [EnableQuery]
        public IActionResult Post([FromBody]Category category)
        {
            return _postCategory.PostCategoryMethod(category);
        }

        [EnableQuery]
        public IActionResult Put(int key, [FromBody]PutCategoryModel putCategoryModel)
        {
            return _putCategory.PutCategoryMethod(key, putCategoryModel);
        }

        [EnableQuery]
        public IActionResult Delete(int key)
        {
            return _deleteCategory.DeleteCategoryMethod(key);
        }
    }
}
