namespace CarFactory.Factories.Cars.CarProperties
{
    public interface IEngine
    {
        public string Name { get; }
        public int MaxSpeed { get; }
    }
    public class SlowEngine : IEngine
    {
        public string Name { get; } = "Slow engine";
        public int MaxSpeed { get; } = 70;
    }
    public class MediumEngine : IEngine
    {
        public string Name { get; } = "Medium engine";
        public int MaxSpeed { get; } = 150;
    }
    public class FastEngine : IEngine
    {
        public string Name { get; } = "Fast engine";
        public int MaxSpeed { get; } = 290;
    }

    public class EngineList
    {
        public List<IEngine> ObjList = new List<IEngine>()
        {
            new SlowEngine(),
            new MediumEngine(),
            new FastEngine(),
        };
    }
}