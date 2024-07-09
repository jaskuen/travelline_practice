namespace CarFactory.Factories.Cars.CarProperties.Transmission
{

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
}
