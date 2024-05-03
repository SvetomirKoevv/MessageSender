using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User : IdentityUser
    {
        public List<Conversation> Conversations { get; set; }

        public List<User> Friends { get; set; }

        public User() { }

        public User(string username)
        {
            this.Conversations = new List<Conversation>();
            this.Friends = new List<User>();
            this.UserName = username;
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}
