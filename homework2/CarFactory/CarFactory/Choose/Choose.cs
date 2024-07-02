using CarFactory.Factories.Cars;
using CarFactory.Factories.Cars.CarProperties.Body;
using CarFactory.Factories.Cars.CarProperties.Color;
using CarFactory.Factories.Cars.CarProperties.Engine;
using CarFactory.Factories.Cars.CarProperties.Model;
using CarFactory.Factories.Cars.CarProperties.Transmission;

namespace CarFactory.Choose
{
    public static class ChooseByConsoleInput
    {
        public static IBody ChooseBody(List<IBody> list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose body type index from the following list:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse( strIndex );
            }
            while (index <= 0 || index > list.Count);
            return list[index - 1];
        }
        public static IColor ChooseColor(List<IColor> list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose color index from the following list:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse(strIndex);
            }
            while (index <= 0 || index > list.Count);
            return list[index - 1];
        }
        public static IEngine ChooseEngine(List<IEngine> list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose engine index from the following list:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse(strIndex);
            }
            while (index <= 0 || index > list.Count);
            return list[index - 1];
        }
        public static IModel ChooseModel(List<IModel> list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose model index from the following list:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse(strIndex);
            }
            while (index <= 0 || index > list.Count);
            return list[index - 1];
        }
        public static ITransmission ChooseTransmission(List<ITransmission> list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose transmission index from the following list:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse(strIndex);
            }
            while (index <= 0 || index > list.Count);
            return list[index - 1];
        }
    }
}
