using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Demo.Data.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e=>e.Id);
            builder.Property<string>("Address")
                .HasColumnType("varchar(50)")
                .HasDefaultValue("Cairo"); //Column Not In Model

            builder.OwnsOne(e => e.DetailedAddress/*address=>address.WithOwner() //its like one to one*/);
        
            builder.Property(e=>e.Id).UseIdentityColumn();
        }
    }
}
