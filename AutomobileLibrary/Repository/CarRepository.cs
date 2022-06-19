using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public Car GetCarById(int carId) => CarDbContext.Instance.GetCarById(carId);
        public IEnumerable<Car> GetCars() => CarDbContext.Instance.GetCars;
        public void InsertCar(Car car) => CarDbContext.Instance.AddNew(car);
        public void DeleteCar(int carId) => CarDbContext.Instance.Remove(carId);
        public void UpdateCar(Car car) => CarDbContext.Instance.Update(car);

    }
}
