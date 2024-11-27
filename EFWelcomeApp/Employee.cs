using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWelcomeApp
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; } = null!;
        public int? Age  { set; get; }
        public Company? Company {  set; get; }
    }
}
