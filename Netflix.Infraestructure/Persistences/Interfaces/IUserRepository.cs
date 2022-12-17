using Netflix.Domain.Entities;

namespace Netflix.Infraestructure.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AccountByEmail(string email);
    }
}