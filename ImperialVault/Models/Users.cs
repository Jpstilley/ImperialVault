using System;
namespace ImperialVault.Models
{
    public class Game
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string CharacterName { get; set; }
        public int CharacterXP { get; set; }
        public int CharacterCredits { get; set; }
        public string CharacterEquipment { get; set; }
        public string CharacterSkills { get; set; }
        public int GameID { get; set; }

        public Game()
        {

        }

        public Game(int userID, string userName, string characterName, int characterXP, int characterCredits, string characterEquipment, string characterSkills, int gameID)
        {
            UserID = userID;
            UserName = userName;
            CharacterName = characterName;
            CharacterXP = characterXP;
            CharacterCredits = characterCredits;
            CharacterEquipment = characterEquipment;
            CharacterSkills = characterSkills;
            GameID = gameID;
        }
    }
}
