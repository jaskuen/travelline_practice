using CarFactory.Factories.Cars;

namespace CarFactory.Factories
{
    public interface ICarsFactory
    {
        public Car CreateNewCar();
    }
}
