using System.Data.Entity;
using SystemAdminClasses;

namespace SystemAdminDataModel
{
    public class SystemAdminContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccessGroup> AccessGroups { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
