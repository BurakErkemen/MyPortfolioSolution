namespace Portfolio.Repositories.UnitOfWorkRepositories
{
    public class UnitOfWorkRepository(PortfolioDbContext context) : IUnitOfWorkRepository
    {
        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
    }
}
