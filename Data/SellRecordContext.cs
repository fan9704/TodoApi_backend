using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi_backend.Models;

namespace TodoApi_backend.Data
{
    public class SellRecordContext : DbContext
    {
        public SellRecordContext (DbContextOptions<SellRecordContext> options)
            : base(options)
        {
        }

        public DbSet<TodoApi_backend.Models.SellRecord> SellRecord { get; set; }
    }
}
