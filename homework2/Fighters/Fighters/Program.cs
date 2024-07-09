using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;
using System.Xml.Serialization;
using Fighters.Models;
using Fighters.Models.ChooseItems;
using Fighters.Models.Item;
using Fighters.Models.Item.Items.Armor;
using Fighters.Models.Item.Items.Class;
using Fighters.Models.Item.Items.Race;
using Fighters.Models.Item.Items.Weapon;
using Fighters.Models.Item.List;

namespace Fighters
{
    public class FighterFactory
    {
        private Fighter CreateFighter()
        {
            Choose choose = new Choose();
            Console.WriteLine("Enter fighter name:");
            string name = Console.ReadLine();
            IRace race = Items.Races.ElementAt(choose.ChooseItem("race"));
            IClass @class = Items.Classes.ElementAt(choose.ChooseItem("class"));
            int level = choose.Level();
            IWeapon weapon = Items.Weapons.ElementAt(choose.ChooseItem("weapon"));
            IArmor armor = Items.Armors.ElementAt(choose.ChooseItem("armor"));
            return new Fighter(name, race, @class, level, weapon, armor);
        }
        public List<Fighter> ReadFighters()
        {
            List<Fighter> fighters = new List<Fighter>();
            Console.WriteLine("Enter number of fighters:");
            string countStr = Console.ReadLine();
            int count = Int32.Parse(countStr);
            for (int i = 0; i < count; i++)
            {
                Console.Clear();
                fighters.Add(CreateFighter());
            }
            return fighters;
        }
    }
    public static class Program
    {
        static void Swap(this List<Fighter> list, int index1, int index2)
        {
            Fighter temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
        static void SortFightersByInitiative(this List<Fighter> fighters)
        {
            for (int i = 0; i < fighters.Count(); i++)
            {
                fighters[i].Initiative = fighters[i].D20RollDice.Roll() + (fighters[i].Attributes.Dexterity - 10) / 2;
                Console.WriteLine($"Player {fighters[i].Name} got {fighters[i].Initiative} at a initiative roll!");
            }
            bool notSorted = false;
            do
            {
                notSorted = false;
                for (int i = 0; i < fighters.Count() - 1; i++)
                {
                    if (fighters[i].Initiative < fighters[i + 1].Initiative)
                    {
                        fighters.Swap(i, i + 1);
                        notSorted = true;
                    }
                }
            }
            while (notSorted);

        }
        public static void Main()
        {
            List<Fighter> fighters = new FighterFactory().ReadFighters();
            var master = new GameMaster();
            Console.Clear();

            fighters.SortFightersByInitiative();

            var winner = master.PlayAndGetWinner(fighters);

            Console.WriteLine( $"{ winner.Name } wins!");
        }
    }

    public class GameMaster
    {

        public Fighter PlayAndGetWinner( List<Fighter> fighters )
        {
            int round = 1;
            List<int> alivePlayers = new List<int>();
            int i;
            for (i = 0; i < fighters.Count; i++) { alivePlayers.Add(i); }
            while ( alivePlayers.Count > 1 )
            {
                Console.WriteLine($"=========Round {round++}=========");
                for (i = 0; i < fighters.Count(); i++)
                {
                    if (!fighters[i].Dead)
                    {
                        Console.WriteLine($"--Turn of {fighters[i].Name}." +
                        $"\nHP: {fighters[i].CurrentHealth}/{fighters[i].MaxHealth}" +
                        $"\nSTR {fighters[i].Attributes.Strength} | DEX {fighters[i].Attributes.Dexterity} | CON {fighters[i].Attributes.Constitution}" +
                        $"\nWho do you want to attack? Choose the opponent:");
                        for (int j = 0; j < fighters.Count(); j++)
                        {
                            string yourCharacter = (j == i) ? " (Your character)" : "";
                            string deadCharacter = (fighters[j].Dead) ? " (DEAD)" : "";
                            
                            Console.WriteLine($"   {j + 1}. {fighters[j].Name} (AC {fighters[j].Armor.Armor}) {yourCharacter + deadCharacter}");
                        }
                        int opponentNum = int.Parse(Console.ReadLine()) - 1;
                        while (opponentNum < 0 || opponentNum >= fighters.Count)
                        {
                            Console.WriteLine("No fighter with that index, enter again");
                            opponentNum = int.Parse(Console.ReadLine()) - 1;
                        }
                        fighters[opponentNum].Dead = Figth(fighters[i], fighters[opponentNum]);
                        if (fighters[opponentNum].Dead) 
                        { 
                            alivePlayers.Remove(opponentNum); 
                            if (alivePlayers.Count == 1)
                            {
                                break;
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }

            return fighters[alivePlayers[0]];
        }
        public int Bonus(int attribute)
        {
            return Convert.ToInt32(Math.Floor((attribute - 10) / 2.0));
        }
        private bool Figth(Fighter player, Fighter opponent)
        {
            int d20RollResult = player.D20RollDice.Roll();
            int rollWithBonus = d20RollResult + Bonus(player.Attributes.Dexterity);
            int damage = player.CalculateDamage();
            if (rollWithBonus < opponent.Armor.Armor)
            {
                if (d20RollResult == 1)
                {
                    Console.WriteLine("Critical miss!");
                }
                else
                {
                    Console.WriteLine($"You missed! ({rollWithBonus} rolled)");
                }
                damage = 0;
            }
            else
            {
                if (d20RollResult == 20)
                {
                    Console.WriteLine("Critical hit!");
                    damage += player.CalculateDamage();
                }
                opponent.TakeDamage(damage);
                Console.WriteLine($"{player.Name} attacks {opponent.Name} and deals {damage} damage ({opponent.CurrentHealth} remains)");
            }
            return opponent.CurrentHealth == 0;
        }
    }
}
