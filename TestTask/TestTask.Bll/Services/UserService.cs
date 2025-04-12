using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces.Bll;
using TestTask.Domain.Interfaces.Repositories;

namespace TestTask.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            user.Id = Guid.NewGuid();
            await _userRepository.CreateAsync(user);
        }

        public Task UpdateAsync(User user)
        {
            return _userRepository.UpdateAsync(user);
        }

        public Task DeleteAsync(Guid id)
        {
            return _userRepository.DeleteAsync(id);
        }
    }
}
