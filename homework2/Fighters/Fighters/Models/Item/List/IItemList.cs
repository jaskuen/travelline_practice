using System.Xml.Serialization;
using Fighters.Models.Item.Items;

namespace Fighters.Models.Item.List
{
    public class IItemList
    {
        public List<IRace> RaceList { get; private set; } = new Races().List;
        public List<IClass> ClassList { get; private set; } = new Classes().List;
        public List<IWeapon> WeaponList { get; private set; } = new Weapons().List;
        public List<IArmor> ArmorList { get; private set; } = new Armors().List;
    }
}
