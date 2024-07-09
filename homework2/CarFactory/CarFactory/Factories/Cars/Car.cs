using System.Runtime.CompilerServices;
using CarFactory.Choose;
using CarFactory.Factories.Cars.CarProperties.Model;
using CarFactory.Factories.Cars.CarProperties.Color;
using CarFactory.Factories.Cars.CarProperties.Body;
using CarFactory.Factories.Cars.CarProperties.Engine;
using CarFactory.Factories.Cars.CarProperties.Transmission;

namespace CarFactory.Factories.Cars
{

    public class Car : ICar
    {
        public Car(string name, IModel model, IColor color, IBody body, IEngine engine, ITransmission transmission) 
        { 
            Name = name;
            Model = model;
            Color = color;
            Body = body;
            Engine = engine;
            Transmission = transmission;
        }
        public string Name { get; private set; }
        public IModel Model { get; private set; }
        public IColor Color { get; private set; }
        public IBody Body { get; private set; }
        public IEngine Engine { get; private set; }
        public ITransmission Transmission { get; private set; }

        public override string ToString()
        {
            return $"""
                        Name: {Name}
                        Model: {Model.Name}
                        Body: {Body.Name}
                        Color: {Color.Name}
                        Engine: {Engine.Name}
                        Transmission: {Transmission.Name}
                    """;
        }

    }
}
