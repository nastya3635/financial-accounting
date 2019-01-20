using Microsoft.AspNetCore.Mvc;

namespace test3.Services
{
    public interface IDeleteCost
    {
        IActionResult DeleteCostMethod(int key);
    }
}
