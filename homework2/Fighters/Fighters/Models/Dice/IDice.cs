namespace Fighters.Models.Dice
{
    public interface IDice
    {
        public int DiceType { get; }
    }
    public class D20 : IDice
    {
        public int DiceType { get; } = 20;
    }
    public class D12 : IDice
    {
        public int DiceType { get; } = 12;
    }
    public class D10 : IDice
    {
        public int DiceType { get; } = 10;
    }
    public class D8 : IDice
    {
        public int DiceType { get; } = 8;
    }
    public class D6 : IDice
    {
        public int DiceType { get; } = 6;
    }
    public class D4 : IDice
    {
        public int DiceType { get; } = 4;
    }
}
