using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Demo.Data.Models
{
    //[Owned]
    public class Address
    {
        public int? BlockNum { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country{ get; set; }
    }
}
