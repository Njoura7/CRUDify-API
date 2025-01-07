    using CRUDify_API.DTOs;

    namespace CRUDify_API.Services

{

    public interface IUserService
    {
        
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDTO userDto);
        Task UpdateUserAsync(int id, UserDTO userDto);
        Task DeleteUserAsync(int id);
    }
}


