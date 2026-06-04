using Example.Database.Repository.Interfaces;

namespace Example.Database.Repository
{
    public class UnitOfWork(ExampleContext context) : IUnitOfWork
    {
        public async Task<int> CommitAsync() 
            => await context.SaveChangesAsync();
    }
}
