namespace Fighters.Models.Item.Items.Race
{
    public class Human : IRace
    {
        public string Name { get; set; } = "Human";
        public int Armor { get; } = 10;
    }

    public class Goblin : IRace
    {
        public string Name { get; set; } = "Goblin";
        public int Armor { get; } = 9;
    }

    public class Elf : IRace
    {
        public string Name { get; set; } = "Elf";
        public int Armor { get; } = 11;
    }

    public class Dragonborn : IRace
    {
        public string Name { get; set; } = "Dragonborn";
        public int Armor { get; } = 12;
    }
}


