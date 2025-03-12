using DB_First.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //To make a Raw sql method there is two ways 
            using NorthwindContext context = new NorthwindContext();
            //1) From sql Raw
            //Excute Select Statement
            //var count = 3;
            //var result = context.Categories.FromSqlRaw("select top(3) * from Categories", count);
            ////2)From sql interpolated
            //var categories = context.Categories.FromSqlInterpolated($"select top({count}) *from Categories");
            //foreach (var category in categories)
            //{
            //    Console.WriteLine(category.CategoryName);
            //}

            //For [ Excute , Insert , Update , Delete ] 
            //1) Excute sql Raw
            //var catId = 5;
            //context.Database.ExecuteSqlRaw("update Categories set CategoryName='jo' where CategoryID={0}",catId);
            ////2)Excute sql interpolated
            //context.Database.ExecuteSqlInterpolated($"update Categories set CategoryName='jo' where CategoryID={catId}");

            //To use Stored procedure
            NorthwindContextProcedures northwindContextProcedures=  new NorthwindContextProcedures(context);
            var res = northwindContextProcedures.SalesByCategoryAsync("Beverages", "1995").Result;
            foreach (var item in res)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
