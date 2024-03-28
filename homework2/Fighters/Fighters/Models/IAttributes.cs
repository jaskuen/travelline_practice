namespace Fighters.Models
{
    public interface IAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        //public int Intelligence { get; }
        //public int Wisdom { get; }
        //public int Charisma { get; }
        public void SetAttributes(int s, int d, int c);
    }

    public class Attributes : IAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public void SetAttributes(int s, int d, int c)
        {
            Strength = s;
            Dexterity = d;
            Constitution = c;
        }
    }
}
