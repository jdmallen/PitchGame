using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchGame.Logic {
    public class Team {
        private static int _teamCount;
        private List<Player> _players;
        public string TeamName { get; private set; }
        public int TeamNumber { get; private set; }
        public int Score { get; set; }
        public int PlayerCount { get; set; }
        

        public Team(TeamConfiguration config, string teamName) {
            _teamCount ++;
            _players = new List<Player>();
            switch (config) {
                case TeamConfiguration.TwoVsTwo:
                case TeamConfiguration.TwoVsTwoVsTwo:
                case TeamConfiguration.TwoVsTwoVsTwoVsTwo:
                    PlayerCount = 2;
                    break;
                case TeamConfiguration.ThreeVsThree:
                    PlayerCount = 3;
                    break;
                case TeamConfiguration.FourVsFour:
                    PlayerCount = 4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(config), config, null);
            }
            PlayerCount = TeamNumber = _teamCount;
            TeamName = teamName;
            Score = 0;
        }

        public Team() : this(TeamConfiguration.TwoVsTwo, "Team " + _teamCount) {}

        public static void ResetTeamCount() {
            _teamCount = 0;
        }

        public static int GetTeamCount() {
            return _teamCount;
        }

        public void AddPlayer(Player player) {
            if (_players.Count <= PlayerCount) {
                _players.Add(player);
            } else throw new MaxPlayersPerTeamReachedException();
        }

        public override string ToString() {
            StringBuilder bldr = new StringBuilder();
            bldr.AppendLine("Team " + TeamNumber + " (" + TeamName + "):");
            if (_players.Count == 0) {
                bldr.AppendLine("    No players in team.");
            } else {
                foreach (Player p in _players) {
                    bldr.AppendLine("    " + p);
                }
            }
            return bldr.ToString();
        }
    }
}
