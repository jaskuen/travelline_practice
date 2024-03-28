using CarFactory.Factories.Cars;

namespace CarFactory.Factories
{
    public interface IFactory
    {
        public List<Car> CarList { get; }
        public Car CreateNewCar();
        public void ListCars();
        public void ListCarInfo(int index);
    }
}
