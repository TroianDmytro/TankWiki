using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TankWiki.Models;
using TankWiki.Models.ModelOneToMany;
using TankWiki.Models.ModelTank;

namespace TankWiki.Controllers.ControllersManyToMany
{
    [Route("[controller]")]
    [ApiController]
    public class TankEnginsController : ControllerBase
    {
        private readonly MySqlDBContext _dbContext;

        public TankEnginsController(MySqlDBContext dBContext) => _dbContext = dBContext;

        [HttpPost]
        public async Task<IActionResult> Post(int tankId, int engineId)
        {
            //перевіряе чи існуе танк
            Tank? tank = await _dbContext.Tanks.FindAsync(tankId);
            if (tank == null) NotFound("Танк не знайдено.");
            //перевіряе чи існуе двигун
            Engine? engine = await _dbContext.Engines.FindAsync(engineId);
            if (engine == null) NotFound("Двигун не знайдено.");

            string resultOperation = string.Empty;

            try
            {
                await _dbContext.TankEngines.AddAsync(new TankEngine { Engine = engine, Tank = tank });
                await _dbContext.SaveChangesAsync();
                resultOperation = "Двигун додано до танка.";
            }
            catch (Exception ex)
            {
                resultOperation = ex.Message;
                return BadRequest(resultOperation);
            }

            return Ok(resultOperation);
        }

        // Замінює oldEngineId на newEngineId в таблиці TankEngines
        [HttpPut("update_engine_id")]
        public async Task<IActionResult> UpdateEngineId(int oldEngineId, int newEngineId)
        {
            await _dbContext.TankEngines
                            .Where(el=>el.EngineId==oldEngineId)
                            .ExecuteUpdateAsync(g=>g.SetProperty(p=>p.EngineId,newEngineId));
            await _dbContext.SaveChangesAsync();

            return Ok("Update engine id.");
        }

        // Замінює oldTankId на newTankId в таблиці TankEngines
        [HttpPut("update_tank_id")]
        public async Task<IActionResult> UpdateTankId(int oldTankId, int newTankId)
        {
            await _dbContext.TankEngines
                            .Where(el => el.TankId == oldTankId)
                            .ExecuteUpdateAsync(g => g.SetProperty(p => p.TankId, newTankId));
            await _dbContext.SaveChangesAsync();

            return Ok("Update tank id.");
        }

        [HttpDelete("DeleteTank/{tankId}")]
        public async Task<IActionResult> DeleteTanksById(int tankId)
        {
            await _dbContext.TankEngines.Where(te => te.TankId == tankId).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();

            return Ok("Deleted Tank.");
        }

        [HttpDelete("DeleteEngine/{engineId}")]
        public async Task<IActionResult> DeleteEngineById(int engineId)
        {
            await _dbContext.TankEngines.Where(te => te.EngineId == engineId).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();

            return Ok("Deleted engine.");
        }
    }
}
