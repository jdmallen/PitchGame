using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PitchGame.Logic {
    public class NoMoreFaceCardsException : Exception {
        private const string DefaultMessage =
            "There are no more face cards to " +
            "distribute to the remaining players.";
        public NoMoreFaceCardsException() : base(DefaultMessage) {}
        public NoMoreFaceCardsException(string message) : base(message) {}
    }

    public class MaxPlayersPerTeamReachedException : Exception {
        private const string DefaultMessage =
            "The maximum number of players for this team has been reached";
        public MaxPlayersPerTeamReachedException() : base(DefaultMessage) { }
        public MaxPlayersPerTeamReachedException(string message) : base(message) { }
    }
}
