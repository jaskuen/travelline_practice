using Fighters.Models.Dice;

namespace Fighters.Models.Item.Items.Class
{

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
}
