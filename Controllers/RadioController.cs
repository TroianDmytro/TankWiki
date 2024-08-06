using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TankWiki.DTO;
using TankWiki.Models;
using TankWiki.Models.ModelOneToMany;
using TankWiki.Models.ModelTank;

namespace TankWiki.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RadioController : ControllerBase
    {
        private readonly MySqlDBContext _dbContext;
        public RadioController(MySqlDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var radio = await _dbContext.Radios
                .Include(tr => tr.TankRadios)
                .ThenInclude(t => t.Tank)
                .Select(r => new RadioDTO(r)
                {
                    Tanks = r.TankRadios.Select(t => new TankDTOTruncated(t.Tank)).ToList()
                }).ToListAsync();

            return Ok(radio);
        }

        [HttpGet("{radioId}")]
        public async Task<IActionResult> GetRadioById(int radioId)
        {
            Radio? radio = await _dbContext.Radios
                                .Include(tr => tr.TankRadios)
                                .ThenInclude(t => t.Tank)
                                .FirstOrDefaultAsync(r=>r.RadioId==radioId);

            if (radio == null) return NotFound("Radio not found");

            RadioDTO? result = new RadioDTO(radio)
            {
                Tanks = radio.TankRadios.Select(t => new TankDTOTruncated(t.Tank)).ToList()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string name,
            int tier, int signalRange, int weiht, long price, [FromForm] List<int> tankIds)
        {
            Radio radio = new Radio()
            {
                Name = name,
                Tier = tier,
                SignalRange = signalRange,
                Weight = weiht,
                Price = price
            };

            foreach (var id in tankIds)
            {
                var tank = await _dbContext.Tanks.FindAsync(id);
                if (tank != null)
                {
                    await _dbContext.TankRadios.AddAsync(new TankRadio() { Radio = radio, Tank = tank });
                }
            }
            await _dbContext.Radios.AddAsync(radio);
            await _dbContext.SaveChangesAsync();

            return Ok("Радіо додано.");
        }


    }
}
