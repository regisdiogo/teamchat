using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamChat.Core.Model;

namespace TeamChat.Repository.Context
{
    public class TeamChatDbContext : DbContext
    {
        public TeamChatDbContext(DbContextOptions options) : base(options) { }

        protected TeamChatDbContext() { }

        public DbSet<User> Users { get; set; }

    }
}
