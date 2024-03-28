using CarFactory.Choose;
using CarFactory.Factories.Cars;
using CarFactory.Factories.Cars.CarProperties;

namespace CarFactory.Factories
{
    public class Factory : IFactory
    {
        public List <Car> CarList { get; } = new List<Car>();
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
            CarList.Add(car);
            return car;
        }
        public void ListCars()
        {
            Console.Clear();
            for (int i = 0; i < CarList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {CarList[i].Name}");
            }
            Console.WriteLine("Press ENTER to continue:");
            Console.ReadLine();
        }
        public void ListCarInfo(int index)
        {
            Console.Clear();
            Car car = CarList[index - 1];
            Console.WriteLine($"Name: {car.Name}" +
                              $"\nModel: {car.Model.Name}" +
                              $"\nBody: {car.Body.Name}" +
                              $"\nEngine: {car.Engine.Name}" +
                              $"\n  Max speed: {car.Engine.MaxSpeed}" +
                              $"\nTransmission: {car.Transmission.Name}");
            Console.WriteLine("Press ENTER to continue:");
            Console.ReadLine();
        }
    }
}
