using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using test3.Models;

namespace test3.Services
{
    public interface IGetCostWithId
    {
        IActionResult GetCostWithIdMethod(int key);
    }
}