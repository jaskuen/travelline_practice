using CarFactory.Factories.Cars.CarProperties.Body;
using CarFactory.Factories.Cars.CarProperties.Color;
using CarFactory.Factories.Cars.CarProperties.Engine;
using CarFactory.Factories.Cars.CarProperties.Model;
using CarFactory.Factories.Cars.CarProperties.Transmission;

namespace CarFactory.Factories.Cars.CarProperties
{
    public interface ICarPropertyFactory
    {
        public List<IBody> Bodies { get; }
        public List<IColor> Colors { get; }
        public List<IEngine> Engines { get; }
        public List<IModel> Models { get; }
        public List<ITransmission> Transmissions { get; }
        public IBody CreateBody();
        public IColor CreateColor();
        public IEngine CreateEngine();
        public IModel CreateModel();
        public ITransmission CreateTransmission();
    }
}
