using BusinessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext : IDb<User, string>
    {
        private readonly MessageAppDbContext context;

        public UserContext(MessageAppDbContext context)
        {
            this.context = context;
        }   

        public async Task CreateAsync(User item)
        {
            try
            {
                context.Users.Add(item);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                User userFromDb = await context.Users.FindAsync(key);
                if (userFromDb != null)
                {
                    context.Users.Remove(userFromDb);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = context.Users;
                
                if (useNavigationalProperties)
                {
                    query = query.Include(x => x.Friends).Include(x => x.Conversations);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            };
        }

        public async Task<User> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = context.Users;

                if (useNavigationalProperties)
                {
                    query = query.Include(x => x.Friends).Include(x => x.Conversations);
                }

                return await query.FirstOrDefaultAsync(x => x.Id == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(User item, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                User userFromDb = await ReadAsync(item.Id);
                if (userFromDb != null)
                {
                    userFromDb.UserName = item.UserName;
                }
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
