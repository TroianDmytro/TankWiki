using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TankWiki.DTO;
using TankWiki.Models;
using TankWiki.Models.ModelOneToMany;
using TankWiki.Models.ModelTank;

namespace TankWiki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuspensionController : ControllerBase
    {
        private readonly MySqlDBContext _dbContext;
        public SuspensionController(MySqlDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<SuspensionDTO> suspension = await _dbContext.Suspensions
                                             .Include(ts => ts.TankSuspensions)
                                             .ThenInclude(t => t.Tank)
                                             .Select(s => new SuspensionDTO(s)
                                             {
                                                 Tanks = s.TankSuspensions
                                                 .Select(t => t == null ? null : new TankDTO(t.Tank)).ToList()
                                             })
                                             .ToListAsync();
            return Ok(suspension);
        }

        [HttpGet("{suspensionsId}")]
        public async Task<IActionResult> Get(int suspensionsId)
        {
            Suspension suspension = await _dbContext.Suspensions
                                             .Include(ts => ts.TankSuspensions)
                                             .ThenInclude(t => t.Tank)
                                             .FirstOrDefaultAsync(s=>s.SuspensionId==suspensionsId);

            SuspensionDTO suspensionDTO = new SuspensionDTO(suspension)
            {
                Tanks = suspension.TankSuspensions.Select(ts => new TankDTO(ts.Tank)).ToList()
            };

            return Ok(suspensionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int tier,
                                            string name,
                                            double loadLimit,
                                            int traverseSpeed,
                                            double weight,
                                            long price, [FromForm] List<int> tanksIds)
        {
            Suspension suspension = new Suspension();
            suspension.Name = name;
            suspension.Tier = tier;
            suspension.LoadLimit = loadLimit;
            suspension.TraverseSpeed = traverseSpeed;
            suspension.Weight = weight;
            suspension.Price = price;

            foreach (var t in tanksIds)
            {
                var tank = await _dbContext.Tanks.FindAsync(t);
                if (tank != null)
                {
                    await _dbContext.TankSuspensions.AddAsync(new TankSuspension() { Tank = tank, Suspension = suspension });
                }
            }

            await _dbContext.Suspensions.AddAsync(suspension);
            await _dbContext.SaveChangesAsync();

            return Ok("Трансмисия додана.");
        }


    }
}
