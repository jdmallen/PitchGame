using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace PitchGame.Logic {
    public class Pitch : IPitch, IDisposable {
        public static int NumTimesNoMoreFaceCardsThrown { get; set; }

        public Deck GameDeck { get; private set; }
        public List<Team> Teams { get; set; }
        public List<Player> Players { get; set; } 
        public CardSuit? Trump { get; private set; }
        public Dictionary<Team, Bet> Bets { get; set; }
        public int NumberOfPlayersPerTeam { get; set; }
        public int NumberOfTeams { get; set; }
        private TeamConfiguration _config;

        public Pitch(TeamConfiguration config) {
            switch (config) {
                case TeamConfiguration.TwoVsTwo:
                    NumberOfPlayersPerTeam = 2;
                    NumberOfTeams = 2;
                    break;
                case TeamConfiguration.TwoVsTwoVsTwo:
                    NumberOfPlayersPerTeam = 2;
                    NumberOfTeams = 3;
                    break;
                case TeamConfiguration.ThreeVsThree:
                    NumberOfPlayersPerTeam = 3;
                    NumberOfTeams = 2;
                    break;
                case TeamConfiguration.TwoVsTwoVsTwoVsTwo:
                    NumberOfPlayersPerTeam = 2;
                    NumberOfTeams = 4;
                    break;
                case TeamConfiguration.FourVsFour:
                    NumberOfPlayersPerTeam = 4;
                    NumberOfTeams = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(config), config, null);
            }
            _config = config;
            Initialize();
        }

        private void Initialize() {
            GameDeck = new Deck();
            Teams = new List<Team>();
            Players = new List<Player>(NumberOfPlayersPerTeam*NumberOfTeams);
            Trump = null;
            Bets = new Dictionary<Team, Bet>();
        }

        public void AddTeam(string teamName = null) {
            Teams.Add(new Team(_config,teamName));
        }

        public void AddPlayer(ref Team team, string playerName = null) {
            Player player = new Player(ref team, playerName);
            Players.Add(player);
        }

        public void DealCards() {
            try {
                foreach (Player p in Players) {
                    p.PlayerCards = GameDeck.GetPlayerCards();
                }
            } catch (NoMoreFaceCardsException) {
                NumTimesNoMoreFaceCardsThrown++;
                Debug.WriteLine(NumTimesNoMoreFaceCardsThrown +
                                " -- No more face cards! Starting over!");
                foreach (Player p in Players) {
                    p.PlayerCards.RemoveRange(0, p.PlayerCards.Count);
                }
                GameDeck.RebuildDeck();
                DealCards();
            }
        }

        public Dictionary<Player, Bet> BetsRequest() {
            Dictionary<Player,Bet> bets = new Dictionary<Player, Bet>();
            foreach (Player p in Players) {
                
            }
            return null;
        }

        public void BetsResponse(Dictionary<Player, Bet> bets) {
            
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

        public void Dispose() {
            GameDeck = null;
            Teams = null;
            Players = null;
            Trump = null;
            Bets = null;
            NumberOfPlayersPerTeam = 0;
            NumberOfTeams = 0;
            _config = TeamConfiguration.TwoVsTwo;
        }
    }
}