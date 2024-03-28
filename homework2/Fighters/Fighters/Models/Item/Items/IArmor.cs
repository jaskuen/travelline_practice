namespace Fighters.Models.Item.Items
{
    public interface IArmor : IItem
    {
        public int Armor { get; internal set; }
    }

    public class NoArmor : IArmor
    {
        public string Name { get; } = "No armor (10 + constitution modificator AC)";
        public int Armor { get; set; } = 10;
    }

    public class LeatherArmor : IArmor
    {
        public string Name { get; } = "Leather armor (12 AC)";
        public int Armor { get; set; } = 12;
    }
    public class LightIronArmor : IArmor
    {
        public string Name { get; } = "Light iron armor (15 AC)";
        public int Armor { get; set; } = 15;
    }
    public class HeavyIronArmor : IArmor
    {
        public string Name { get; } = "Heavy iron armor (18 AC)";
        public int Armor { get; set; } = 12;
    }
    public class Armors
    {
        public List<IArmor> List { get; set; } = new List<IArmor>()
            {
                new NoArmor(),
                new LeatherArmor(),
                new LightIronArmor(),
                new HeavyIronArmor(),
            };
    };
}
