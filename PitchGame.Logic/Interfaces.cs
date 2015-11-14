using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PitchGame.Logic {
    public interface IPitch {
        void BeginBettingRound();
        void BeginPlay();
        List<Card> GetCardsInPlay();
        Card GetLastCardPlayed();
        Player GetStartingPlayer();
        void ScoreRound();
        void GetTeamScores();

    }

    public interface IPlayer {}
    
}
