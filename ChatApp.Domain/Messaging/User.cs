using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<User> Friends { get; set; }
        public IList<Conversation> Conversations { get; set; }

        public Message SendMessage(string messageContent, IList<User> receivers)
        {
            var conversation = Conversations.FirstOrDefault(c => c.Participants.All(p => p.Id == Id || receivers.Any(r => r.Id == p.Id)));

            if (conversation == null)
            {
                var participants = new List<User>(receivers) { this };

                conversation = Conversation.NewConversation(participants);

                Conversations.Add(conversation);

                foreach (var receiver in receivers)
                    receiver.Conversations.Add(Conversation.NewConversation(conversation.Id, participants));
            }

            var message = Message.NewMessage(this, messageContent, conversation.Id);

            foreach (var receiver in receivers)
            {
                receiver.ReceiveMessage(message);
            }

            message.Status = MessageStatus.Delivered;

            return message;
        }

        public void ReceiveMessage(Message message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            var conversation = Conversations.FirstOrDefault(c => c.Id == message.ConversationId);

            if (conversation == null)
                throw new Exception("conversation not found");

            conversation.Messages.Add(message);
        }

        public void ReadMessages(Conversation conversation)
        {
            if (conversation == null)
                throw new ArgumentNullException("conversation");

            var notReadMessages = conversation.Messages.Where(m => m.Status == MessageStatus.Delivered);

            foreach (var message in notReadMessages)
            {
                message.ReadBy(Id);
                message.Status = MessageStatus.ReadBySome;

                if (conversation.Participants.All(p => message.ReadByIds.Contains(p.Id)))
                    message.Status = MessageStatus.ReadByAll;
            }
        }

        public User()
        {
            Friends = new List<User>();
            Conversations = new List<Conversation>();
        }
    }
}
