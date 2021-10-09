using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Domain
{
    public class Conversation
    {

        public Guid Id { get; set; }
        public IList<User> Participants { get; set; }
        public IList<Message> Messages { get; set; }

        private Conversation()
        {
            Participants = new List<User>();
            Messages = new List<Message>();
        }

        public static Conversation NewConversation(IList<User> participants)
        {
            if (participants == null)
                throw new ArgumentNullException("participants");
            var conversation = new Conversation
            {
                Id = Guid.NewGuid(),
                Participants = participants
            };
            return conversation;
        }

        public static Conversation NewConversation(Guid id, IList<User> participants)
        {
            var conversation = NewConversation(participants);
            conversation.Id = id;
            return conversation;
        }
    }
}
