using BusinessLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class IdentityResultSet
    {
        public IdentityResult result { get; set; }
        public User LoggedUser { get; set; }    

        public IdentityResultSet() { }

        public IdentityResultSet(IdentityResult result, User loggedUser)
        {
            this.result = result;
            this.LoggedUser = loggedUser;
        }
    }

    public class LoginUser
    {
        public bool PasswordIsValid { get; set; }
        public User user { get; set; }

        public LoginUser() { }
        public LoginUser(User user, bool valid)
        {
            this.user = user;
            PasswordIsValid = valid;
        }
    }
}
