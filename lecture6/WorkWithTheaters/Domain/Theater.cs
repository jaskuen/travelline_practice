using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Theater
    {
        public int Id { get; private init; }
        public string Name { get; private init; }
        public string Address { get; private init; }
        public string PhoneNumber { get; private init; }
        public DateTime OpeningDate { get; private init; }
        public List<Play> Plays { get; set; } = new List<Play>();
        public Theater(string name, string address, string phoneNumber, DateTime openingDate)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            OpeningDate = openingDate;
        }

        public override string ToString()
        {
            StringBuilder sb = new(300);
            sb.AppendLine("[Theater]");
            sb.AppendLine($"  Id: {Id}");
            sb.AppendLine($"  Name: {Name}");
            sb.AppendLine($"  Address: {Address}");
            sb.AppendLine($"  PhoneNumber: {PhoneNumber}");
            sb.AppendLine($"  OpeningDate: {OpeningDate}");
            sb.AppendLine($"  [Plays]: ");
            foreach (Play play in Plays)
            {
                sb.AppendLine($"    {play}");
            }

            return sb.ToString();
        }
    }
}
