using Data.Models;
using Data.Models.Interfaces;

namespace Data.Services
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        #region Seed
        public void Seed()
        {
            ctx.Add(new Student
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
            });
            ctx.Add(new Student
            {
                FirstName = "Mihai",
                LastName = "Mihailescu",
                Age = 15,
                Address = new Address
                {
                    City = "Bucuresti",
                    Street = "Triumfului",
                    Number = 124
                }
            });
            ctx.Add(new Student
            {
                FirstName = "George",
                LastName = "Georgescu",
                Age = 15,
                Address = new Address
                {
                    City = "Iasi",
                    Street = "Modestiei",
                    Number = 15
                }
            });
            ctx.Add(new Student
            {
                FirstName = "Marius",
                LastName = "Popescu",
                Age = 15,
                Address = new Address
                {
                    City = "Suceava",
                    Street = "Prunului",
                    Number = 37
                }
            });
            ctx.Add(new Student
            {
                FirstName = "Ionut",
                LastName = "Panait",
                Age = 15,
                Address = new Address
                {
                    City = "Galati",
                    Street = "Navigatiei",
                    Number = 92
                }
            });
            ctx.Add(new Student
            {
                FirstName = "Adrian",
                LastName = "Avramescu",
                Age = 15,
                Address = new Address
                {
                    City = "Botosani",
                    Street = "Amintirii",
                    Number = 132
                }
            });

            ctx.SaveChanges();
        }
        #endregion
    }
}
