using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging.Abstractions;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageSender
{
    public partial class MainApp : Form
    {
        private UserContext userContext;
        private MessageContext messageContext;
        private ConversationContext converstaionContext;

        private User loggedInUser;
        private Conversation currentConversation;

        private List<Conversation> userConversations;
        private List<BusinessLayer.Message> currentConversationMessages;
        private List<User> allRegisteredUsers;

        IPHostEntry ipEntry;
        IPAddress ip;
        IPEndPoint iPEndPoint;


        public MainApp(User loggedInUser_)
        {
            InitializeComponent();
            this.loggedInUser = loggedInUser_;

            userContext = ContextGenerator.GetUserContext();
            messageContext = ContextGenerator.GetMessageContext();
            converstaionContext = ContextGenerator.GetConversationContext();

            userConversations = new List<Conversation>();
            currentConversationMessages = new List<BusinessLayer.Message>();
            allRegisteredUsers = new List<User>();
        }

        private async void MainApp_Load(object sender, EventArgs e)
        {
            loggedInUser = await userContext.ReadAsync(loggedInUser.Id, true);
            UsernameText.Text = loggedInUser.UserName;
            try
            {
                userConversations = loggedInUser.Conversations.ToList();
            }
            catch
            {

            }
            
            allRegisteredUsers = await userContext.ReadAllAsync();
            SetListValues();

            ipEntry = await Dns.GetHostEntryAsync(Dns.GetHostName());
            ip = ipEntry.AddressList[0];
            iPEndPoint = new(ip, 1234);

            using Socket client = new(
                iPEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            await client.ConnectAsync(iPEndPoint);
        }

        public async void SetListValues()
        {
            loggedInUser = await userContext.ReadAsync(loggedInUser.Id, true);
            userConversations = loggedInUser.Conversations;
            ConverstaionsList.Items.Clear();
            foreach(Conversation conversation in userConversations)
            {
                ConverstaionsList.Items.Add(conversation);
            }


            allRegisteredUsers = await userContext.ReadAllAsync();
            UsersList.Items.Clear();
            foreach(User user in allRegisteredUsers)
            {
                UsersList.Items.Add(user);
            }
        }

        private async void UpdateMessageBox()
        {
            currentConversationMessages = currentConversation.Messages;
            MessageList.Items.Clear();
            foreach (BusinessLayer.Message msg in currentConversationMessages)
            {
                MessageList.Items.Add(msg);
            }
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            if (ConverstaionsList.SelectedItem == null) return;
            if (MessageText.Text == "") return;

            BusinessLayer.Message message = new BusinessLayer.Message(MessageText.Text, loggedInUser.Id, currentConversation.Id, DateTime.Now);
            await messageContext.CreateAsync(message);
            UpdateMessageBox();
        }

        private void AddConButton_Click(object sender, EventArgs e)
        {
            AddConversation addConversationForm = new AddConversation(loggedInUser, this);
            addConversationForm.Show();
        }

        private async void ConverstaionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendButton.Enabled = true;
            Conversation conversation = (Conversation)ConverstaionsList.SelectedItem;
            currentConversation = await converstaionContext.ReadAsync(conversation.Id, true);
            UpdateMessageBox();
        }
    }
}
