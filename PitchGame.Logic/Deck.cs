using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Enum;

namespace PitchGame.Logic {
    public class Deck {
        public List<Card> Cards { get; private set; }
        private int _faceCardsRemaining;

        public Deck() {
            RebuildDeck();
            Cards.Shuffle();
        }

        public void RebuildDeck() {
            Cards = new List<Card>(52);
            _faceCardsRemaining = 16;
            foreach (CardSuit s in GetValues(typeof(CardSuit)).Cast<CardSuit>()) {
                foreach (CardValue v in
                    GetValues(typeof(CardValue)).Cast<CardValue>()) {
                    Cards.Add(new Card(s,v) {
                        IsInPlay = false,
                        IsVisible = false
                    });
                }
            }
            Cards.Shuffle();
        }

        public void ShuffleDeck() {
            Cards.Shuffle();
        }

        public override string ToString() {
            StringBuilder bldr = new StringBuilder();
            ConsoleColor foreColor = Console.ForegroundColor;
            bldr.AppendLine("Cards in deck (" + Cards.Count + "):");
            if (Cards.Count == 0) {
                bldr.AppendLine("    No cards in deck.");
            } else {
                foreach (Card c in Cards) {
                    bldr.AppendLine("    " + c);
                }
            }
            return bldr.ToString();
        }

        public void ColoredDeckToConsole() {
            ConsoleColor foreColor = Console.ForegroundColor;
            Console.WriteLine("Cards in deck (" + Cards.Count + "):");
            if (Cards.Count == 0) {
                Console.WriteLine("    No cards in deck.");
            } else {
                foreach (Card c in Cards) {
                    Console.ForegroundColor = c.CardColor;
                    Console.WriteLine("    " + c);
                }
            }
            Console.ForegroundColor = foreColor;
        }

        public void GetPlayerCards(ref List<Player> players) {
            for (int i = 0; i < players.Count; i++) {
                if (_faceCardsRemaining == 0) {
                    RebuildDeck();
                    i = 0;
                }
                if (players[i].PlayerCards == null) {
                    players[i].PlayerCards = new List<Card>(6);
                }
                players[i].PlayerCards.RemoveRange(0,
                    players[i].PlayerCards.Count);
                bool playerHandContainsFaceCard = false;
                while (!playerHandContainsFaceCard) {
                    if (players[i].PlayerCards.Count > 0) {
                        Cards.AddRange(
                            players[i].PlayerCards.Take(
                                players[i].PlayerCards.Count));
                        players[i].PlayerCards.RemoveRange(0,
                            players[i].PlayerCards.Count);
                        ShuffleDeck();
                    }
                    players[i].PlayerCards.AddRange(Cards.Take(6));
                    Cards.RemoveRange(0, 6);
                    int faceCards =
                        players[i].PlayerCards.Count(
                            x => x.Value > CardValue.Ten);
                    if (faceCards <= 0) {
                        continue;
                    }
                    playerHandContainsFaceCard = true;
                    _faceCardsRemaining -= faceCards;
                }
            }
        }
    }
}
