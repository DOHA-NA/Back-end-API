using ApiCe.Core.Entites;
using ApiCe.Core.Students;

namespace ApiCe.Core.Services
{
    public interface IStudentService
    {
        Task<List<STDResposDto>> GetAllAsync();
        Task<STDResposDto?>GetByIdAsync(int id);
        Task<STDResposDto> CreateAsync(CreateSTDDto student);
        Task UpdateAsync(int id, UpdateSTSDto student);
        Task DeleteAsync(int id);
    }
}