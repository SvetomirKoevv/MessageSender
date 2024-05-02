﻿using BusinessLayer;
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
    public partial class MainApp : Form
    {
        private User LoggedInUser;

        public MainApp(User loggedInUser)
        {
            InitializeComponent();
            this.LoggedInUser = loggedInUser;
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            UsernameText.Text = LoggedInUser.UserName;
        }
    }
}
