using Fighters.Models.Dice;

namespace Fighters.Models.Item.Items
{
    public interface IClass : IItem
    {
        public IDice HealthDice { get; }
    }

    public class Warrior : IClass
    {
        public string Name { get; } = "Warrior";
        public IDice HealthDice { get; } = new D10();
    }
    public class Barbarian : IClass
    {
        public string Name { get; } = "Barbarian";
        public IDice HealthDice { get; } = new D12();
    }
    public class Ranger : IClass
    {
        public string Name { get; } = "Ranger";
        public IDice HealthDice { get; } = new D6();
    }

    public class Classes
    {
        public List<IClass> List = new List<IClass>()
        {
            new Warrior(),
            new Barbarian(),
            new Ranger(),
        };
    }
}
