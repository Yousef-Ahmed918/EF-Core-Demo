using EF_Core_Demo.Data;
using EF_Core_Demo.Data.Data_Seed;
using EF_Core_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Demo
{
    //Date Seeding 
    //its data that been seeded and be there when running the program
    //Seed is been done at the First use

    //Navigational Property (Lookup Property)
    //doesnt exist in the database
    //by default wont be loaded 

    //when to use which 
    //exclude the explicit loading from the equation
    //for the lazy loading needs to use the package and activate it in the configuration
    //for the Eager use Include 
    //use the Eager loading if i have (one to one relationship mandatory)
    //if i have a collection
    //if the relation is aggrigation use (Lazy Loading) dont always need to load the two entites together 
    //if the relation composition use (Eager Loading) two entities cant be seperated

    internal class Program
    {
        static void Main(string[] args)
        {
            using (CompanyDBContext companyDBContext = new CompanyDBContext())
            {
                #region Add
                //Employee emp01 = new Employee() { Name = "Nada", Age = 26, Salary = 9_000, Email = "Nada@gmail.com" };
                //Employee emp02 = new Employee() {Id=1,  Name = "Rana", Age = 26, Salary = 8_000, Email = "Rana@gmail.com" };

                //Console.WriteLine(companyDBContext.Entry(emp01).State);//Detached
                //Console.WriteLine(companyDBContext.Entry(emp02).State);//Detached

                //companyDBContext.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.TrackAll;//Default Behaviour

                //Employee emp04 = new Employee() { Id = 3, Name = "Omar", Age = 26, Salary = 8_000, Email = "Rana@gmail.com" };

                //companyDBContext.Set<Employee>().Add(emp04); // .toTable instead of dbSet
                // companyDBContext.Employees.Add(emp01); //as Local Sequence 
                // companyDBContext.Add(emp02);
                //companyDBContext.Entry(emp01).State=EntityState.Added;

                #endregion
                #region Get And Update
                //var emp = (from e in companyDBContext.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //if(emp is not null)
                //{
                //    Console.WriteLine(companyDBContext.Entry(emp).State);
                //    Console.WriteLine(emp.Name);
                //    Console.WriteLine(emp.Email);
                //    emp.Salary = 10_000;
                //    Console.WriteLine(companyDBContext.Entry(emp).State);

                //}
                #endregion

                #region Get And Remove

                //var emp = (from e in companyDBContext.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //if (emp is not null)
                //{
                //    Console.WriteLine(companyDBContext.Entry(emp).State);
                //    Console.WriteLine(emp.Name);

                //    //companyDBContext.Set<Employee>().Remove(emp); // .toTable instead of dbSet
                //    /*companyDBContext.Employees.Remove(emp); *///as Local Sequence 
                //    companyDBContext.Remove(emp);
                //    //companyDBContext.Entry(emp).State = EntityState.Deleted;
                //    //
                //    Console.WriteLine(companyDBContext.Entry(emp).State);

                //}
                #endregion
                //companyDBContext.SaveChanges();

               CompanyDbContextSeed.Seed(companyDBContext);


                #region Navigational property EX 01
                //var emp = (from e in companyDBContext.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //if (emp is not null)
                //{
                //    Console.WriteLine($"Employee: {emp.Name} , Department : {emp.Department?.Name ?? "No Department"}");
                //    //in this example there is a department name but its not loaded (the navigational property not loaded)

                //}

                //var dept = (from d in companyDBContext.Departments
                //            where d.DepartmentId == 3
                //            select d).FirstOrDefault();

                //if (dept is not null)
                //{
                //    Console.WriteLine($"department ID: {dept.DepartmentId} , Department Name : {dept?.Name ?? "No Department"}");
                //    //in this example there is a department name but its not loaded (the navigational property not loaded)
                //    foreach (var e in dept.Employees)
                //    {
                //        Console.WriteLine($"Employee Name: {e.Name}");
                //    }
                //} 
                #endregion

                #region Explicit Loading
                //it makes more than one request (one request for the main property and one for the navigational property)
                //get the data i need when i needed it 

                //var emp = (from e in companyDBContext.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //companyDBContext.Entry(emp).Reference(nameof(Employee.Department)).Load();
                ////Reference if single
                ////Collection if plural

                //if (emp is not null)
                //{
                //    Console.WriteLine($"Employee: {emp.Name} , Department : {emp.Department?.Name ?? "No Department"}");
                //    //in this example there is a department name but its not loaded (the navigational property not loaded)

                //}

                //var dept = (from d in companyDBContext.Departments
                //            where d.DepartmentId == 1
                //            select d).FirstOrDefault();
                //companyDBContext.Entry(dept).Collection(nameof(Department.Employees)).Load();

                //if (dept is not null)
                //{
                //    Console.WriteLine($"department ID: {dept.DepartmentId} , Department Name : {dept?.Name ?? "No Department"}");
                //    //in this example there is a department name but its not loaded (the navigational property not loaded)
                //    foreach (var e in dept.Employees)
                //    {
                //        Console.WriteLine($"Employee Name: {e.Name}");
                //    }
                //}
                #endregion

                #region Eager Loading
                //Loads everything
                //its a concept
                //all happens in one query 
                //the idea of it is the (join)

                //var emp = (from e in companyDBContext.Employees
                //           .Include(e=>e.Department)
                //           //.ThenInclude(e => e.Employees) //if i want to include another entity
                //           where e.Id == 3
                //           select e).FirstOrDefault();




                //if (emp is not null)
                //{
                //    Console.WriteLine($"Employee: {emp.Name} , Department : {emp.Department?.Name ?? "No Department"}");
                //    //in this example there is a department name but its not loaded (the navigational property not loaded)

                //}

                //var dept = (from d in companyDBContext.Departments.Include(d => d.Employees)
                //            where d.DepartmentId == 1
                //            select d).FirstOrDefault();

                //if (dept is not null)
                //{
                //    Console.WriteLine($"department ID: {dept.DepartmentId} , Department Name : {dept?.Name ?? "No Department"}");
                //    //in this example there is a department name but its not loaded (the navigational property not loaded)
                //    foreach (var e in dept.Employees)
                //    {
                //        Console.WriteLine($"Employee Name: {e.Name}");
                //    }
                //}
                #endregion


                #region Lazy Loading
                //Its like the explict loading 
                //put it happens implictly
                //to use it need to install package EntityFrameWorkCore.Proxies
                //optionsBuilder.UseLazyLoadingProxies(true);  add this line in CompanyDBContext OnConfiguration
                //Needs the navigational property to be vitual
                //Make the Classes public

                //var emp = (from e in companyDBContext.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();

                //if (emp is not null)
                //{
                //    Console.WriteLine($"Employee: {emp.Name} , Department : {emp.Department?.Name ?? "No Department"}");
                //    //in this example there is a department name but its not loaded (the navigational property not loaded)

                //}

                //var dept = (from d in companyDBContext.Departments
                //            where d.DepartmentId == 1
                //            select d).FirstOrDefault();

                //if (dept is not null)
                //{
                //    Console.WriteLine($"department ID: {dept.DepartmentId} , Department Name : {dept?.Name ?? "No Department"}");
                //    //in this example there is a department name but its not loaded (the navigational property not loaded)
                //    foreach (var e in dept.Employees)
                //    {
                //        Console.WriteLine($"Employee Name: {e.Name}");
                //    }
                //}
                #endregion

                #region Join - Join() , GroupJoin() , left outer join , cross join
                //join is better with the query syntax than fluent syntax
                #region Join
                //var result = from d in companyDBContext.Departments
                //             join e in companyDBContext.Employees
                //             on d.DepartmentId equals e.DepartmentId //write equals not = 
                //             select new
                //             {
                //                 EmployeeID = e.Id,
                //                 EmployeeName = e.Name,
                //                 DepartmentID = d.DepartmentId,
                //                 DepartmentName = d.Name

                //             };
                //result = companyDBContext.Departments
                //    .Join(companyDBContext.Employees
                //    , d => d.DepartmentId
                //    , e => e.DepartmentId
                //    , (d, e) => new
                //    {
                //        EmployeeID = e.Id,
                //        EmployeeName = e.Name,
                //        DepartmentID = d.DepartmentId,
                //        DepartmentName = d.Name

                //    }
                //    );

                //foreach (var e in result)
                //{
                //    Console.WriteLine(e);
                //} 
                #endregion

                #region GroupJoin
                //var result = companyDBContext.Departments
                //    .GroupJoin(companyDBContext.Employees
                //    , d => d.DepartmentId
                //    , e => e.DepartmentId
                //    , (department, employees) => new
                //    {
                //        department, 
                //        employees
                //    });



                //result = from d in companyDBContext.Departments
                //         join e in companyDBContext.Employees
                //       on d.DepartmentId equals e.DepartmentId
                //       into employees
                //         select new
                //         {
                //             department = d,
                //             employees = employees
                //         };

                //foreach (var d in result)
                //{
                //    Console.WriteLine($"Department:{d.department.DepartmentId}, {d.department.Name}");
                //    foreach(var e in d.employees)
                //    {
                //        Console.WriteLine($"Employee:{e.Id} , {e.Name}" );
                //    }
                //}

                #endregion

                #region Left / Right Outer Join
                //Group join is considered left outer join 

                //var result = companyDBContext.Departments
                //    .GroupJoin(companyDBContext.Employees
                //    , d => d.DepartmentId
                //    , e => e.DepartmentId
                //    , (department, employees) => new
                //    {
                //        department,
                //        employees
                //    });

                //foreach (var d in result)
                //{
                //    Console.WriteLine($"Department:{d.department.DepartmentId}, {d.department.Name}");
                //    foreach (var e in d.employees)
                //    {
                //        Console.WriteLine($"Employee:{e.Id} , {e.Name}");
                //    }
                //}


                //Select Many
                //var result = companyDBContext.Departments
                //    .GroupJoin(companyDBContext.Employees
                //    , d => d.DepartmentId
                //    , e => e.DepartmentId
                //    , (department, employees) => new
                //    {
                //        department,
                //        employees=employees.DefaultIfEmpty() //to display department even if there is no employees on the department
                //    }).SelectMany(gColl=> gColl.employees, (gColl, emp) => new //here gColl works on emplyees 
                //    {
                //        emp, 
                //        d=gColl.department
                //    });


                //result = from d in companyDBContext.Departments
                //         join e in companyDBContext.Employees
                //         on d.DepartmentId equals e.DepartmentId
                //         into employees
                //         from emp in employees.DefaultIfEmpty()
                //         select new
                //         {
                //            emp,
                //            d
                //         };

                //foreach (var d in result)
                //{
                //    Console.WriteLine($"{d.d.Name} : {d.emp?.Name??"No Emp"}");

                //}

                #endregion


                #region Cross join
                //to make dummy data for testing 
                //var crossJoinResult = from d in companyDBContext.Departments
                //                      from e in companyDBContext.Employees
                //                      select new
                //                      {
                //                          e,
                //                          d
                //                      };

                //var crossJoinResult02 = companyDBContext.Departments.SelectMany(
                //     department => companyDBContext.Employees.Select(emp => new
                //     {
                //         emp,
                //         department
                //     }));

                //foreach (var result in crossJoinResult02)
                //{
                //    Console.WriteLine($"{result.emp.Name}  {result.department.Name}");
                //}

                #endregion
                #endregion


                #region Mapping Views
                //To create View
                //Make a empty migration and add the sql code in it 
                //and create a class for the view 
                //in the companyDbcontext on model creating add 
                //modelBuilder.Entity<Class Name>().ToView("View Name").HasNoKey();
                //now call the view normally
                //var result = companyDBContext.EmployeesDepartmentsView;

                //foreach (var re in result)
                //{
                //    Console.WriteLine($"{re.DepartmentId} - {re.DepartmentName} - {re?.EmployeeId??0} - {re?.EmployeeName??"No Name"}");
                //}
                #endregion


                #region DB First

                #endregion

            }

        }

    }
}
