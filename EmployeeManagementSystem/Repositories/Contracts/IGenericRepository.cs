namespace EmployeeManagementSystem.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T obj);
        Task Delete(object ID);
        Task Update(object ID, T obj);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(object ID);
    }
}
