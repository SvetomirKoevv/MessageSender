using BusinessLayer;
using DataLayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageSender
{
    public partial class AddConversation : Form
    {
        private ConversationContext conversationContext;
        public User user;
        private MainApp mainApp;

        public AddConversation(User user_, MainApp mainApp_)
        {
            InitializeComponent();
            conversationContext = ContextGenerator.GetConversationContext();
            user = user_;
            mainApp = mainApp_;
        }

        private async void AddConButtonSubmit_Click(object sender, EventArgs e)
        {
            Conversation newConversation = new Conversation(NameTextBox.Text);
            newConversation.Users.Add(user);
            await conversationContext.CreateAsync(newConversation);
            mainApp.SetListValues();
            this.Close();
        }
    }
}
