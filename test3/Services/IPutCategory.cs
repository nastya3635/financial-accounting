using test3.Models;
using Microsoft.AspNetCore.Mvc;

namespace test3.Services
{
    public interface IPutCategory
    {
        IActionResult PutCategoryMethod(int key, [FromBody]PutCategoryModel putCategoryModel);
    }
}
