namespace CarFactory.Factories.Cars.CarProperties
{
    public interface ITransmission
    {
        public string Name { get; }
        public int GearCount { get; }
    }

    public class BadTransmission : ITransmission
    {
        public string Name { get; } = "Bad transmission";
        public int GearCount { get; } = 2;
    }
    public class GoodTransmission : ITransmission
    {
        public string Name { get; } = "Good transmission";
        public int GearCount { get; } = 4;
    }
    public class BestTransmission : ITransmission
    {
        public string Name { get; } = "The best transmission";
        public int GearCount { get; } = 6;
    }

    public class TransmissionList
    {
        public List<ITransmission> ObjList = new List<ITransmission>()
        {
            new BadTransmission(),
            new GoodTransmission(),
            new BestTransmission(),
        };
    }
}
