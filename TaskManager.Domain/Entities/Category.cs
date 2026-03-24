using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
