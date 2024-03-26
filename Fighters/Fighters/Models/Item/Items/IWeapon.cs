using Fighters.Models.Dice;

namespace Fighters.Models.Item.Items
{
    public interface IWeapon : IItem
    {
        public IDice Dice { get; }
        public int DiceCount { get; }
        public int AttackBonus { get; set; }

        public int GenerateDamage()
        {
            DiceRoll roll = new DiceRoll(Dice, DiceCount);
            return roll.Roll();
        }
    }

    public class NoWeapon : IWeapon
    {
        public IDice Dice { get; } = new D4();
        public int DiceCount { get; } = 1;
        public int AttackBonus { get; set; } = 0;
        public string Name { get; set; } = "No weapon (1d4)";
    }
    public class ShortSword : IWeapon
    {
        public IDice Dice { get; } = new D8();
        public int DiceCount { get; } = 1;
        public int AttackBonus { get; set; } = 0;
        public string Name { get; set; } = "Short sword (1d8)";
    }
    public class LongSword : IWeapon
    {
        public IDice Dice { get; } = new D12();
        public int DiceCount { get; } = 1;
        public int AttackBonus { get; set; } = 0;
        public string Name { get; set; } = "Long sword (1d12)";
    }
    public class Dagger : IWeapon
    {
        public IDice Dice { get; } = new D4();
        public int DiceCount { get; } = 2;
        public int AttackBonus { get; set; } = 0;
        public string Name { get; set; } = "Dagger (2d4)";
    }
    public class ShortBow : IWeapon
    {
        public IDice Dice { get; } = new D6();
        public int DiceCount { get; } = 1;
        public int AttackBonus { get; set; } = 0;
        public string Name { get; set; } = "Short bow (1d6)";
    }
    public class LongBow : IWeapon
    {
        public IDice Dice { get; } = new D8();
        public int DiceCount { get; } = 1;
        public int AttackBonus { get; set; } = 0;
        public string Name { get; set; } = "Long bow (1d8)";
    }

    public class Weapons
    {
        public List<IWeapon> List = new List<IWeapon>
        {
            new NoWeapon(),
            new ShortSword(),
            new LongSword(),
            new Dagger(),
            new ShortBow(),
            new LongBow(),
        };
    }

}
