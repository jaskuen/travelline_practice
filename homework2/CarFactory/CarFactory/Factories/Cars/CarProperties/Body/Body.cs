namespace CarFactory.Factories.Cars.CarProperties.Body
{
    public class Sedan : IBody
    {
        public string Name { get; } = "Sedan";
    }
    public class Coupe : IBody
    {
        public string Name { get; } = "Coupe";
    }
    public class PickUp : IBody
    {
        public string Name { get; } = "Pick up";
    }
}
