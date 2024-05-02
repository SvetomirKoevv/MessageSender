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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            App main = new App();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            var result = await VerifyUser(username, password);
            if (result.PasswordIsValid)
            {
                MainApp mainApp = new MainApp(result.user);
                this.Hide(); 
                mainApp.ShowDialog();
                this.Close();
            }
            
        }

        private async Task<LoginUser> VerifyUser(string username, string password)
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
            User user = await userManager.FindByNameAsync(username);
            LoginUser login = new(user, await userManager.CheckPasswordAsync(user, password));
            return login;
        }
    }
}
