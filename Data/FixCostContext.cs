using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi_backend.Models;

namespace TodoApi_backend.Data {
    public class FixCostContext : DbContext {
        public FixCostContext(DbContextOptions<FixCostContext> options)
            : base(options) {
        }

        public DbSet<FixCost> FixCost { get; set; }
    }
}
