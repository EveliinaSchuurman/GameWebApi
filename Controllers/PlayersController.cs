using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/*namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
         public Task<Player> Get(Guid id){
    
            }
        public Task<Player[]> GetAll();
        public Task<Player> Create(NewPlayer player);
        public Task<Player> Modify(Guid id, ModifiedPlayer player);
        public Task<Player> Delete(Guid id);


        private readonly ILogger<PlayersController> _logger;

        public PlayersController(ILogger<PlayersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PlayersController> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new PlayersController
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}*/
