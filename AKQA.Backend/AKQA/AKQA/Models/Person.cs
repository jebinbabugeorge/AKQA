using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AKQA.Models
{
    public class Person
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Salary { get; set; }

        public string SalaryInWords { get; set; }
    }
}