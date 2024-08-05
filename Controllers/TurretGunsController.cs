using Microsoft.AspNetCore.Mvc;
using TankWiki.Models;
using TankWiki.Models.ModelOneToMany;

namespace TankWiki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurretGunsController : ControllerBase
    {
        private readonly MySqlDBContext _dbContext;

        public TurretGunsController(MySqlDBContext dBContext) => _dbContext = dBContext;

        // Post: TurretGuns/Add
        [HttpPost]
        public async Task<IActionResult> AddTurretToGun(int gunId, int turretId)
        {
            // Перевірка, чи існує гармата
            var gun = await _dbContext.Guns.FindAsync(gunId);

            if (gun == null) return NotFound("Гармата не знайдена.");

            // Перевірка, чи існує башта
            var turret = await _dbContext.Turrets.FindAsync(turretId);
            if (turret == null) return NotFound("Башта не знайдена.");

            string resultOperation = string.Empty;
            try
            {
                // Додавання нового зв'язку
                await _dbContext.TurretGuns.AddAsync(new TurretGun() { Gun = gun, Turret = turret });
                // Збереження змін у базі даних
                await _dbContext.SaveChangesAsync();
                resultOperation = "Башта успішно додана до гармати.";
            }
            catch (Exception ex)
            {
                resultOperation = ex.Message;
                return BadRequest(resultOperation);
            }

            return Ok(resultOperation);
        }
    }
}
