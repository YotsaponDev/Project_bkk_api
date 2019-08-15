using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<StaffEntity> staff { get; set; }
        public DbSet<LawsEntity> laws { get; set; }
        public DbSet<UserEntity> user { get; set; }
    }
}
