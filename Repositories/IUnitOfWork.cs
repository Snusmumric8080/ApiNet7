namespace ApiNet7.Repositories
{
    public interface IUnitOfWork
    {
        public interface IUnitOfWork : IDisposable
        {
            IBookRepository Books { get; }
            Task<int> SaveChangesAsync();
        }
    }
}
