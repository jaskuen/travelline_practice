using CarFactory.Factories.Cars;
using CarFactory.Factories.Cars.CarProperties;

namespace CarFactory.Choose
{
    public class ChooseProperty
    {
        public IBody Choose(BodyList list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose body type from the following list:");
            for (int i = 0; i < list.ObjList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list.ObjList[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse( strIndex );
            }
            while (index <= 0 || index > list.ObjList.Count);
            return list.ObjList[index - 1];
        }
        public IColor Choose(ColorList list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose color from the following list:");
            for (int i = 0; i < list.ObjList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list.ObjList[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse(strIndex);
            }
            while (index <= 0 || index > list.ObjList.Count);
            return list.ObjList[index - 1];
        }
        public IEngine Choose(EngineList list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose engine from the following list:");
            for (int i = 0; i < list.ObjList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list.ObjList[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse(strIndex);
            }
            while (index <= 0 || index > list.ObjList.Count);
            return list.ObjList[index - 1];
        }
        public IModel Choose(ModelList list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose model from the following list:");
            for (int i = 0; i < list.ObjList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list.ObjList[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse(strIndex);
            }
            while (index <= 0 || index > list.ObjList.Count);
            return list.ObjList[index - 1];
        }
        public ITransmission Choose(TransmissionList list)
        {
            int index;
            string strIndex;
            Console.Clear();
            Console.WriteLine("Choose transmission from the following list:");
            for (int i = 0; i < list.ObjList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list.ObjList[i].Name}");
            }
            do
            {
                strIndex = Console.ReadLine();
                index = int.Parse(strIndex);
            }
            while (index <= 0 || index > list.ObjList.Count);
            return list.ObjList[index - 1];
        }
    }
}
