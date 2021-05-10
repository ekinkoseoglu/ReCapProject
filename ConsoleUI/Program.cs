using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICarDal inMemoryCarDal = new InMemoryCarDal();

            //CarManager carManager = new CarManager(inMemoryCarDal);
            //inMemoryCarDal.Add(new Car { Id = 6, BrandId = 5, ColorId = 2, DailyPrice = 999000, ModelYear = "2021", Description = "White Tesle Model S" }); // Added Tesla
            //Console.WriteLine("Number Of Cars: {0}", carManager.GetAll().Count);


            //foreach (var x in carManager.GetAll())
            //{
            //    Console.WriteLine($"Car Brand: {x.BrandId} -- Model: {x.ModelYear} -- Price: {x.DailyPrice} -- Color Code: {x.ColorId} -- Description: {x.Description}");
            //}


            //Console.WriteLine("------------------");

            //inMemoryCarDal.Delete(new Car{ Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 20000, ModelYear = "2010", Description = "Black Ford Focus" }); // Deleted Ford Focus (Id 1)
            //Console.WriteLine("Number of Cars : {0}",carManager.GetAll().Count);
            //foreach (var x in carManager.GetAll())
            //{
            //    Console.WriteLine($"Car Brand: {x.BrandId} -- Model: {x.ModelYear} -- Price: {x.DailyPrice} -- Color Code: {x.ColorId} -- Description: {x.Description}");
            //}

            EfCarDal efCarDal = new EfCarDal();
            CarManager efCarManager = new CarManager(efCarDal);

            Car carornek3 = new Car()
            {
                ColorId = 2,Details = "Volkswagen Jetta", DailyPrice = 20000,ModelYear = "2019",BrandId = 2,CarId = 2008
            };
            //efCarDal.Update(carornek);
            //foreach (var x in efCarManager.GetAll())
            //{
            //    Console.WriteLine(x.Details+" "+x.CarId);
            
            //}

            Console.WriteLine("---------");
            efCarManager.Update(carornek3);
            //efCarManager.Delete(1011); // It deletes the car for Carid Number
            foreach (var x in efCarManager.GetAll())
            {
                Console.WriteLine(x.Details + " " + x.CarId);
            }
        }
    }
}
