using System;
using PitchGame.Logic;

namespace PitchGame.Tests {
    public class Program {
        public static void Main(string[] args) {
            //            Deck newDeck = new Deck();
            //            newDeck.ColoredDeckToConsole();
            //            Console.WriteLine("\nShuffling\n");
            //            newDeck.ShuffleDeck();
            //            newDeck.ColoredDeckToConsole();
            for (int i = 0; i < 10000; i++) {
                using (Pitch pitch = new Pitch(TeamConfiguration.TwoVsTwo)) {

                    pitch.AddTeam();
                    pitch.AddTeam();
                    pitch.AddTeam();
                    pitch.AddTeam();

                    Team team1 = pitch.Teams[0];
                    Team team2 = pitch.Teams[1];
                    Team team3 = pitch.Teams[2];
                    Team team4 = pitch.Teams[3];
                    pitch.AddPlayer(ref team1, "Alice");
                    pitch.AddPlayer(ref team1, "Bob");
                    pitch.AddPlayer(ref team2, "Charlie");
                    pitch.AddPlayer(ref team2, "Denise");
                    pitch.AddPlayer(ref team3, "Eric");
                    pitch.AddPlayer(ref team3, "Francesca");
                    pitch.AddPlayer(ref team4, "Greg");
                    pitch.AddPlayer(ref team4, "Heather");

                    pitch.DealCards();

                    foreach (Player p in pitch.GetPlayers()) {
                        Console.WriteLine(p.ToString());
                    }
                }
            }
            Console.Read();
        }
    }
}
