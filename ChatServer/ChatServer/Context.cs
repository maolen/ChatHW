using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class Context : DbContext
    {
        private string _connectionString = "Server=DESKTOP-NVDGPN3;Database=MessageDb;Trusted_Connection=true;";

        public Context() : base(_connectionString) { }
        public DbSet<Message> Messages { get; set; }
    }
}
