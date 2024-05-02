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
    public class MessageContext : IDb<Message, int>
    {
        private readonly MessageAppDbContext context;

        public MessageContext(MessageAppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Message item)
        {
            try
            {
                context.Messages.Add(item);
                context.SaveChangesAsync();
            }
            catch
            {

            }
        }

        public async Task DeleteAsync(int key)
        {
            try
            {
                Message messageFromDb = context.Messages.Find(key);
                if (messageFromDb != null)
                {
                    context.Messages.Remove(messageFromDb);
                }
                await context.SaveChangesAsync();
            }
            catch
            {

            }
        }

        public async Task<List<Message>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Message> query = context.Messages;
                
                if (useNavigationalProperties)
                {
                    query = query.Include(x => x.Sender).Include(x => x.MessageConversation);
                }

                return await query.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Message> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Message> query = context.Messages;

                if (useNavigationalProperties)
                {
                    query = query.Include(x => x.Sender).Include(x => x.MessageConversation);
                }

                return await query.FirstOrDefaultAsync(x => x.Id == key);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAsync(Message item, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                Message messageFromDb = await context.Messages.FindAsync(item.Id);
                if (messageFromDb != null)
                {
                    messageFromDb.MessageText = item.MessageText;
                    context.Messages.Update(messageFromDb);
                    await context.SaveChangesAsync();
                }
            }
            catch
            {

            }
        }
    }
}
