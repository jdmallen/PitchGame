using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchGame.Logic;

namespace PitchGame.Tests {
    public class Program {
        public static void Main(string[] args) {
            Deck newDeck = new Deck();
            newDeck.ColoredDeckToConsole();
            Console.WriteLine("\nShuffling\n");
            newDeck.ShuffleDeck();
            newDeck.ColoredDeckToConsole();

            Console.Read();


        }
    }
}
