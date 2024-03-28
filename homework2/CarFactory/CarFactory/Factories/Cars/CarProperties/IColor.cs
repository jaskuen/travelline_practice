namespace CarFactory.Factories.Cars.CarProperties
{
    public interface IColor
    {
        public string Name { get; }
    }
    public class Red : IColor
    {
        public string Name { get; } = "Red";
    }
    public class Blue : IColor
    {
        public string Name { get; } = "Blue";
    }
    public class White : IColor
    {
        public string Name { get; } = "White";
    }
    public class Green : IColor
    {
        public string Name { get; } = "Green";
    }

    public class ColorList
    {
        public List<IColor> ObjList = new List<IColor>()
        {
            new Red(),
            new Blue(),
            new White(),
            new Green(),
        };
    }
}
