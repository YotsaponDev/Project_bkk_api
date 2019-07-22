using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_bkk_api.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        public DbSet<Test.TestEntity> test { get; set; }

        public object aaa (){
            var a = new { name = "Hello World!" };

            return a; 
        }
    }
}
