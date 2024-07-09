using CarFactory.Factories;
using CarFactory.Factories.Cars;
namespace CarFactory
{
    public partial class Program
    {
        public static void Main()
        {
            CarsFactory carsFactory = new();
            List<Car> carList = [carsFactory.CreateNewCar()];
            string strIndex;
            int index;
            bool exit = false;
            bool success;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Choose one of the options:" +
                                  "\n1. Create new car" +
                                  "\n2. List all cars" +
                                  "\n3. List info about certain car" +
                                  "\n4. Exit");
                
                success = int.TryParse(Console.ReadLine(), out index);
                while (!success && (index <= 0 || index > 4))
                {
                    success = int.TryParse(Console.ReadLine(), out index);
                }
                switch (index)
                {
                    case 1: carList.Add(carsFactory.CreateNewCar()); break;
                    case 2:
                        foreach (Car car in carList)
                        {
                            Console.WriteLine($"{carList.IndexOf(car) + 1}. {car.Name}, {car.Model.Name}");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter index of the car:");
                        success = int.TryParse(Console.ReadLine(), out index);
                        while (!success && (index <= 0 || index > carList.Count))
                        {
                            success = int.TryParse(Console.ReadLine(), out index);
                        }
                        Console.WriteLine(carList[index - 1].ToString());
                        Console.ReadLine();
                        break;
                    case 4:
                        exit = true;
                        break;
                        
                }
            }
        }
    }
}
