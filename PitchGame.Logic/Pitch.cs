using System.Collections.Generic;

namespace PitchGame.Logic {
    public class Pitch : IPitch {
        public List<IPlayer> GetPlayers() {
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

        public IPlayer GetStartingPlayer() {
            throw new System.NotImplementedException();
        }
    }
}