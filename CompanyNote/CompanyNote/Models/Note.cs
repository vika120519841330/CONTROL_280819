﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyNote.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string HumanName { get; set; }
        public DateTime DateOfMeet { get; set; }
        public string Сomment { get; set; }

        //внешний ключ для связи с сущностью Company
        public Company CompanyId { get; set; }
    }
}