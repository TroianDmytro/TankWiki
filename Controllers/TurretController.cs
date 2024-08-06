using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TankWiki.DTO;
using TankWiki.Models;
using TankWiki.Models.ModelOneToMany;
using TankWiki.Models.ModelTank;

namespace TankWiki.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TurretController : ControllerBase
    {
        private readonly MySqlDBContext _dbContext;

        public TurretController(MySqlDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTurrets()
        {
            var turrets = await _dbContext.Turrets
                .AsNoTracking()
                .Include(t => t.TurretGuns)
                .ThenInclude(g => g.Gun)
                .Include(tg => tg.TankTurrets)
                .ThenInclude(tn => tn.Tank)
                .Select(t => new TurretDTO(t)
                {
                    Guns = t.TurretGuns.Select(tg => new GunDTO(tg.Gun)).ToList(),
                    Tanks = t.TankTurrets.Select(t => new TankDTOTruncated(t.Tank)).ToList()
                })
                .ToListAsync();

            //return this.StatusCode((int)HttpStatusCode.OK, turrets);
            return Ok(turrets);
        }

        [HttpGet("{turretId}")]
        public IActionResult GetId(int turretId)
        {
            var turret = _dbContext.Turrets
                .Include(tg => tg.TurretGuns)
                .ThenInclude(g => g.Gun)
                .Include(tt => tt.TankTurrets)
                .ThenInclude(t => t.Tank)
                .FirstOrDefault(t => t.TurretId == turretId);
            if (turret != null)
            {
                var newTurret = new TurretDTO()
                {
                    TurretId = turret.TurretId,
                    TurretName = turret.TurretName,
                    Tier = turret.Tier,
                    TurretFront = turret.TurretFront,
                    TurretSide = turret.TurretSide,
                    TurretRear = turret.TurretRear,
                    Turn = turret.Turn,
                    Overview = turret.Overview,
                    Weight = turret.Weight,
                    Price = turret.Price,
                    Guns = turret.TurretGuns.Select(gun => new GunDTO()
                    {
                        GunId = gun.Gun.GunId,
                        Tier = gun.Gun.Tier,
                        Name = gun.Gun.Name,
                        Penetration = gun.Gun.Penetration,
                        Damage = gun.Gun.Damage,
                        RateOfFire = gun.Gun.RateOfFire,
                        Accuracy = gun.Gun.Accuracy,
                        AimTime = gun.Gun.AimTime,
                        Ammunition = gun.Gun.Ammunition,
                        Weight = gun.Gun.Weight,
                        Price = gun.Gun.Price
                    }).ToList(),
                    Tanks = turret.TankTurrets.Select(t => new TankDTOTruncated(t.Tank)).ToList()
                };
                return Ok(turret);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult PostTurret(
            [FromForm] string turretName,
            [FromForm] int tier,
            [FromForm] int turretFront,
            [FromForm] int turretSide,
            [FromForm] int turretRear,
            [FromForm] double turn,
            [FromForm] int overview,
            [FromForm] int weight,
            [FromForm] long price,
            [FromForm] List<int> gunIds, // IDs для Guns
            [FromForm] List<int> tankIds) // IDs для Tanks
        {
            var turret = new Turret
            {
                TurretName = turretName,
                Tier = tier,
                TurretFront = turretFront,
                TurretSide = turretSide,
                TurretRear = turretRear,
                Turn = turn,
                Overview = overview,
                Weight = weight,
                Price = price
            };

            // Добавляем Guns и Tanks
            foreach (var gunId in gunIds)
            {
                var gun = _dbContext.Guns.Find(gunId);
                if (gun != null)
                {
                    turret.TurretGuns.Add(new TurretGun { Turret = turret, Gun = gun });
                }
            }

            foreach (var tankId in tankIds)
            {
                var tank = _dbContext.Tanks.Find(tankId);
                if (tank != null)
                {
                    turret.TankTurrets.Add(new TankTurret { Turret = turret, Tank = tank });
                }
            }

            _dbContext.Turrets.Add(turret);
            _dbContext.SaveChanges();

            return Ok();
        }

       
        [HttpPatch("AddGun")]
        public async Task<IActionResult> AddGunToTurret(int turretId, int gunId)
        {
            var turret = await _dbContext.Turrets
                .Include(t => t.TurretGuns)
                .FirstOrDefaultAsync(t => t.TurretId == turretId);

            if (turret == null)
            {
                return NotFound(new { Message = "Turret not found" });
            }

            var gun = await _dbContext.Guns.FindAsync(gunId);
            if (gun == null)
            {
                return NotFound(new { Message = "Gun not found" });
            }

            turret.TurretGuns.Add(new TurretGun { TurretId = turret.TurretId, GunId = gun.GunId });
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
