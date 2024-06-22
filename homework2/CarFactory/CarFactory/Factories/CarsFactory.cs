using CarFactory.Choose;
using CarFactory.Factories.Cars;
using CarFactory.Factories.Cars.CarProperties;

namespace CarFactory.Factories
{
    public class CarsFactory : ICarsFactory
    {
        public Car CreateNewCar()
        {
            ChooseProperty choice = new();
            Car car = new();
            Console.WriteLine("Enter car name:");
            car.SetName(Console.ReadLine());
            car.SetModel(choice.Choose(new ModelList()));
            car.SetColor(choice.Choose(new ColorList()));
            car.SetBody(choice.Choose(new BodyList()));
            car.SetEngine(choice.Choose(new EngineList()));
            car.SetTransmission(choice.Choose(new TransmissionList()));
            return car;
        }
    }
}
