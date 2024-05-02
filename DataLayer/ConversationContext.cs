using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ConversationContext : IDb<Conversation, int>
    {
        private readonly MessageAppDbContext context;
        
        public ConversationContext(MessageAppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Conversation item)
        {
            try
            {
                context.Conversations.Add(item);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAsync(int key)
        {
            try
            {
                Conversation conversationFromDb = await context.Conversations.FindAsync(key);
               
                if (conversationFromDb != null)
                {
                    foreach (Message msg in context.Messages)
                    {
                        if (msg.ConversationId == key)
                        {
                            context.Messages.Remove(msg);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Conversation>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Conversation> query = context.Conversations;

                if (useNavigationalProperties)
                {
                    query = query.Include(x => x.Messages).Include(x => x.Users);
                }
                return await query.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Conversation> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Conversation> query = context.Conversations;

                if (useNavigationalProperties)
                {
                    query = query.Include(x => x.Messages).Include(x => x.Users);
                }
                return await query.FirstOrDefaultAsync(x => x.Id == key);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAsync(Conversation item, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                Conversation conversationFromDb = await context.Conversations.FindAsync(item.Id);

                if (conversationFromDb != null)
                {
                    conversationFromDb.Name = item.Name;
                    context.Conversations.Update(conversationFromDb);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
