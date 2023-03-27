using devonbackend.Models;

namespace devonbackend.Repository
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>>  GetUsers();


        Task<User> GetUserById(int Id);


        Task<User> CreateUpdateUser(User user);


        Task<bool> DeleetProduct(int Id);

    }
}
