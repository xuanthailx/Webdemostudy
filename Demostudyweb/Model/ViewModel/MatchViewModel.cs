using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class MatchViewModel
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan? StartTime { get; set; }

        public int? Duration { get; set; }

        public string Location { get; set; }

        public string Game { get; set; }

        public string FirstTeam { get; set; }

        public string SecondTeam { get; set; }

        public int? FirstTeamScore { get; set; }

        public int? SecondTeamScore { get; set; }

    }
}