using Microsoft.AspNetCore.Mvc;
using Entities;

namespace test3.Services
{
    public interface IPostCost
    {
        IActionResult PostCostMethod([FromBody]Cost cost);
    }
}

