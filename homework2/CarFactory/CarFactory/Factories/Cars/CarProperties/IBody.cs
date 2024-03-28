namespace CarFactory.Factories.Cars.CarProperties
{
    public interface IBody
    {
        public string Name { get; }
    }
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

    public class BodyList
    {
        public List<IBody> ObjList = new List<IBody>()
        {
            new Sedan(),
            new Coupe(),
            new PickUp(),
        };
    }
}
