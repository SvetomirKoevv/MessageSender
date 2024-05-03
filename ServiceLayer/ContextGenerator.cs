using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ContextGenerator
    {
        private static MessageAppDbContext dbContext;
        private static MessageContext autoContext;
        private static ConversationContext saloniContext;
        private static UserContext customerContext;

        public static MessageAppDbContext GetDbContext()
        {
            if (dbContext == null)
            {
                SetDbContext();
            }
            return dbContext;
        }

        public static void SetDbContext()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
            dbContext = new MessageAppDbContext();
        }

        public static MessageContext GetMessageContext()
        {
            if (autoContext == null)
            {
                SetMessageContext();
            }
            return autoContext;
        }

        private static void SetMessageContext()
        {
            autoContext = new MessageContext(GetDbContext());
        }

        public static ConversationContext GetConversationContext()
        {
            if (saloniContext == null)
            {
                SetConversationContext();
            }
            return saloniContext;
        }

        private static void SetConversationContext()
        {
            saloniContext = new ConversationContext(GetDbContext());
        }

        public static UserContext GetUserContext()
        {
            if (customerContext == null)
            {
                SetUserContext();
            }
            return customerContext;
        }

        private static void SetUserContext()
        {
            customerContext = new UserContext(GetDbContext());
        }

    }
}
