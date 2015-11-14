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
//            Deck newDeck = new Deck();
//            newDeck.ColoredDeckToConsole();
//            Console.WriteLine("\nShuffling\n");
//            newDeck.ShuffleDeck();
//            newDeck.ColoredDeckToConsole();

            Pitch pitch = new Pitch(2,2);
            
            pitch.AddTeam("Team More Awesome");
            pitch.AddTeam("Team Less Awesome");

            Team team1 = pitch.Teams[0];
            Team team2 = pitch.Teams[1];
            pitch.AddPlayer(ref team1, "Alice");
            pitch.AddPlayer(ref team1, "Bob");
            pitch.AddPlayer(ref team2, "Charlie");
            pitch.AddPlayer(ref team2, "Denise");
            pitch.AddPlayer(ref team1, "Eric");
            pitch.AddPlayer(ref team1, "Francesca");
            pitch.AddPlayer(ref team2, "Greg");
            pitch.AddPlayer(ref team2, "Heather");

            foreach (Player p in pitch.Players) {
                Console.WriteLine(p.ToString());
            }




            Console.Read();
        }
    }
}
