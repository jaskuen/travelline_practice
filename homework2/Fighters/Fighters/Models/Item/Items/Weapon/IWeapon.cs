using Fighters.Models.Dice;

namespace Fighters.Models.Item.Items.Weapon
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

}
