using CompanyNote.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompanyNote.Initializer
{
    public class CompanyDbInitializer
    {
        readonly ApplicationDbContext context;
        public CompanyDbInitializer()
        {
            context = new ApplicationDbContext();
            if (context.Companies.Count()==3)
            {
                context.Companies.RemoveRange(context.Companies);
                this.Init(context);
            }
            
        }

        protected void Init(ApplicationDbContext context)
        {
            Company c1 = new Company()
            {
                Id = 1,
                CompanyName = "ОДО<<Промтехнология>>"
            };
            context.Companies.Add(c1);
            Company c2 = new Company()
            {
                Id = 2,
                CompanyName = "ООО<<Модная Галактика>>"
            };
            context.Companies.Add(c2);
            Company c3 = new Company()
            {
                Id = 3,
                CompanyName = "ИП Иванов П.П."
            };
            context.Companies.Add(c3);
            context.SaveChanges();
        }
    }
}
