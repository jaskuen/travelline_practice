namespace Fighters.Models.Item.Items.Armor
{

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
        public int Armor { get; set; } = 18;
    }
}
