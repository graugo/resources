using EFHibrid.WebApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFHibrid.WebApi.Infrastructure.Context
{
    public class AdoSampleDbContext : DbContext
    {
        public AdoSampleDbContext(): base("name=AdoSampleDBEntities")
        {

        }

        public DbSet<AdoTable> AdoTables { get; set; }
    }
}