using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Item.Items;

namespace Fighters.Models.ChooseItems
{
    internal class Choose
    {
        public IRace Race()
        {
            Console.Clear();
            Console.WriteLine("Choose one of the following race: ");
            var raceList = new Races().List;
            for (int i = 0; i < raceList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {raceList[i].Name}");
            }
            string raceNumStr = Console.ReadLine();

            return raceList[Int32.Parse(raceNumStr) - 1];
        }
        public IClass Class()
        {
            Console.Clear();
            Console.WriteLine("Choose one of the following class: ");
            var classList = new Classes().List;
            for (int i = 0; i < classList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {classList[i].Name}");
            }
            string classNumStr = Console.ReadLine();

            return classList[Int32.Parse(classNumStr) - 1];
        }
        public int Level()
        {
            Console.Clear();
            int result = 0;
            while (result < 1)
            {
                Console.WriteLine("Enter character level:");
                string levelStr = Console.ReadLine();
                return int.Parse(levelStr);
            }
            throw new UnreachableException();
        }
        public IWeapon Weapon()
        {
            Console.Clear();
            Console.WriteLine("Choose one of the following weapon: ");
            var weaponList = new Weapons().List;
            for (int i = 0; i < weaponList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {weaponList[i].Name}");
            }
            string weaponNumStr = Console.ReadLine();

            return weaponList[Int32.Parse(weaponNumStr) - 1];
        }
        public IArmor Armor()
        {
            Console.Clear();
            Console.WriteLine("Choose one of the following armor: ");
            var armorList = new Armors().List;
            for (int i = 0; i < armorList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {armorList[i].Name}");
            }
            string armorNumStr = Console.ReadLine();

            return armorList[Int32.Parse(armorNumStr) - 1];
        }
    }
}
// понимаю, что у функций идентичная структура, но не придумал, как сделать общую функцию 
// (вылезают ошибки неправильного аргумента, когда пытался сделать общих класс-родитель и подать его)