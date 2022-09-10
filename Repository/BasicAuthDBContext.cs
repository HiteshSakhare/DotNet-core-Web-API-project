using MedicalStoreManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Repository
{
    public class BasicAuthDBContext : DbContext
    {
        public BasicAuthDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserDetailsModel> userDetailsModels { get; set; }
        public DbSet<RolesModel> rolesModels { get; set; }
        public DbSet<LoginModel> loginModels { get; set; }
        public DbSet<StoreModel> storeModels { get; set; }

    }
}
