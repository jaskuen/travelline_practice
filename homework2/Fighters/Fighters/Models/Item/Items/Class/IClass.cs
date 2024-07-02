using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Dice;

namespace Fighters.Models.Item.Items.Class
{

    public interface IClass : IItem
    {
        public IDice HealthDice { get; }
    }
}
