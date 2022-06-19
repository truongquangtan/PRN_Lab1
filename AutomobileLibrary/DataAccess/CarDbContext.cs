using AutomobileLibrary.BussinessObject;

namespace AutomobileLibrary.DataAccess
{
    public class CarDbContext
    {
        //Initialize
        private static List<Car> CarList = new List<Car>()
        {
            new Car
            {
                CarId = 1,
                CarName = "CRV",
                Manufacturer = "Honda",
                Price = 30000,
                ReleaseYear = 2021
            },
            new Car
            {
                CarId = 2,
                CarName = "Ford Focus",
                Manufacturer = "Ford",
                Price = 15000,
                ReleaseYear = 2020
            }
        };

        //Singleton Pattern
        private static CarDbContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDbContext() { }
        public static CarDbContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new CarDbContext();
                    }
                    return instance;
                }
            }
        }

        //--Methods

        public List<Car> GetCars => CarList;

        public Car GetCarById(int carId)
        {
            Car? car = CarList.SingleOrDefault(car => car.CarId == carId);
            return car;
        }

        public void AddNew(Car car)
        {
            Car pro = GetCarById(car.CarId);
            if(pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car is already exists");
            }
        }

        public void Update(Car car)
        {
            Car pro = GetCarById(car.CarId);
            if(pro != null)
            {
                var index = CarList.IndexOf(pro);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }

        public void Remove(int carId)
        {
            Car car = GetCarById(carId);
            if(car != null)
            {
                CarList.Remove(car);
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }    
        }    
    }
}
