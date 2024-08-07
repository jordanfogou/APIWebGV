using APIWebGV.Data;
using APIWebGV.Models.garage;
using APIWebGV.Models.Voiture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace APIWebGV.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class VoituresController : Controller
    {
        private readonly GaragesAPIDbContext _dbContext;

        public VoituresController(GaragesAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetVoitures()
        {
            return Ok(await _dbContext.Voitures.Include(v => v.Garage).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddVoiture(AddVoitureRequest addVoitureRequest)
        {
            var garage = await _dbContext.Garages.FindAsync(addVoitureRequest.GarageId);

            if (garage == null)
            {
                return NotFound($"Garage with Id = {addVoitureRequest.GarageId} not found");
            }

            var voiture = new Voiture
            {
                Id = Guid.NewGuid(),
                Marque = addVoitureRequest.Marque,
                Modele = addVoitureRequest.Modele,
                Annee = addVoitureRequest.Annee,
                GarageId = addVoitureRequest.GarageId,
                Garage = garage
            };

            _dbContext.Voitures.Add(voiture);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVoiture), new { id = voiture.Id }, voiture);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoiture(Guid id)
        {
            var voiture = await _dbContext.Voitures.Include(v => v.Garage).FirstOrDefaultAsync(v => v.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }
            return Ok(voiture);
        }
    }
}
