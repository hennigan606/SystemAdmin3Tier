using System.Data.Entity;
using SystemAdminClasses;

namespace SystemAdminDataModel
{
    public class SystemAdminContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccessGroup> AccessGroups { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<LogonAttempt> LogonAttempts { get; set; }
    }
}
