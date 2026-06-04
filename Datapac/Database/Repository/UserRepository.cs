using Example.DB.Repository.Interfaces;
using Example.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Example.Database.Repository
{
    public class UserRepository(ExampleContext context) : IUserRepository
    {
        public Task<User?> GetUserAsync(Guid id) 
            => context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}
