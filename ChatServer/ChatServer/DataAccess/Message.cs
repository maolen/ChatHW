using System;

namespace ChatServer.DataAccess
{
    public class Message : Entity
    {
        public User SenderName { get; set; }
        public string Text { get; set; }
    }
}