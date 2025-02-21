using ConstructionProjectManagement.Domain.Entities;
using ConstructionProjectManagement.Domain.Interfaces;
using ConstructionProjectManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace ConstructionProjectManagement.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
