namespace Fighters.Models.Item.Items
{
    public interface IRace : IItem
    {
        public int Armor { get; }
    }
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

    public class Races
    {
        public List<IRace> List { get; } = new List<IRace>()
        {
            new Human(),
            new Goblin(),
            new Elf(),
            new Dragonborn(),
        };
    }
}


