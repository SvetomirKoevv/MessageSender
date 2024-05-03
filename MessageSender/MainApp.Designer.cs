namespace MessageSender
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernameText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ConverstaionsList = new System.Windows.Forms.ListBox();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessageList = new System.Windows.Forms.ListBox();
            this.UsersList = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.AddConButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameText
            // 
            this.UsernameText.AutoSize = true;
            this.UsernameText.Location = new System.Drawing.Point(848, 12);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(0, 15);
            this.UsernameText.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(926, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ConverstaionsList
            // 
            this.ConverstaionsList.FormattingEnabled = true;
            this.ConverstaionsList.ItemHeight = 15;
            this.ConverstaionsList.Location = new System.Drawing.Point(12, 105);
            this.ConverstaionsList.Name = "ConverstaionsList";
            this.ConverstaionsList.Size = new System.Drawing.Size(189, 454);
            this.ConverstaionsList.TabIndex = 2;
            this.ConverstaionsList.SelectedIndexChanged += new System.EventHandler(this.ConverstaionsList_SelectedIndexChanged);
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(207, 516);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(520, 39);
            this.MessageText.TabIndex = 3;
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(733, 516);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(58, 39);
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // MessageList
            // 
            this.MessageList.FormattingEnabled = true;
            this.MessageList.ItemHeight = 15;
            this.MessageList.Location = new System.Drawing.Point(207, 59);
            this.MessageList.Name = "MessageList";
            this.MessageList.Size = new System.Drawing.Size(584, 454);
            this.MessageList.TabIndex = 5;
            // 
            // UsersList
            // 
            this.UsersList.FormattingEnabled = true;
            this.UsersList.ItemHeight = 15;
            this.UsersList.Location = new System.Drawing.Point(797, 60);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(209, 454);
            this.UsersList.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(935, 516);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 39);
            this.button3.TabIndex = 7;
            this.button3.Text = "Message";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // AddConButton
            // 
            this.AddConButton.Location = new System.Drawing.Point(12, 59);
            this.AddConButton.Name = "AddConButton";
            this.AddConButton.Size = new System.Drawing.Size(189, 40);
            this.AddConButton.TabIndex = 8;
            this.AddConButton.Text = "AddConverstaion";
            this.AddConButton.UseVisualStyleBackColor = true;
            this.AddConButton.Click += new System.EventHandler(this.AddConButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(797, 516);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 39);
            this.button2.TabIndex = 9;
            this.button2.Text = "Add To Conversation";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 567);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddConButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.UsersList);
            this.Controls.Add(this.MessageList);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.ConverstaionsList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UsernameText);
            this.Name = "MainApp";
            this.Text = "MainApp";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label UsernameText;
        private Button button1;
        private ListBox ConverstaionsList;
        private TextBox MessageText;
        private Button SendButton;
        private ListBox MessageList;
        private ListBox UsersList;
        private Button button3;
        private Button AddConButton;
        private Button button2;
    }
}