using System.Collections.Generic;
using Entities;


namespace test3.Services
{
    public interface IGetCategoryWithId
    {
        List<Category> GetCategoryWithIdMethod(int key);
    }
}
