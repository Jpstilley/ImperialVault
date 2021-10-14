using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace ImperialVault.Models
{
    public class GameRepository : IGameRepository
    {
        private readonly IDbConnection _conn;

        public GameRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Game> GetGames()
        {
            return _conn.Query<Game>("SELECT * FROM Game;");
        }

        public Game GetSingleGame(int campaignID)
        {
            var game = _conn.QuerySingle<Game>("SELECT * FROM Game WHERE CampaignID = @campaignID;", new { campaignID });
            game.Players = GetPlayers(game.CampaignID);
            return game;
        }

        public void CreateGame(Game game)
        {
            _conn.Execute("INSERT INTO Game (CampaignName) VALUES (@name);"
                , new { name = game.CampaignName});
        }

        public Game GetLastGame()
        {
            return _conn.QuerySingle<Game>("SELECT * FROM Game ORDER BY CampaignID DESC LIMIT 1;");
        }

        public void DeleteGame(Game game)
        {
            _conn.Execute("DELETE FROM Game WHERE Campaign = @id;",
                                       new { id = game.CampaignID });
            _conn.Execute("DELETE FROM Users WHERE CampaignID = @id;",
                                       new { id = game.CampaignID });
        }

        public IEnumerable<Users> GetPlayers(int campaignID)
        {
            return _conn.Query<Users>("SELECT * FROM Users WHERE CampaignID = @campaignID;", new { campaignID });
        }

        public Users GetSinglePlayer(int userID)
        {
            return _conn.QuerySingle<Users>("SELECT * FROM Users WHERE UserID = @userID;", new { userID });
        }

        public void CreatePlayer(Users user)
        {
            _conn.Execute("INSERT INTO Users (UserName, CharacterName, XP, Credits, Equipment, Skills, CampaignID) VALUES (@name, @characterName, @xp, @credits, @equipment, @skills, @campaignID);"
                , new { name = user.UserName, characterName = user.CharacterName, xp = 0, credits = 0, equipment = user.Equipment, skills = user.Skills, campaignID = user.CampaignID });
        }

        public void UpdateCharacter(Users user)
        {
            _conn.Execute("UPDATE Users SET XP = @xp, Credits = @credits, Equipment = @equipment, Skills = @skills WHERE UserID = @id;",
                new { xp = user.XP, credits = user.Credits, equipment = user.Equipment, skills = user.Skills, id = user.UserID });
        }

        public void DeleteCharacter(Users user)
        {
            _conn.Execute("DELETE FROM Users WHERE UserID = @id;",
                                       new { id = user.UserID });
        }
    }
}
