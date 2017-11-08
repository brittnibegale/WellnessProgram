using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VirtualWellnessProgram.Models;

namespace VirtualWellnessProgram.UpdateCustomer
{
    public class UpdateCalories
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Customer EditCalories(double calories, Customer customer)
        {
            customer.CurrentCalorieCount += calories;
            customer.CaloriesPending = true;

            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return customer;
        }
    }
}