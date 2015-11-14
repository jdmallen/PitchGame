using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PitchGame.Logic {
    public class Pitch : IPitch {
        public Deck GameDeck { get; private set; }
        public List<Team> Teams { get; set; }
        public List<Player> Players { get; set; } 
        public CardSuit? Trump { get; private set; }
        public Dictionary<Team, Bet> Bets { get; set; }
        public int NumberOfPlayersPerTeam { get; set; }
        public int NumberOfTeams { get; set; }

        public Pitch(int numTeams, int numPlayersPerTeam) {
            if (numTeams < 2 || numPlayersPerTeam < 2) {
                NumberOfTeams = 2;
                NumberOfPlayersPerTeam = 2;
            }
            Initialize();
        }

        private void Initialize() {
            GameDeck = new Deck();
            Teams = new List<Team>();
            Players = new List<Player>(NumberOfPlayersPerTeam * NumberOfTeams);
            Trump = null;
            Bets = new Dictionary<Team, Bet>();
        }

        public void AddTeam(string teamName = null) {
            Teams.Add(new Team(teamName));
        }

        public void AddPlayer(ref Team team, string playerName = null) {
            Player player = new Player(ref team, GameDeck.GetPlayerCards(),
                playerName);
            Players.Add(player);
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