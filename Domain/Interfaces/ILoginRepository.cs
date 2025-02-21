using ConstructionProjectManagement.Domain.Entities;

namespace ConstructionProjectManagement.Domain.Interfaces
{

    public interface ILoginRepository
    {
        Task<Users> GetUserByEmailAsync(string email);
    }
}
