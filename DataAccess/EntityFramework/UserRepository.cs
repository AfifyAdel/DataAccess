

using DataAccess.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(EFDataContext context):base(context)
        {

        }
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> Insert(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            _context.Users.Remove(new User() { ID = id});
            _context.SaveChanges();
        }
    }
}
