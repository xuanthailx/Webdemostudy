using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class TeamViewModel
    {
        public int ID { get; set; }

        public string TeamName { get; set; }

        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string GameName { get; set; }

        public int? Checkin { get; set; }
    }
}
