﻿using Microsoft.AspNetCore.Mvc;
using ServerApp.Managers;
using SharedLibrary.Exceptions;
using SharedLibrary.Factories;
using SharedLibrary.Models;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly ServerManager _serverManager = ServerManager.Instance;
        private readonly LevelOneGameFactory _levelOneGameFactory = new LevelOneGameFactory();

        #region Observer endpoints
        [HttpPost("SubscribeToObserver")]
        public IActionResult Subscribe()
        {
            return Ok(new Message { MessageText = "Subscribed to ServerManager observer." });
        }
        #endregion

        [HttpGet("CreateGameServer")]
        public IActionResult CreateGameServer(string serverName, string password, int level = 1)
        {
            if (_serverManager.IsServerNameTaken(serverName))
            {
                return new BadRequestObjectResult(new ErrorMessage("A server with this name already exists!"));
            }
            
            Game game = null;
            switch (level)
            {
                case 1:
                    game = _levelOneGameFactory.CreateGame(serverName, password, level);
                    break;
                case 2:
                    game = _levelOneGameFactory.CreateGame(serverName, password, level);
                    break;
                default:
                    return new BadRequestObjectResult(new ErrorMessage("Invalid game level!"));
            }
            _serverManager.CreateGameServer(game);
            return Ok(game);
        }
    }
}