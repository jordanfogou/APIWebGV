using APIWebGV.Data;
using APIWebGV.Models.garage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace APIWebGV.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class GaragesController : Controller
    {
        private readonly GaragesAPIDbContext _dbContext;

        public GaragesController(GaragesAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetGarages()
        {
            return Ok(await _dbContext.Garages.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddGarage(AddGarageRequest addGarageRequest)
        {
            var garage = new Garage
            {
                Id = Guid.NewGuid(),
                Nom = addGarageRequest.Nom,
                Emplacement = addGarageRequest.Emplacement
            };

            _dbContext.Garages.Add(garage);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGarage), new { id = garage.Id }, garage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGarage(Guid id)
        {
            var garage = await _dbContext.Garages.FindAsync(id);
            if (garage == null)
            {
                return NotFound();
            }
            return Ok(garage);
        }
    }
}
