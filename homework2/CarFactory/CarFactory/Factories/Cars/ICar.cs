using System.Runtime.CompilerServices;
using CarFactory.Factories.Cars.CarProperties;
using CarFactory.Choose;

namespace CarFactory.Factories.Cars
{
    public interface ICar
    {
        public string Name { get; }
        public IModel Model { get; }
        public IColor Color { get; }
        public IBody Body { get; }
        public IEngine Engine { get; }
        public ITransmission Transmission { get; }
        public void SetName(string name);
        public void SetModel(IModel model);
        public void SetColor(IColor color);
        public void SetBody(IBody body);
        public void SetEngine(IEngine engine);
        public void SetTransmission(ITransmission transmission);
    }

    public class Car : ICar
    {
        public string Name { get; private set; }
        public IModel Model { get; private set; }
        public IColor Color { get; private set; }
        public IBody Body { get; private set; }
        public IEngine Engine { get; private set; }
        public ITransmission Transmission { get; private set; }
        
        public void SetName(string name)
        {
            Name = name; 
        }
        public void SetModel(IModel model)
        {
            Model = model;
        }
        public void SetColor(IColor color)
        {
            Color = color;
        }
        public void SetBody(IBody body)
        {
            Body = body;    
        }

        public void SetEngine(IEngine engine)
        {
            Engine = engine;
        }
        public void SetTransmission(ITransmission transmission)
        {
            Transmission = transmission;
        }

    }
}
