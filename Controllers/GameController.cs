using BetchleyBreaker.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetchleyBreaker.Controllers
{
    public class GameController : Controller
    {
        private static Game _game;

        public GameController()
        {
            if (_game == null)
            {
                _game = new Game();
            }
        }

        public ActionResult Index()
        {
            return View(_game);
        }

        [HttpPost]
        public ActionResult MakeGuess(int[] guess)
        {
            var result = _game.MakeGuess(guess);

            if (_game.IsGameWon())
            {
                ViewBag.Message = "You won the game!";
            }
            else if (_game.Attempts >= 13)
            {
                ViewBag.Message = "Game over! You've reached the maximum number of attempts.";
            }

            return View("Index", _game);
        }

        public ActionResult NewGame()
        {
            _game = new Game();
            return View("Index", _game);
        }
    }

}
