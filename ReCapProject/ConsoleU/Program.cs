using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace ReCapProject // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CustomerTest();
            //UserTest();
            //RentalTest();
        }

        private static void RentalTest()
        {
            IRentalService rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 11, 9) };
            Rental rental2 = new Rental { CarId = 5, CustomerId = 2, RentDate = new DateTime(2022, 11, 5) };
            Rental rental3 = new Rental { CarId = 2, CustomerId = 3, RentDate = new DateTime(2022, 11, 6) };
            Console.WriteLine(rentalManager.Add(rental1).Message);
            Console.WriteLine(rentalManager.Add(rental2).Message);
            Console.WriteLine(rentalManager.Add(rental3).Message);
        }

        private static void UserTest()
        {
            IUserService userManager = new UserManager(new EfUserDal());
            User user1 = new User { FirstName = "x", LastName = "a", Email = "x@gmail.com" };
            User user2 = new User { FirstName = "y", LastName = "b", Email = "y@gmail.com" };
            User user3 = new User { FirstName = "z", LastName = "b", Email = "z@gmail.com" };

            userManager.Add(user1);
            userManager.Add(user2);
            userManager.Add(user3);
        }

        private static void CustomerTest()
        {
            ICustomerService customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer1 = new Customer() { UserId = 1, CompanyName = "t." };
            Customer customer2 = new Customer() { UserId = 2, CompanyName = "y." };
            Customer customer3 = new Customer() { UserId = 3, CompanyName = "u." };

            Console.WriteLine(customerManager.Add(customer1).Message);
            Console.WriteLine(customerManager.Add(customer2).Message);
            Console.WriteLine(customerManager.Add(customer3).Message);
        }

        private static void CarTest()
        {
            ICarService carManager = new CarManager(new EfCarDal());
            //Car car1 = new Car{BrandId = 4, ColorId = 2, ModelYear = 2022, DailyPrice = 350, Description = "Togg" };
            //carManager.Add(car1);

            var getById = carManager.GetById(5);
            Console.WriteLine(getById.Data.Id + "   " + getById.Data.BrandId + "   " + getById.Data.ColorId + "   " + getById.Data.ModelYear + "   " + getById.Data.DailyPrice + "   " + getById.Data.Description);

            Console.WriteLine("CarId    BrandId    ColorId    ModelYear    DailyPrice    Description");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + "   " + car.BrandId + "   " + car.ColorId + "   " + car.ModelYear + "   " + car.DailyPrice + "   " + car.Description);
            }

            var result = carManager.GetCarDetail();
            if (result.Success)
            {
                Console.WriteLine("CarName    BrandName    ColorName    DailyPrice");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine();
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "   " + car.BrandName + "   " + car.ColorName + "   " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
