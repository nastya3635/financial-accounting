using Entities;
using Microsoft.AspNetCore.Mvc;

namespace test3.Services
{
    public interface IDeleteCategory
    {
        IActionResult DeleteCategoryMethod(int key);
    }
}
