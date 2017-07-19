using System.Collections.Generic;

namespace SystemAdminClasses
{

    public class User
    {
        public User()
        {
        }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsBanned { get; set; }

        public virtual ICollection<UserAccessGroup> AccessGroups { get; set; }

    }



    public class UserAccessGroup
    {
        public UserAccessGroup()
        {
        }

        public int UserAccessGroupID { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }



    public class ServiceRequest
    {
        public ServiceRequest()
        {
        }

        public int ServiceRequestID { get; set; }
        public string UserFullName { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string AdminOperator { get; set; }
        public string AdditionalInfo { get; set; }
        public RequestStatus Status { get; set; }

    }

}
