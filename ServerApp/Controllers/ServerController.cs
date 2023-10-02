using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServerApp.Managers;
using SharedLibrary.Exceptions;
using SharedLibrary.Factories;
using SharedLibrary.Models;
using SharedLibrary.Models.Request_Models;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly ServerManager _serverManager;
        private readonly LevelOneGameFactory _levelOneGameFactory = new LevelOneGameFactory();
        
        public ServerController(ServerManager serverManager)
        {
            _serverManager = serverManager;
        }

        [HttpPost("CreateNewGameServer")]
        public async Task<IActionResult> CreateGameServer(Game game)
        {
            if (_serverManager.IsServerNameTaken(game.Name))
            {
                return new BadRequestObjectResult(new ErrorMessage("A server with this name already exists!"));
            }
            
            switch (game.Level)
            {
                case 1:
                    game = _levelOneGameFactory.CreateGame(game.CreatorId, game.Name, game.Password, game.Level);
                    break;
                case 2:
                    game = _levelOneGameFactory.CreateGame(game.CreatorId, game.Name, game.Password, game.Level);
                    break;
                default:
                    return new BadRequestObjectResult(new ErrorMessage("Invalid game level!"));
            }
            _serverManager.CreateGameServer(game);
            return Ok(game);
        }

        [HttpPost("JoinGameServer")]
        public async Task<IActionResult> JoinGameServer(JoinGameDetails joinGameDetails)
        {
            try
            {
                var joined = await _serverManager.JoinGameServer(joinGameDetails);
                return Ok(joined);
            }
            catch (GameNotFoundException)
            {
                return new BadRequestObjectResult(new ErrorMessage("Game not found!"));
            }
            catch (InvalidPasswordException)
            {
                return new BadRequestObjectResult(new ErrorMessage("Invalid password!"));
            }
            catch (GameFullException)
            {
                return new BadRequestObjectResult(new ErrorMessage("Game is full!"));
            }
        }

        [HttpPost("SetPlayerAsReady")]
        public async Task<IActionResult> SetPlayerAsReady(PlayerReadyDetails playerReadyDetails)
        {
            bool isServerReady = await _serverManager.SetPlayerAsReady(playerReadyDetails);
            playerReadyDetails.IsServerReady = isServerReady;
            return Ok(playerReadyDetails);
        }
    }
}
