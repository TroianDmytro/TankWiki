using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
                .Select(r => new RadioDTO()
                {
                    RadioId = r.RadioId,
                    Tier = r.Tier,
                    Name = r.Name,
                    SignalRange = r.SignalRange,
                    Weight = r.Weight,
                    Price = r.Price,
                    Tanks = r.TankRadios.Select(tr => new TankDTO(tr.Tank)).ToList()
                    //Tanks = r.TankRadios.Select(tr => new TankDTO()
                    //{
                    //    TankId = tr.Tank.TankId,
                    //    Name = tr.Tank.Name,
                    //    NationId = tr.Tank.NationId,
                    //    Nation = tr.Tank.Nation,
                    //    Tier = tr.Tank.Tier,
                    //    HitPoints = tr.Tank.HitPoints,
                    //    Status = tr.Tank.Status,
                    //    Price = tr.Tank.Price,
                    //    Description = tr.Tank.Description,
                    //    TypeId = tr.Tank.TypeId,
                    //    TankType = tr.Tank.TankType,
                    //    ArmorId = tr.Tank.ArmorId,
                    //    Armor = tr.Tank.Armor,
                    //    Crew = tr.Tank.Crew
                    //}).ToList()
                }).ToListAsync();

            return Ok(radio);
        }

        [HttpGet("{radioId}")]
        public async Task<IActionResult> GetRadioById(int radioId)
        {
            Radio radio = await _dbContext.Radios.FindAsync(radioId);

            RadioDTO? result = radio == null ? null
                : new RadioDTO()
                {
                    RadioId = radio.RadioId,
                    Tier = radio.Tier,
                    Name = radio.Name,
                    SignalRange = radio.SignalRange,
                    Weight = radio.Weight,
                    Price = radio.Price,
                    Tanks = radio.TankRadios.Select(tr => new TankDTO(tr.Tank)).ToList()
                    //{
                    //    TankId = tr.Tank.TankId,
                    //    Name = tr.Tank.Name,
                    //    NationId = tr.Tank.NationId,
                    //    Nation = tr.Tank.Nation,
                    //    Tier = tr.Tank.Tier,
                    //    HitPoints = tr.Tank.HitPoints,
                    //    Status = tr.Tank.Status,
                    //    Price = tr.Tank.Price,
                    //    Description = tr.Tank.Description,
                    //    TypeId = tr.Tank.TypeId,
                    //    TankType = tr.Tank.TankType,
                    //    ArmorId = tr.Tank.ArmorId,
                    //    Armor = tr.Tank.Armor,
                    //    Crew = tr.Tank.Crew
                    //}
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
