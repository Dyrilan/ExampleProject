namespace Example.Database.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
