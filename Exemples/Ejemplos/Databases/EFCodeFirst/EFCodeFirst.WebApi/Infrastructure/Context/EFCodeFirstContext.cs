using EFCodeFirst.WebApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirst.WebApi.Infrastructure.Context
{
    public class EFCodeFirstContext : DbContext
    {
        public DbSet<EfCodeFistModel> EfCodeFists { get; set; }
    }
}