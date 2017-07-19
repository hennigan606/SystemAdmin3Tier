using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemAdminClasses
{

    public class User
    {
        public User()
        {
        }

        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsBanned { get; set; }

        public virtual ICollection<AccessGroupWithUsers> Groups { get; set; }

    }



    public class UserAccessGroup
    {
        public UserAccessGroup()
        {
        }

        [Key]
        public int AccessGroupID { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<AccessGroupWithUsers> Groups { get; set; }

    }



    public class AccessGroupWithUsers
    {
        public AccessGroupWithUsers()
        {

        }

        public int UserID { get; set; }
        public int AccessGroupID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [ForeignKey("AccessGroupID")]
        public virtual UserAccessGroup UserAccessGroup { get; set; }

    }



    public class ServiceRequest
    {
        public ServiceRequest()
        {
        }

        [Key]
        public int RequestID { get; set; }
        public string UserFullName { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string AdminOperator { get; set; }
        public string AdditionalInfo { get; set; }
        public RequestStatus Status { get; set; }

    }

}
