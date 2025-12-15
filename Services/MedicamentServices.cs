using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CRUD_API.AppDataContext;
using CRUD_API.Interface;
using CRUD_API.Models;
using CRUD_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;

namespace CRUD_API.Services
{

    public class MedicamentServices : IMedicamentServices
    {
        private readonly CRUD_APIDbContext _context;
        private readonly ILogger<MedicamentServices> _logger;
        private readonly IMapper _mapper;

        public MedicamentServices(CRUD_APIDbContext context, ILogger<MedicamentServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        //Creates medicament to be saved in the database
        public async Task CreateMedicamentAsync(CreateMedicamentRequest request)
        {
            try
            {
                var medicament = _mapper.Map<Medicament>(request);
                _context.Medicaments.Add(medicament);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Medicament item.");
                throw new Exception("An error ocurred while creating the Medicament item.");
            }
        }
        //erases a medicament from the database based on the ID
        public async Task DeleteMedicamentAsync(Guid Id)
        {
            var medicament = await _context.Medicaments.FindAsync(Id);
            if (medicament == null)
            {
                throw new Exception($"No Medicament found with the Id {Id}");
            }
            else
            {
                _context.Medicaments.Remove(medicament);
                await _context.SaveChangesAsync();
            }
        }
        //gets all medicaments on the database
        public async Task<IEnumerable<Medicament>> GetAllAsync()
        {
            var medicament= await _context.Medicaments.ToListAsync();
            if(medicament == null)
            {
                throw new Exception("No Medicament items found");
            }
            return medicament;
        }
        //gets only one medicament from the database guided by the ID
        public async Task<Medicament> GetByIdAsync(Guid Id)
        {
            var medicament = await _context.Medicaments.FindAsync(Id);
            if (medicament == null)
            {
                throw new KeyNotFoundException($"No Medicament item with Id {Id} found.");
            }
            return medicament;
        }
        //updates a medicament on the database guided by the ID
        public async Task UpdateMedicamentAsync(Guid Id, UpdateMedicamentRequest request)
        {
            try
            {
                var medicament = await _context.Medicaments.FindAsync(Id);
                if (medicament == null)
                {
                    throw new Exception($"Medicament with Id {Id} not found");
                }
                if (request.Name != null)
                {
                    medicament.Name = request.Name;
                }
                if (request.ActiveIngridient != null)
                {
                    medicament.ActiveIngridient = request.ActiveIngridient;
                }
                if (request.ExpirationDate != null)
                {
                    medicament.ExpirationDate = request.ExpirationDate;
                }
                if (request.Batch != null)
                {
                    medicament.Batch = request.Batch;
                }
                if (request.Laboratory != null)
                {
                    medicament.Laboratory = request.Laboratory;
                }
                if (request.Price != null)
                {
                    medicament.Price = request.Price;
                }
                if (request.Quantity != null)
                {
                    medicament.Quantity = request.Quantity;
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the Medicament with the id {Id}.");
                throw;
            }
        }
    }
}