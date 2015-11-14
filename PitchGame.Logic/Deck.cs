using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Enum;

namespace PitchGame.Logic {
    public class Deck {
        public static List<Card> Cards { get; private set; }

        public Deck() {
            if (Cards == null) {
                RebuildDeck();
            }
            Cards.Shuffle();
        }

        public static void RebuildDeck() {
            Cards = new List<Card>(52);
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

        public List<Card> GetPlayerCards() {
            List<Card> playerCards = new List<Card>(6);
            bool containsFaceCard = false;
            while (!containsFaceCard) {
                if (playerCards.Count > 0) {
                    Cards.AddRange(playerCards.Take(playerCards.Count));
                    playerCards.RemoveRange(0, playerCards.Count);
                    ShuffleDeck();
                }
                playerCards.AddRange(Cards.Take(6));
                Cards.RemoveRange(0, 6);
                if (playerCards.Any(card => card.Value > CardValue.Ten)) {
                    containsFaceCard = true;
                }
            }
            return playerCards;
        }
    }
}
