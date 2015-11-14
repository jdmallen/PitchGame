using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchGame.Logic {
    public class Team {
        private static int _teamCount = 0;
        public List<Player> Players { get; set; }
        public string TeamName { get; private set; }
        public int TeamNumber { get; private set; }
        public string Score { get; set; }

        public Team(string teamName, List<string> playerNames) {
            
        }

        public Team(string teamName) {
            _teamCount ++;
            TeamNumber = _teamCount;
            TeamName = teamName;
        }

        public Team() : this("Team " + _teamCount) {}

        public override string ToString() {
            StringBuilder bldr = new StringBuilder();
            bldr.AppendLine("Team " + TeamNumber + " (" + TeamName + "):");
            foreach (Player p in Players) {
                bldr.AppendLine("    " + p);
            }
            return bldr.ToString();
        }
    }
}
