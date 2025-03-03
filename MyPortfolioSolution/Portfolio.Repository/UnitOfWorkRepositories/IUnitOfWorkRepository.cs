namespace Portfolio.Repositories.UnitOfWorkRepositories
{
    public interface IUnitOfWorkRepository
    {
        Task<int> SaveChangesAsync();
    }
}
