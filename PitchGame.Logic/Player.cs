using System.Collections.Generic;
using System.Text;

namespace PitchGame.Logic {
    public class Player {
        private static int _playerCount = 0;
        public List<Card> PlayerCards { get; set; }
        public string PlayerName { get; set; }
        public Team PlayerTeam { get; set; }
        public Bet PlayerBet { get; set; }
        
        public Player(ref Team team, List<Card> cards, string name = null) {
            _playerCount++;
            if (string.IsNullOrWhiteSpace(name)) {
                PlayerName = "Player " + _playerCount;
            } else {
                PlayerName = name;
            }
            PlayerTeam = team;
            PlayerCards = cards;
        }

        public override string ToString() {
            StringBuilder bldr = new StringBuilder();
            bldr.Append("Player: " + PlayerName + ", Team: ");
            bldr.AppendLine(PlayerTeam == null
                ? "[Player not assigned team yet.]"
                : PlayerTeam.TeamName);
            bldr.AppendLine("Cards:");
            if (PlayerCards.Count == 0)
                bldr.AppendLine("[Player has no cards.]");
            else
                foreach (Card c in PlayerCards) {
                    bldr.AppendLine(c.ToString());
                }

            return bldr.ToString();
        }
    }
}
