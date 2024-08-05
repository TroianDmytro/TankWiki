using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TankWiki.Models.ModelTank;
using TankWiki.Models;

namespace TankWiki.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NationController : ControllerBase
    {
        private readonly MySqlDBContext _dbContext;
        public NationController(MySqlDBContext dBContext) => _dbContext = dBContext;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Nations);
        }

        [HttpPost]
        public IActionResult Post(string nation)
        {
            if (!string.IsNullOrEmpty(nation))
            {
                Nations newNation = new Nations();
                newNation.NationName = nation;
                _dbContext.Nations.Add(newNation);
                _dbContext.SaveChanges();
                return Ok(_dbContext.Nations);
            }
            return BadRequest();

        }
    }
}
