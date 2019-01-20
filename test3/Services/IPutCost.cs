using test3.Models;
using Microsoft.AspNetCore.Mvc;

namespace test3.Services
{
    public interface IPutCost
    {
        IActionResult PutCostMethod(int key, [FromBody]PutCostModel putCostModel);
    }
}

