using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial.Models {
    public class AppDbContext : DbContext {
        //context class, important to have a context class
        //context class contains all classes you want to use
        //this class must inherit from another class

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items {get; set;}

        //two costructors because this is a console app
        //default constructor
        public AppDbContext() {

        }

        //constructor that takes one parameter, configuring how things will work
        public AppDbContext(DbContextOptions<AppDbContext> fred) : base(fred) { 

        }
        //in the dbcontext class a method called onconfiguring that takes dbcontextoptionsbuilder
        //doing something slightly different than what dbcontext is doing which is why we are overriding
        //protected is in between private and public, only makes sense when inheriting
        //OnConfiguring is called once, when app starts up. Tells EF about the database we are using
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            //if our db has not been configred yet then complete what is in our if statement
            //done one time when app starts up
            //tell to use sql db and use connection string to do so
            //local host is the server
            //sql express is the instance
            //two slashes means what comes after has special meaning

            if (!builder.IsConfigured) {
                builder.UseSqlServer("server=localhost\\sqlexpress;database=SalesDb1;trusted_connection=true;");
            }
        }
        //contains fluent api
        //must use fleunt api to have unique value on code
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Item>(
                fred => fred.HasIndex(fred => fred.Code)
                .IsUnique(true));
        }
    }
}
