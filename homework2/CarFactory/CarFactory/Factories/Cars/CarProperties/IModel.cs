namespace CarFactory.Factories.Cars.CarProperties
{
    public interface IModel
    {
        public string Name { get; }
    }
    public class Volvo : IModel
    {
        public string Name { get; } = "Volvo";
    }
    public class Lada : IModel
    {
        public string Name { get; } = "Lada";
    }
    public class Mercedes : IModel
    {
        public string Name { get; } = "Mercedes";
    }
    public class Toyota : IModel
    {
        public string Name { get; } = "Toyota";
    }

    public class ModelList
    {
        public List<IModel> ObjList = new List<IModel>()
        {
            new Volvo(),
            new Lada(),
            new Mercedes(),
            new Toyota(),
        };
    }
}
