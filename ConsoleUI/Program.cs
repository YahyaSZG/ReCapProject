using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            AddRentalTest();
            //AddCustomerTest();
            //AddUserTest();
            //BrandManagerTest();
            //CarManagerTest();
        }

        private static void AddCustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                Creator = "yahya",
                CreateTime = DateTime.Now,
                UserId = 1,
                CompanyName = "yahya ltd."
            });
        }

        private static void AddRentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                Creator = "yahya",
                CreateTime = DateTime.Now,
                CarID = 1,
                CustomerID = 1,
                RentDate = DateTime.Now
            });
        }

        private static void AddUserTest()
        {
            UserManager adduser = new UserManager(new EfUserDal());
            adduser.Add(new User
            {
                FirstName = "yahyaaa",
                LastName = "sezgin"
            });
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine("Brand Name: " + item.BrandName + " Car Name: " + item.CarName + " Color Name: " + item.ColorName);
                }
            }
        }
    }
}
