using CRUDify_API.Models;
using CRUDify_API.DTOs;

namespace CRUDify_API.Data.Repositories.Interfaces

{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
