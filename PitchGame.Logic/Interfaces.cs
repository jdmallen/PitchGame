using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PitchGame.Logic {
    public interface IPitch {

        List<IPlayer> GetPlayers();
        List<Card> GetCardsInPlay();
        Card GetLastCardPlayed();
        CardSuit GetTrumpSuit();
        IPlayer GetStartingPlayer();

    }

    public interface IPlayer {}
    
}
