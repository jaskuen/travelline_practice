using CarFactory.Factories.Cars.CarProperties.Model;
using CarFactory.Factories.Cars.CarProperties.Color;
using CarFactory.Factories.Cars.CarProperties.Body;
using CarFactory.Factories.Cars.CarProperties.Engine;
using CarFactory.Factories.Cars.CarProperties.Transmission;

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
    }
}
