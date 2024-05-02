using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MessageSender
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string confirmPassword = ConfirmPassTextBox.Text;

            var res = new IdentityResultSet();

            if (password == confirmPassword)
            {
                res = await CreateUser(username, password);
                if (!res.result.Succeeded) return;
            }
            else
            {
                return;
            }
            MainApp mainApp = new MainApp(res.LoggedUser);
            this.Hide();
            mainApp.ShowDialog();
            this.Close();
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {

        }


        public async Task<IdentityResultSet> CreateUser(string userName, string password)
        {
            IdentityOptions options = new IdentityOptions();
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 5;

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(
                "Server=TIMI-PC;Database=MessageApp;TrustServerCertificate=True;Trusted_Connection=True;Encrypt=True"
                );

            MessageAppDbContext dbContext = new MessageAppDbContext(builder.Options);
            UserManager<User> userManager = new UserManager<User>(
                new UserStore<User>(dbContext), Options.Create(options),
                new PasswordHasher<User>(), new List<IUserValidator<User>>() { new UserValidator<User>() },
                new List<IPasswordValidator<User>>() { new PasswordValidator<User>() }, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), new ServiceCollection().BuildServiceProvider(),
                new Logger<UserManager<User>>(new LoggerFactory())
                );
            var user = new User(userName);
            IdentityResult res = await userManager.CreateAsync(user);
            await userManager.AddPasswordAsync(user, password);
            IdentityResultSet resSet = new(res, user);
            return resSet;
        }
    }
}
