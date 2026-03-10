namespace packstation.Repositorys
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync (int id);
        Task<IReadOnlyList<T>> GetAllAsync ();
        Task<T> GetBySendingNumberAsync(string sendingNumber);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete (T entity);
        Task<int> SaveChangeAsync();
        IQueryable<T> Query();


    }
}
