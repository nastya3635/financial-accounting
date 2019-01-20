using Entities;
using Microsoft.AspNetCore.Mvc;

namespace test3.Services
{
    public interface IPostCategory
    {
        IActionResult PostCategoryMethod([FromBody]Category category);
    }
}
