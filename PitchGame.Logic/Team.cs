using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchGame.Logic {
    public class Team {
        private static int _teamCount;
        public List<Player> Players { get; set; }
        public string TeamName { get; private set; }
        public int TeamNumber { get; private set; }
        public int Score { get; set; }
        

        public Team(string teamName) {
            _teamCount ++;
            Players = new List<Player>();
            TeamNumber = _teamCount;
            TeamName = teamName;
            Score = 0;
        }

        public Team() : this("Team " + _teamCount) {}

        public static void ResetTeamCount() {
            _teamCount = 0;
        }

        public static int GetTeamCount() {
            return _teamCount;
        }

        public override string ToString() {
            StringBuilder bldr = new StringBuilder();
            bldr.AppendLine("Team " + TeamNumber + " (" + TeamName + "):");
            if (Players.Count == 0)
                bldr.AppendLine("    No players in team.");
            else
                foreach (Player p in Players) {
                    bldr.AppendLine("    " + p);
                }
            return bldr.ToString();
        }
    }
}
