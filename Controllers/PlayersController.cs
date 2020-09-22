using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IRepository _irepository;

        public PlayerController(ILogger<PlayerController> logger, IRepository irepository)
        {
            _logger = logger;
            _irepository = irepository;
        }

        [HttpPost] //{"Name":"yeet"}
        [Route("create")]
        public async Task<Player> Create([FromBody] NewPlayer player)
        {
            DateTime localDate = DateTime.Now;

            Player new_player = new Player();
            new_player.Name = player.Name;
            new_player.Id = Guid.NewGuid();
            new_player.Score = 0;
            new_player.Level = 0;
            new_player.IsBanned = false;
            new_player.CreationTime = localDate;

            await _irepository.CreatePlayer(new_player);
            return new_player;
        }
        
        [HttpGet]
        [Route("ListPlayers")]
        public Task<Player[]> GetAll()
        {
            Task<Player[]> list_players = _irepository.GetAllPlayers();
            return list_players;
        }

        [HttpGet]
        [Route("Delete/{id:Guid}")]
        public async Task<Player> Delete(Guid id)
        {
            await _irepository.DeletePlayer(id);
            return null;
        }


        [HttpGet]
        [Route("Get/{id:Guid}")]
        public async Task<Player> GetPlayer(Guid id)
        {
            return await _irepository.GetPlayer(id);
        }

        [HttpPost] //{"Score":5}
        [Route("Modify/{id:Guid}")]
        public async Task<Player> UpdatePlayer(Guid id, [FromBody] ModifiedPlayer player)
        {
            await _irepository.UpdatePlayer(id, player);
            return null;
        }


    }
}
