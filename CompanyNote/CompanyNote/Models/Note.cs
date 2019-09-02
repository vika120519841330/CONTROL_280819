using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyNote.Models
{
[ModelBinder(typeof(NoteModelBinder))]
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string HumanName { get; set; }
        public DateTime DateOfMeet { get; set; }
        public string Сomment { get; set; }

        //внешний ключ для связи с сущностью Company
        [Required]
        public int CompanyId { get; set; }

        //ссылка на другую сущность Company
       
        public Company Company { get; set; }
    }
}