using System;
namespace ImperialVault.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string CharacterName { get; set; }
        public int XP { get; set; }
        public int Credits { get; set; }
        public string Equipment { get; set; }
        public string Skills { get; set; }
        public int CampaignID { get; set; }

        public Users()
        {

        }

        
    }
}
