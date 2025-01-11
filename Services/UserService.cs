using CRUDify_API.Data.Repositories.Interfaces;
using CRUDify_API.DTOs;
using CRUDify_API.Models;
 
namespace CRUDify_API.Services

{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //todo: why we have to use GetAllUsersAsync as the name of repository twice; 
        //in the decalarion and the implemenmtation with await
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            //todo: investigate the use cases of var in C#
            var users = await _userRepository.GetAllUsersAsync();

            // Map User to UserDTO
            return users.Select(user => new UserDTO
            {

                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Color = user.Color

            }).ToList();
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Color = user.Color
            };

        }

        public async Task AddUserAsync(UserDTO userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Age = userDto.Age,
                Color = userDto.Color
            };
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserDTO userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) throw new Exception("User not found");
         
            user.Name = userDto.Name;
            user.Name = userDto.Name;
            user.Color = userDto.Color;

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) throw new Exception("User not found");

            await _userRepository.DeleteUserAsync(user);
        }
    }

}
