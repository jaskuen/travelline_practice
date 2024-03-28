using System.Reflection.Metadata.Ecma335;
using Fighters.Models.Dice;
using Fighters.Models.Item.Items;

namespace Fighters.Models
{
    public interface IFighter
    {
        public string Name { get; }
        public int Level { get; }
        public IRace Race { get; }
        public IClass Class { get; }
        public int MaxHealth { get; }
        public int CurrentHealth { get; }
        public IWeapon Weapon { get; }
        public IArmor Armor { get; }
        public void TakeDamage(int damage);
        public int CalculateDamage();
    }
    public class Fighter : IFighter
    {
        public string Name { get; }
        public int Level { get; private set; }
        public IAttributes Attributes { get; private set; }
        public IRace Race { get; }
        public IClass Class { get; }
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public IWeapon Weapon { get; private set; }
        public IArmor Armor { get; private set; }
        public DiceRoll D20RollDice { get; private set; } = new DiceRoll(new D20(), 1);
        public int Initiative { get; set; } = 0;
        public bool Dead { get; set; } = false;
        public Fighter(string name, IRace race, IClass _class, int level, IWeapon weapon, IArmor armor)
        {
            Name = name;
            Race = race;
            Class = _class;
            Level = level;
            DiceRoll rollAttributes = new DiceRoll(new D4(), Level / 3); // за каждые 3 уровня будет кидаться кубик 1d4 на каждую характеристику
            Attributes = new Attributes()
            {
                Strength = 16 + rollAttributes.Roll(),
                Dexterity = 15 + rollAttributes.Roll(),
                Constitution = 13 + rollAttributes.Roll(),
            };
            DiceRoll rollHealth = new DiceRoll(Class.HealthDice, Level - 1); // каждый новый уровень кидается кость хита персонажа
            MaxHealth = Class.HealthDice.DiceType + rollHealth.Roll(); // первый уровень - кол-во хитов равно макс значению кости хитов
            CurrentHealth = MaxHealth;
            Weapon = weapon;
            Weapon.AttackBonus += (Attributes.Dexterity - 10) / 2;
            Armor = armor;
            if (armor == new NoArmor())
            {
                Armor.Armor += (Attributes.Constitution - 10) / 2;
            }
        }

        public int CalculateDamage()
        {
            DiceRoll roll = new DiceRoll(Weapon.Dice, Weapon.DiceCount);
            return roll.Roll() + Weapon.AttackBonus;
        }
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }
    }
}
