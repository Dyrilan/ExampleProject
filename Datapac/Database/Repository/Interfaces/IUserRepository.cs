using Example.Domain.Models;

namespace Example.DB.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserAsync(Guid id);
    }
}