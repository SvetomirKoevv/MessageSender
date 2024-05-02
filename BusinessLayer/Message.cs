using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Required]
        public User Sender { get; set; }

        [Required]
        [ForeignKey("User")]
        public string SenderId { get; set; }

        [Required]
        public Conversation MessageConversation { get; set; }

        [Required]
        [ForeignKey("Converstaion")]
        public int ConversationId { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        private Message() { }

        public Message(string messageText, string senderId, int conversationId, DateTime dateSent)
        {
            this.MessageText = messageText;
            this.SenderId = senderId;
            this.ConversationId = conversationId;
            this.DateSent = dateSent;
        }
    }
}