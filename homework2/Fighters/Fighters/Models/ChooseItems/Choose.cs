using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Tools;
using Fighters.Models.Item;
using Fighters.Models.Item.Items.Armor;
using Fighters.Models.Item.Items.Class;
using Fighters.Models.Item.Items.Race;
using Fighters.Models.Item.Items.Weapon;
using Fighters.Models.Item.List;

namespace Fighters.Models.ChooseItems
{
    internal class Choose
    {
        public int Level()
        {
            Console.Clear();
            Console.WriteLine("Enter character level:");
            int result = 0;
            while (!Int32.TryParse(Console.ReadLine(), out result) || result < 1)
            {
                Console.WriteLine("Wrong number");
            }
            return result;
        }
        public int ChooseItem(string itemName)
        {
            List<string> itemNamesList = new List<string>();
            switch (itemName)
            {
                case "armor":
                    List<IArmor> armorList = Items.Armors;
                    foreach (IArmor armor in armorList)
                    {
                        itemNamesList.Add(armor.Name);
                    }
                    break;
                case "race":
                    List<IRace> raceList = Items.Races;
                    foreach (IRace race in raceList)
                    {
                        itemNamesList.Add(race.Name);
                    }
                    break;
                case "class":
                    List<IClass> classList = Items.Classes;
                    foreach (IClass @class in classList)
                    {
                        itemNamesList.Add(@class.Name);
                    }
                    break;
                case "weapon":
                    List<IWeapon> weaponList = Items.Weapons;
                    foreach (IWeapon weapon in weaponList)
                    {
                        itemNamesList.Add(weapon.Name);
                    }
                    break;
            }
            Console.Clear();
            Console.WriteLine($"Choose one of the foolowing {itemName}:");
            int result = MakeChoice(itemNamesList);
            while (result >= itemNamesList.Count || result < 0)
            {
                Console.WriteLine("Incorrect number entered");
                result = MakeChoice(itemNamesList);
            }
            return result;
        }
        private int MakeChoice(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
            return Tools.Tools.ConsoleRead() - 1;
        }
    }
}
// понимаю, что у функций идентичная структура, но не придумал, как сделать общую функцию 
// (вылезают ошибки неправильного аргумента, когда пытался сделать общих класс-родитель и подать его)