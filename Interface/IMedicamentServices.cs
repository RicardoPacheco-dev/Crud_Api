using CRUD_API.Models;

namespace CRUD_API.Interface
{
    public interface IMedicamentServices
    {
        Task<IEnumerable<Medicament>> GetAllAsync();
        Task<Medicament> GetByIdAsync(Guid Id);
        Task CreateMedicamentAsync(CreateMedicamentRequest request);
        Task UpdateMedicamentAsync(Guid Id, UpdateMedicamentRequest request);
        Task DeleteMedicamentAsync(Guid Id);
    }
}