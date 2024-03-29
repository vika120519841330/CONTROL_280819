﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyNote.Models
{
    public class NoteModelBinder : IModelBinder
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Company FindCompanyById(int id)
        {
            Company comp = db.Companies.Find(id);
            return comp;
        }
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            // Получаем поставщик значений
            var valueProvider = bindingContext.ValueProvider;

            // получаем данные по одному полю
            //ValueProviderResult vprId = valueProvider.GetValue("CompanyId");

            // получаем данные по остальным полям
            string email = (string)valueProvider.GetValue("Email").ConvertTo(typeof(string));
            string humanName = (string)valueProvider.GetValue("HumanName").ConvertTo(typeof(string));
            DateTime dateOfMeet = (DateTime)valueProvider.GetValue("DateOfMeet").ConvertTo(typeof(DateTime));
            int сompanyId = (int)valueProvider.GetValue("CompanyId").ConvertTo(typeof(int));
            string comment = (string)valueProvider.GetValue("Сomment").ConvertTo(typeof(string));
            Company company = this.FindCompanyById(сompanyId);
           
            Note note = new Note()
            {
                Email = email,
                HumanName = humanName,
                DateOfMeet = dateOfMeet,
                CompanyId = сompanyId,
                Company = company,
                Сomment = comment
            };
            return note;
        }
    }
}
    