using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Play
    {
        public int Id { get; private init; }
        public string Name { get; private init; }
        public string StageDirector { get; private init; }
        public int TheaterId { get; private set; }
        public DateTime StartDate { get; private init; }
        public DateTime EndDate { get; private init; }

        public IReadOnlyList<Actor> Actors { get; private init; } = new List<Actor>();

        public Play(string name, string stageDirector, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StageDirector = stageDirector;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            StringBuilder sb = new(300);
            sb.AppendLine("[Play]");
            sb.AppendLine($"  Id: {Id}");
            sb.AppendLine($"  Name: {Name}");
            sb.AppendLine($"  StageDirector: {StageDirector}");
            sb.AppendLine($"  EndDate: {StartDate}");
            sb.AppendLine($"  StartDate: {EndDate}");

            return sb.ToString();
        }
    }
}
