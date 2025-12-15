using Microsoft.AspNetCore.Mvc;
using CRUD_API.Interface;
using CRUD_API.Models;
using CRUD_API.Services;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentController : ControllerBase
    {
        private readonly IMedicamentServices _medicamentServices;

        public MedicamentController(IMedicamentServices medicamentServices)
        {
            _medicamentServices = medicamentServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicamentAsync(CreateMedicamentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _medicamentServices.CreateMedicamentAsync(request);
                return Ok(new { message = "Medicament successfully created"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message ="An error occurred while creating the Medicament", error = ex.Message});
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var medicament = await _medicamentServices.GetAllAsync();
                if (medicament == null || !medicament.Any())
                {
                    return Ok(new {message = "No Medicaments found"});
                }
                return Ok(new {message = "Successfully retrived all Medicaments", data = medicament});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error ocurred while retriving all Medicaments", error = ex.Message});
            }
        }
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            try
            {
                var medicament = await _medicamentServices.GetByIdAsync(Id);
                if (medicament == null)
                {
                    return NotFound(new {message = $"No medicament with Id {Id} found"});
                }
                return Ok(new {message = $"Successfully retrived Medicament with Id {Id}.", data = medicament});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error ocurred while retrieveing the Medicament with Id {Id}.", error = ex.Message});
            }  
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateMedicamentAsync(Guid Id, UpdateMedicamentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var medicament = await _medicamentServices.GetByIdAsync(Id);
                if (medicament == null)
                {
                    return NotFound(new { message = $"Medicament with Id {Id}"});
                }
                await _medicamentServices.UpdateMedicamentAsync(Id, request);
                return Ok(new { message = $"Medicament with id {Id} successfully updated"});
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while updating the Medicament with Id {Id} ", error = ex.Message});
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTodoAsync(Guid Id)
        {
            try
            {
                await _medicamentServices.DeleteMedicamentAsync(Id);
                return Ok(new { message = $"Medicament with id {Id} successfully deleted"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while deleting the Medicament with id {Id}", error = ex.Message});
            }
        }
    }
}