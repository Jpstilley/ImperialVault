using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace ImperialVault.Models
{
    public class Game 
    {
        public int CampaignID { get; set; }

        public string CampaignName { get; set; }

        public IEnumerable<Users> Players { get; set; }

        public Users UserToInsert { get; set; }

        public Game()
        {
             
        }         

    }
}
