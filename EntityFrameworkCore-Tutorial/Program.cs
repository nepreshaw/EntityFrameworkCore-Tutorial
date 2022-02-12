using EntityFrameworkCore_Tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore_Tutorial {
    class Program {
        static void Main(string[] args) {
            //creating an instance of our dbcontext class
            AppDbContext context = new AppDbContext();

            var items = context.Items.ToList();

            foreach(var fred in items) {
                fred.Price = fred.Price * (1 + 0.10m);
            }
            context.SaveChanges();

             items = context.Items.ToList();

            foreach (var item in items){
                Console.WriteLine($"{item.Id,-5}{item.Code,-10}" +
                        $"{item.Name,10:c} {item.Price:c}");
            };

            //find reads by primary key

            //add a new order for kroger
            //var kroger = context.Customers.SingleOrDefault(fred => fred.Name.StartsWith("Krog"));
            //var order = new Order() {
            //    Id = 0,
            //    Description = "3rd order",
            //    Total = 2500,
            //    CustomerId = kroger.Id
            //};

            //context.Orders.Add(order);
            //context.SaveChanges();

            //var orders = context.Orders.Include(fred => fred.Customer).ToList();

            //foreach (var o in orders) {
            //    Console.WriteLine($"{o.Id,-5}{o.Description,-10}" +
            //        $"{o.Total,10:c} {o.Customer.Name}");
            //}

            //delete a customer
            //var amazon = context.Customers.SingleOrDefault(fred => fred.Name == "Amazon");
            //if(amazon != null) {
            //    context.Customers.Remove(amazon);
            //    context.SaveChanges();
            //}

            //find the customer
            //var max = context.Customers.Find(1);
            ////adds sales to max
            //max.Sales += 5000;
            ////save cahnges
            //context.SaveChanges();

            //add a new customer
            //var newCustomer = new Customer() {
            //    Id = 0, Name = "Kroger", Active = true, Sales = 3000000, Updated = new DateTime(2022,02,11)

            //};
            ////adds to entity framework collection, but not the database
            //context.Customers.Add(newCustomer);
            ////savechanges causes the db to be updated
            //context.SaveChanges();

            //read by primary key is more efficient than using a where clause
            //var customer = context.Customers.Find(2);
            //Console.WriteLine($"{customer.Name} {customer.Sales:c}");

            //read all customers
            //var customers = from fred in context.Customers
            //                //where fred.Sales < 100000
            //                select fred;

            //always the context.collection
            //List<Customer> customers = context.Customers.
            //                           Where(fred => fred.Sales < 100000)
            //                           .ToList();

            //foreach (var customer in customers) {
            //    Console.WriteLine($"{customer.Name,-20} {customer.Sales,10:c}");
            //}

        }
    }
}
