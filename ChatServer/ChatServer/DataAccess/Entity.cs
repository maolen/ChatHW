using System;

namespace ChatServer.DataAccess
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? DeletionTime { get; set; }

    }
}