using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Created { get; set; }
    }
}
