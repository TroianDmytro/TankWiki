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


        [HttpGet("Nation/{nation}")]
        public ActionResult Get(string nation)
        {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(string name, int nationId, int tier,
                                  int hitPoints, bool status, long price,
                                  string? description, int typeId, 
                                  int armorId, [FromForm] List<string> crew, [FromForm] List<int> turretIDs,
                                   [FromForm] List<int> engineIDs, [FromForm] List<int> radioIDs,
                                    [FromForm] List<int> suspensionIDs)
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

            foreach (var id in turretIDs)
            {
                Turret turret = await _dbContext.Turrets.FindAsync(id);
                if (turret != null)
                {
                    await _dbContext.TankTurrets.AddAsync(new TankTurret() { Tank=tank,Turret=turret });
                }
            }

            foreach (var id in engineIDs)
            {
                Engine engine = await _dbContext.Engines.FindAsync(id);
                if (engine != null)
                {
                    await _dbContext.TankEngines.AddAsync(new TankEngine() { Tank = tank, Engine=engine });
                }
            }

            foreach (var id in radioIDs)
            {
                Radio radio = await _dbContext.Radios.FindAsync(id);
                if (radio != null)
                {
                    await _dbContext.TankRadios.AddAsync(new TankRadio() { Tank = tank, Radio=radio });
                }
            }

            foreach (var id in suspensionIDs)
            {
                Suspension suspension = await _dbContext.Suspensions.FindAsync(id);
                if (suspension != null)
                {
                    await _dbContext.TankSuspensions.AddAsync(new TankSuspension() { Tank = tank, Suspension=suspension });
                }
            }

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
