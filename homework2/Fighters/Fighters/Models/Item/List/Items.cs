using System.Xml.Serialization;
using Fighters.Models.Item.Items.Armor;
using Fighters.Models.Item.Items.Class;
using Fighters.Models.Item.Items.Race;
using Fighters.Models.Item.Items.Weapon;

namespace Fighters.Models.Item.List
{
    public static class Items
    {
        public static List<IRace> Races { get; private set; } = new List<IRace>()
        {
            new Human(),
            new Goblin(),
            new Elf(),
            new Dragonborn(),
        };
        public static List<IClass> Classes { get; private set; } = new List<IClass>()
        {
            new Warrior(),
            new Barbarian(),
            new Ranger(),
        };
        public static List<IWeapon> Weapons { get; private set; } = new List<IWeapon>
        {
            new NoWeapon(),
            new ShortSword(),
            new LongSword(),
            new Dagger(),
            new ShortBow(),
            new LongBow(),
        };
        public static List<IArmor> Armors { get; private set; } = new List<IArmor>()
        {
            new NoArmor(),
            new LeatherArmor(),
            new LightIronArmor(),
            new HeavyIronArmor(),
        };
    }
}
