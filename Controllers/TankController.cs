using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TankWiki.DTO;
using TankWiki.Models;
using TankWiki.Models.ModelOneToMany;
using TankWiki.Models.ModelTank;

namespace TankWiki.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TankController : ControllerBase
    {

        private readonly MySqlDBContext _dbContext;
        private readonly ILogger<TankController> _logger;

        public TankController(ILogger<TankController> logger, MySqlDBContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tanks = await _dbContext.Tanks
                                        .Include(tt => tt.TankType)
                                        .Include(te => te.TankEngines)
                                        .ThenInclude(e => e.Engine)
                                        .Include(tr => tr.TankRadios)
                                        .ThenInclude(r => r.Radio)
                                        .Include(ts => ts.TankSuspensions)
                                        .ThenInclude(s => s.Suspension)
                                        .Include(tt => tt.TankTurrets)
                                        .ThenInclude(t => t.Turret)
                                        .ThenInclude(tg => tg.TurretGuns)
                                        .ThenInclude(g => g.Gun)
                                        .Include(n => n.Nation)
                                        .Include(a => a.Armor)
                                        .Select(t => new TankDTO(t)
                                        {
                                            Engines = t.TankEngines.Select(e => new EngineDTO(e.Engine)).ToList(),
                                            Radios = t.TankRadios.Select(r => new RadioDTO(r.Radio)).ToList(),
                                            Suspensions = t.TankSuspensions.Select(s => new SuspensionDTO(s.Suspension)).ToList(),
                                            Turrets = t.TankTurrets.Select(t => new TurretDTO(t.Turret)
                                            {
                                                Guns = t.Turret.TurretGuns.Select(g => new GunDTO(g.Gun)).ToList(),
                                            }).ToList(),
                                        }
                                        ).ToListAsync();
                
            return Ok(tanks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Tank? tank = await _dbContext.Tanks
                                        .Include(tt => tt.TankType)
                                        .Include(te => te.TankEngines)
                                        .ThenInclude(e => e.Engine)
                                        .Include(tr => tr.TankRadios)
                                        .ThenInclude(r => r.Radio)
                                        .Include(ts => ts.TankSuspensions)
                                        .ThenInclude(s => s.Suspension)
                                        .Include(tt => tt.TankTurrets)
                                        .ThenInclude(t => t.Turret)
                                        .ThenInclude(tg => tg.TurretGuns)
                                        .ThenInclude(g => g.Gun)
                                        .Include(n => n.Nation)
                                        .Include(a => a.Armor)
                                        .FirstOrDefaultAsync(t=>t.TankId == id);

            if (tank == null) return NotFound("Tank not found.");

            TankDTO tankDTO = new TankDTO(tank)
            {
                Engines = tank.TankEngines.Select(e => new EngineDTO(e.Engine)).ToList(),
                Radios = tank.TankRadios.Select(r => new RadioDTO(r.Radio)).ToList(),
                Suspensions = tank.TankSuspensions.Select(s => new SuspensionDTO(s.Suspension)).ToList(),
                Turrets = tank.TankTurrets.Select(t => new TurretDTO(t.Turret)
                {
                    Guns = t.Turret.TurretGuns.Select(g => new GunDTO(g.Gun)).ToList(),
                }).ToList(),
            };


            return Ok(tankDTO);
        }
        //[HttpGet("Nation/{nation}")]
        //public ActionResult Get(string nation)
        //{

        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> Post(string name, int nationId, int tier, int hitPoints, bool status,
                                              long price, string? description, int typeId, int armorId, 
                                              [FromForm] List<string> crew)
        {
            Tank tank = new Tank()
            {
                Name = name,
                NationId = nationId,
                Tier = tier,
                HitPoints = hitPoints,
                Status = status,
                Price = price,
                Description = description,
                TypeId = typeId,
                ArmorId = armorId,
                Crew = crew,
            };

            await _dbContext.Tanks.AddAsync(tank);
            await _dbContext.SaveChangesAsync();

            return Ok("Танк додано.");

        }

        //[HttpPatch("{tankId}")]
        //public Task<IActionResult> PatchDescription(int tankId, string description)
        //{

        //}
    }
}
