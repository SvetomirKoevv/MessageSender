﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        [Required]
        public List<User> Users { get; set; }

        public List<Message> Messages { get; set; }

        public Conversation() { }

        public Conversation (string name, List<User> users)
        {
            this.Name = name;
            this.Users = users;
        }

        public Conversation(string name)
        {
            this.Name = name;
            this.Users = new List<User>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}