using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<User> Friends { get; set; }
        public IList<Message> InboxMessages { get; set; }

        public void SendMessage(string messageContent, User receiver)
        {
            if (receiver == null)
                throw new ArgumentNullException("receiver");
            if (string.IsNullOrEmpty(messageContent))
                throw new ArgumentNullException("message");

            var message = new Message
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                SenderId = Id,
                ReceiverId = receiver.Id,
                Content = messageContent
            };

            receiver.InboxMessages.Add(message);
        }

        public void ReadMessage(Guid messageId)
        {
            var message = InboxMessages.FirstOrDefault(message => message.Id == messageId);
            if (message == null)
                throw new Exception("Message not found");
            message.Status = MessageStatus.Read;
        }

        public User()
        {
            Friends = new List<User>();
            InboxMessages = new List<Message>();
        }
    }
}
