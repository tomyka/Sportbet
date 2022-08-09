using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportbetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private static List<Game> _games = new List<Game>();

        [HttpPost]
        public IActionResult Create(Game game)
        {
            _games.Add(game);

            return Created("/game", game);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_games);
        }

        [HttpGet(template: "{gameId}")]
        public IActionResult Get(int gameId)
        {
            var foundGame = findGame(gameId);
            if (foundGame == null)
            {
                return NotFound($"Game with gameId {gameId} has not been found");
            }
            return Ok(foundGame);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            _games.Clear();
            return Ok();
        }

        [HttpDelete("{gameId}")]
        public IActionResult Delete(int gameId)
        {
            var foundGame = findGame(gameId);
            if (foundGame == null)
            {
                return NotFound($"Game with gameId {gameId} has not been found");
            }
            _games.Remove(foundGame);
            return Ok();
        }

        private Game findGame(int gameId)
        {
            foreach (var game in _games)
            {
                if (game.gameId == gameId)
                {
                    return game;
                }
            }
            return null;
        }
    }
}
