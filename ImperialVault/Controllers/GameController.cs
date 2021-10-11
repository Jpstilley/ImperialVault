using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImperialVault.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImperialVault.Controllers
{
    public class GameController : Controller
    {
        private readonly Game game;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewGame(int gameID)
        {
            var users = game.GetPlayers(gameID);

            return View(users);
        }
    }
}