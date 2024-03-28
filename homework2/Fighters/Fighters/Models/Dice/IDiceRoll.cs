namespace Fighters.Models.Dice
{
    public interface IDiceRoll
    {
        public IDice Dice { get; set; }
        public int DiceCount { get; set; }
        public int Roll();
    }

    public class DiceRoll(IDice dice, int diceCount)
    {
        public IDice Dice { get; set; } = dice;
        public int DiceCount { get; set; } = diceCount;
        public int Roll()
        {
            Random random = new Random();
            int result = 0;
            for (int i = 0; i < DiceCount; i++)
            {
                result += random.Next(Dice.DiceType) + 1;
            }
            return result;
        }
    }
}
