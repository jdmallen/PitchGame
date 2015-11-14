﻿using System;
using System.Drawing;

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

        public ConsoleColor CardColor {
            get {
                switch (Suit) {
                    case CardSuit.Spades:
                        return Console.ForegroundColor = ConsoleColor.White;
                    case CardSuit.Hearts:
                        return Console.ForegroundColor = ConsoleColor.Red;
                    case CardSuit.Diamonds:
                        return Console.ForegroundColor = ConsoleColor.Cyan;
                    case CardSuit.Clubs:
                        return Console.ForegroundColor = ConsoleColor.Green;
                    default:
                        return Console.ForegroundColor = ConsoleColor.White;
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
            return ShortValueName + " " + ShortSuitName + " (" + LongValueName + " of " + LongSuitName + ")";
        }
    }
}
