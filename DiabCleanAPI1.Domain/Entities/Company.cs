using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI
{
    public class Company
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Field { get; private set; }
        public List<Employee> Employees { get; } = new();

        public Company(string name, string field)
        {
            Name = name;
            Field = field;
        }
        public void Update(string name, string field)
        {
            Name = name;
            Field = field;
        }
    }
}
