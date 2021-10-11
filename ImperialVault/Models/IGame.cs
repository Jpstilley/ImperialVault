using System;
using System.Collections.Generic;

namespace ImperialVault.Models
{
    public interface IGame
    {
        public IEnumerable<Game> GetPlayers(int gameID);

    }
}
