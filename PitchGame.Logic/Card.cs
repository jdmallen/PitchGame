using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchGame.Logic {
    public class Card {
        public CardValue Value { get; set; }
        public CardSuit Suit { get; set; }
        public string LongValueName => Value.ToString();
        public string LongSuitName => Suit.ToString();
        public string ShortValueName {
            get {
                switch (Value) {
                    case CardValue.Ace:
                        return "A";
                    case CardValue.Jack:
                        return "J";
                    case CardValue.Queen:
                        return "Q";
                    case CardValue.King:
                        return "K";
                    default:
                        return ((int)Value).ToString();
                }
            }
        }
        public string ShortSuitName {
            get {
                switch (Suit) {
                    case CardSuit.Spades:
                        return "\u2660";
                    case CardSuit.Hearts:
                        return "\u2665";
                    case CardSuit.Diamonds:
                        return "\u2666";
                    case CardSuit.Clubs:
                        return "\u2663";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int GameValue {
            get {
                switch (Value) {
                    case CardValue.Ace:
                        return 4;
                    case CardValue.Ten:
                        return 10;
                    case CardValue.Jack:
                        return 1;
                    case CardValue.Queen:
                        return 2;
                    case CardValue.King:
                        return 3;
                    default:
                        return 0;
                }
            }
        }

        public bool IsVisible { get; set; }
        public bool IsInPlay { get; set; }
        public Image CardImage { get; set; }

        public Card(CardSuit suit, CardValue value) {
            Suit = suit;
            Value = value;
        }

        public override string ToString() {
            return ShortSuitName + " " + ShortValueName + " (" + LongValueName + " of " + LongSuitName + ")";
        }
    }
}
