using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace ImperialVault.Models
{
    public class Game : IGame
    {
        public int CampaignID { get; set; }

        public string CampaignName { get; set; }

        public List<Game> Players { get; set; }

        private readonly IDbConnection _conn;

        public Game(IDbConnection conn)
        {
            _conn = conn;
        }

        public Game(int gameID, string gameModel, List<Game> players)
        {
            CampaignID = gameID;
            CampaignName = gameModel;
            Players = players;
        }

        public IEnumerable<Game> GetPlayers(int gameID)
        {
            return _conn.Query<Game>("SELECT * FROM USERS WHERE GameID = @gameID;", new { gameID = gameID });
        }
    }
}
