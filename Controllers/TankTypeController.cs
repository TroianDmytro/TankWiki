using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TankWiki.Models;

namespace TankWiki.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TankTypeController : ControllerBase
    {
        private readonly MySqlDBContext _dbContext;
        public TankTypeController(MySqlDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.TankTypes);
        }
        [HttpPost]
        public IActionResult Post(string tankType)
        {
            if (!string.IsNullOrEmpty(tankType))
            {
                TankType newTankType = new TankType();
                newTankType.TypeMachine = tankType;
                _dbContext.TankTypes.Add(newTankType);
                _dbContext.SaveChanges();
                return Ok(_dbContext.TankTypes);
            }
            return BadRequest();

        }
    }
}
