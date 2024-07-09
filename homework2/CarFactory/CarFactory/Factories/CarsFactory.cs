using System.Xml.Linq;
using CarFactory.Choose;
using CarFactory.Factories.Cars;
using CarFactory.Factories.Cars.CarProperties;
using CarFactory.Factories.Cars.CarProperties.Model;

namespace CarFactory.Factories
{
    public class CarsFactory : ICarsFactory
    {
        public Car CreateNewCar()
        {
            CarPropertyFactory carPropertyFactory = new();
            Car car = new(Console.ReadLine(),
                carPropertyFactory.CreateModel(),
                carPropertyFactory.CreateColor(),
                carPropertyFactory.CreateBody(),
                carPropertyFactory.CreateEngine(),
                carPropertyFactory.CreateTransmission());
            return car;
        }
    }
}
