using System;
using System.Collections.Generic;

namespace ImperialVault.Models
{
    public interface IGameRepository
    {
        public IEnumerable<Game> GetGames();
        public Game GetSingleGame(int campaignID);
        public void CreateGame(Game game);
        public void DeleteGame(Game game);
        public Game GetLastGame();
        public IEnumerable<Users> GetPlayers(int gameID);
        public Users GetSinglePlayer(int userID);
        public void CreatePlayer(Users user);
        public void UpdateCharacter(Users user);
        public void DeleteCharacter(Users user);
    }
}
