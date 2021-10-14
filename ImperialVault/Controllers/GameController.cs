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
        private readonly IGameRepository _game;

        public GameController(IGameRepository game)
        {
            _game = game;
        }

        public IActionResult Index()
        {
            var games = _game.GetGames();
            

            return View(games);
        }        

        public IActionResult ViewGame(int id)
        {
            Game game = _game.GetSingleGame(id);

            return View(game);
        }

        public IActionResult CreateGame()
        {
            Game game = new Game();

            return View(game);
        }

        public IActionResult SendGameToDatabase(Game game)
        {
            _game.CreateGame(game);

            game = _game.GetLastGame();

            return RedirectToAction("ViewGame", new { id = game.CampaignID });
        }

        public IActionResult DeleteGame(Game game)
        {
            _game.DeleteGame(game);

            return RedirectToAction("Index");
        }

        public IActionResult ViewCharacter(int id)
        {
            Users user = _game.GetSinglePlayer(id);

            return View(user);
        }

        public IActionResult AddPlayer(int id)
        {
            var game = _game.GetSingleGame(id);

            return View(game);
        }

        public IActionResult AddPlayerToDatabase(Game game)
        {
            _game.CreatePlayer(game.UserToInsert);

            return RedirectToAction("ViewGame", new { id = game.UserToInsert.CampaignID });
        }

        public IActionResult UpdateCharacter(int id)
        {
            Users user = _game.GetSinglePlayer(id);

            if (user == null)
            {
                return View("CharacterNotFound");
            }

            return View(user);
        }

        public IActionResult UpdateCharacterToDatabase(Users user)
        {
            _game.UpdateCharacter(user);

            return RedirectToAction("ViewCharacter", new { id = user.UserID });
        }


        public IActionResult DeleteCharacter(Users user)
        {
            _game.DeleteCharacter(user);

            return RedirectToAction("ViewGame", new { id = user.CampaignID });
        }
    }
}