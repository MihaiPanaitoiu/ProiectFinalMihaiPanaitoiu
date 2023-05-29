using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public partial class DataAccessLayerSingletonSeed
    {
        public void Seed()
        {
            using var ctx = new SchoolDbContext();
            var s1 = new Student
            {
                FirstName = "Ionica",
                LastName = "Ionel",
                Age = 15,
                Address = new Address
                {
                    City = "Bucuresti",
                    Street = "Minervei",
                    Number = 13
                }
            };
        }
    }
}
