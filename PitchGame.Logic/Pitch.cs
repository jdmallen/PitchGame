using System.Collections.Generic;
using System.ComponentModel;

namespace PitchGame.Logic {
    public class Pitch : IPitch {
        public Deck GameDeck { get; private set; }
        public List<Team> Teams { get; set; }
        public CardSuit? Trump { get; private set; }
        public Dictionary<Team, Bet> Bets { get; set; }

        public Pitch() {
            Initialize();
        }

        private void Initialize() {
            GameDeck = new Deck();
            Teams = new List<Team>();
            Trump = null;
            Bets = new Dictionary<Team, Bet>();
        }

        public void BeginBettingRound() {
            throw new System.NotImplementedException();
        }

        public void BeginPlay() {
            throw new System.NotImplementedException();
        }
        

        public List<Card> GetCardsInPlay() {
            throw new System.NotImplementedException();
        }

        public Card GetLastCardPlayed() {
            throw new System.NotImplementedException();
        }

        public CardSuit GetTrumpSuit() {
            throw new System.NotImplementedException();
        }

        public Player GetStartingPlayer() {
            throw new System.NotImplementedException();
        }

        public void ScoreRound() {
            throw new System.NotImplementedException();
        }

        public void GetTeamScores() {
            throw new System.NotImplementedException();
        }
    }
}