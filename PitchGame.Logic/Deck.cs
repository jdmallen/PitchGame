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
                BuildDeck();
            }
            Cards.Shuffle();
        }

        private static void BuildDeck() {
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
    }
}
