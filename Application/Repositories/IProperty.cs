using Domain;

namespace Application.Repositories
{
    public interface IProperty
    {
        Task AddNewAsync(Property property);
        Task DeleteAsync(Property property);
        Task<List<Property>> GetAllAsync();
        Task<Property> GetByIdAsync(int id);
        Task UpdateAsync(Property property);
    }
}
