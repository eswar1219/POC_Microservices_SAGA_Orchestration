using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<UserAccount> UserAccount { get; set; }

        public DbSet<Payment> PaymentDetail { get; set; }

        public DbSet<Notification> NotificationDetail { get; set; }



    }
}
