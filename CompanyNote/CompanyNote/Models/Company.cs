using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyNote.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }
}