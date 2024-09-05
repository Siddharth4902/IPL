using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerDao _playerDao;

        public PlayerController(IPlayerDao playerDao)
        {
            _playerDao = playerDao;
        }
        [HttpGet("GetPlayers")]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var players1 = await _playerDao.GetPlayers();
            if (players1 == null)
            {
                return NotFound();
            }
            return Ok(players1);
        }
        [HttpGet("Top5")]
        public async Task<ActionResult<List<Player>>> Top5()
        {
            var players2 = await _playerDao.Top5();
            if (players2 == null)
            {
                return NotFound();
            }
            return Ok(players2);
        }

        [HttpGet("GetMatch")]
        public async Task<ActionResult<List<Match>>> GetMatch()
        {
            var match = await _playerDao.GetMatch();
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }
        [HttpPost("CreatePlayer")]
        public async Task<ActionResult<Player?>> CreatePlayer(Player player)
        {
            if (player != null)
            {
                if (ModelState.IsValid)
                {
                    int res = await _playerDao.InsertPlayer(player);
                    if (res > 0)
                    {
                        return Ok();
                    }
                }
                return BadRequest("Failed to add player");
            }
            else
            {
                return BadRequest("No Player Found");
            }
        }
        [HttpGet("GetMatchesByDate")]

        public async Task<ActionResult<List<Date>>> GetMatchesByDate(DateTime date1, DateTime date2)
        {
            List<Date> list = null;
            list = await _playerDao.GetMatchesByDate(date1,date2);
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound("No Match Found");
            }
        }
    }
}

