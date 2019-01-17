using System;
using System.Linq;
using Entities;

namespace test3.Initialize
{
    public class SampleData
    {
        public static void Initialize(CostsContext context)
        {
            if (!context.Costs.Any() && !context.Categories.Any())
            {
                {

                    context.Costs.Add(new Cost { Name = "Бананы", Value = 89, Date = new DateTime(2018, 11, 1), CategoryId = 1, Created = DateTime.UtcNow });
                    context.Costs.Add(new Cost { Name = "За квартиру", Value = 15000, Date = new DateTime(2018, 11, 10), CategoryId = 2, Created = DateTime.UtcNow });
                    context.Categories.Add(new Category { Name = "Еда" });
                    context.Categories.Add(new Category { Name = "Аренда" });
                    context.SaveChanges();
                }
            }
        }
    }
}
