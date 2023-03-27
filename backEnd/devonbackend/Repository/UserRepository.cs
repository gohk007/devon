using devonbackend.Dbcontexts;
using devonbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace devonbackend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
                _context= context;
        }

        public async Task<User> CreateUpdateUser(User user)
        {

           // User users = await _context.Users.FirstOrDefaultAsync(x => x.ID == user.ID);
            if(user.ID>0)
            {
                 _context.Users.Update(user);
            }
            else if(user.ID==0) 
            {
               await _context.Users.AddAsync(user);
            }

            await _context.SaveChangesAsync();

            return user;
            
        }

        public async Task<bool> DeleetProduct(int Id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x=>x.ID==Id);
            if (user==null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserById(int Id)
        {
            User user = await _context.Users.Where(x => x.ID == Id).FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable <User>  users= await _context.Users.ToListAsync();

            return users;
        }
    }
}
