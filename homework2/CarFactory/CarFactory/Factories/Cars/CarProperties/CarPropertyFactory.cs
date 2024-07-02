using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFactory.Choose;
using CarFactory.Factories.Cars.CarProperties.Body;
using CarFactory.Factories.Cars.CarProperties.Color;
using CarFactory.Factories.Cars.CarProperties.Engine;
using CarFactory.Factories.Cars.CarProperties.Model;
using CarFactory.Factories.Cars.CarProperties.Transmission;

namespace CarFactory.Factories.Cars.CarProperties
{
    public class CarPropertyFactory : ICarPropertyFactory
    {
        public CarPropertyFactory() 
        {
            Bodies = new List<IBody>()
            {
                new Sedan(),
                new Coupe(),
                new PickUp(),
            };
            Colors = new List<IColor>()
            {
                new Red(),
                new Blue(),
                new White(),
                new Green(),
            };
            Engines = new List<IEngine>()
            {
                new SlowEngine(),
                new MediumEngine(),
                new FastEngine(),
            };
            Models = new List<IModel>()
            {
                new Volvo(),
                new Lada(),
                new Mercedes(),
                new Toyota(),
            };
            Transmissions = new List<ITransmission>()
            {
                new BadTransmission(),
                new GoodTransmission(),
                new BestTransmission(),
            };
        }
        public List<IBody> Bodies { get; private set; }
        public List<IColor> Colors {  get; private set; }
        public List<IEngine> Engines { get; private set; }
        public List<IModel> Models { get; private set; }
        public List<ITransmission> Transmissions {  get; private set; } 

        public IBody CreateBody()
        {
            return ChooseByConsoleInput.ChooseBody(Bodies);
        }
        public IColor CreateColor()
        {
            return ChooseByConsoleInput.ChooseColor(Colors);
        }
        public IEngine CreateEngine()
        {
            return ChooseByConsoleInput.ChooseEngine(Engines);
        }
        public IModel CreateModel()
        {
            return ChooseByConsoleInput.ChooseModel(Models);
        }
        public ITransmission CreateTransmission()
        {
            return ChooseByConsoleInput.ChooseTransmission(Transmissions);
        }

    }
}
