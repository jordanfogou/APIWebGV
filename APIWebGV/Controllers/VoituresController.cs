using APIWebGV.Data;
using APIWebGV.Models.garage;
using APIWebGV.Models.voiture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace APIWebGV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var voitures = await _dbContext.Voitures
                .Select(v => new VoitureDTO
                {
                    Id = v.Id,
                    Marque = v.Marque,
                    Modele = v.Modele,
                    Annee = v.Annee,
                    GarageId = v.GarageId
                })
                .ToListAsync();
            return Ok(voitures);
        }

        [HttpPost]
        public async Task<IActionResult> AddVoiture(AddVoitureRequest addVoitureRequest)
        {
            var voiture = new Voiture
            {
                Id = Guid.NewGuid(),
                Marque = addVoitureRequest.Marque,
                Modele = addVoitureRequest.Modele,
                Annee = addVoitureRequest.Annee,
                GarageId = addVoitureRequest.GarageId
            };

            _dbContext.Voitures.Add(voiture);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVoiture), new { id = voiture.Id }, voiture);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoiture(Guid id)
        {
            var voiture = await _dbContext.Voitures
                .Where(v => v.Id == id)
                .Select(v => new VoitureDTO
                {
                    Id = v.Id,
                    Marque = v.Marque,
                    Modele = v.Modele,
                    Annee = v.Annee,
                    GarageId = v.GarageId
                })
                .FirstOrDefaultAsync();

            if (voiture == null)
            {
                return NotFound();
            }

            return Ok(voiture);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVoiture(Guid id, UpdateVoitureRequest updateVoitureRequest)
        {
            var voiture = await _dbContext.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }

            voiture.Marque = updateVoitureRequest.Marque;
            voiture.Modele = updateVoitureRequest.Modele;
            voiture.Annee = updateVoitureRequest.Annee;
            voiture.GarageId = updateVoitureRequest.GarageId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoiture(Guid id)
        {
            var voiture = await _dbContext.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }

            _dbContext.Voitures.Remove(voiture);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }

    public class VoitureDTO
    {
        public Guid Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public Guid GarageId { get; set; }
    }
}
