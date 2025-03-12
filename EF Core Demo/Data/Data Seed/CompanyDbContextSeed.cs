using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EF_Core_Demo.Data.Models;

namespace EF_Core_Demo.Data.Data_Seed
{
    internal static class CompanyDbContextSeed
    {
        public static void Seed(CompanyDBContext dbContext)
        {
            if (!dbContext.Departments.Any())
            {
                var departmentsData = File.ReadAllText("C:\\Users\\ayous\\source\\repos\\EF Core Demo\\EF Core Demo\\Data\\Data Seed\\departments.json");
                //To Convert From Json To C# Object
                var departments = JsonSerializer.Deserialize<List<Department>>(departmentsData);

                if (departments?.Count > 0)
                {
                    foreach (var department in departments)
                    {
                        dbContext.Departments.Add(department);
                    }
                    dbContext.SaveChanges();
                }
            }

            if (!dbContext.Employees.Any())
            {
                var employeesData = File.ReadAllText("C:\\Users\\ayous\\source\\repos\\EF Core Demo\\EF Core Demo\\Data\\Data Seed\\employees.json");
                //To Convert From Json To C# Object
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);

                if (employees?.Count > 0)
                {
                    foreach (var employee in employees)
                    {
                        dbContext.Employees.Add(employee);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
 