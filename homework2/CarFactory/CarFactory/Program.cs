using CarFactory.Factories;
namespace CarFactory
{
    public partial class Program
    {
        public static void Main()
        {
            var factory = new Factory();
            factory.CreateNewCar();
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
                    case 1: factory.CreateNewCar(); break;
                    case 2: factory.ListCars(); break;
                    case 3:
                        Console.WriteLine("Enter index of the car:");
                        success = int.TryParse(Console.ReadLine(), out index);
                        while (!success && (index <= 0 || index > factory.CarList.Count))
                        {
                            success = int.TryParse(Console.ReadLine(), out index);
                        }
                        factory.ListCarInfo(index);
                        break;
                    case 4:
                        exit = true;
                        break;
                        
                }
            }
        }
    }
}
