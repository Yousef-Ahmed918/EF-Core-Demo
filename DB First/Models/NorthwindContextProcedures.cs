﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using DB_First.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DB_First.Models
{
    public partial class NorthwindContext
    {
        private INorthwindContextProcedures _procedures;

        public virtual INorthwindContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new NorthwindContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public INorthwindContextProcedures GetProcedures()
        {
            return Procedures;
        }
    }

    public partial class NorthwindContextProcedures : INorthwindContextProcedures
    {
        private readonly NorthwindContext _context;

        public NorthwindContextProcedures(NorthwindContext context)
        {
            _context = context;
        }

        public virtual async Task<List<SalesByCategoryResult>> SalesByCategoryAsync(string categoryName, string ordYear, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "CategoryName",
                    Size = 30,
                    Value = categoryName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "OrdYear",
                    Size = 8,
                    Value = ordYear ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SalesByCategoryResult>("EXEC @returnValue = [dbo].[SalesByCategory] @CategoryName = @CategoryName, @OrdYear = @OrdYear", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value); 

            return _;
        }
    }
}
