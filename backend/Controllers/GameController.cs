﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Music_Game.Services;
using Music_Game.Models;

namespace Music_Game.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("start")]
        public async Task<ActionResult<Game>> StartGame()
        {
            var game = await _gameService.StartGameAsync();
            return Ok(game);
        }

        [HttpPost("turn")]
        public async Task<ActionResult<bool>> PlayerTurn([FromBody] PlayerTurnRequest request)
        {
            await _gameService.PlayerTurnAsync(request.Game, request.Player, request.Card);
            var isValid = _gameService.ValidatePlacement(request.Game, request.Card, request.Card.ReleaseDate);
            return Ok(isValid);
        }
    }
}