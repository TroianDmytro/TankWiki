﻿using Microsoft.AspNetCore.Mvc;
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
