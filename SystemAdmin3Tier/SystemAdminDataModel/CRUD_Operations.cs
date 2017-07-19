using SystemAdminClasses;

namespace SystemAdminDataModel
{
    public class CRUD_Operations
    {

        public CRUD_Operations()
        {
        }



        public void InsertUser(string FirstName, string LastName,
            string Email, string Password)
        {
            var user = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password,
                IsBanned = false
            };

            using (var context = new SystemAdminContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }



        public void InsertUserAccessGroup(string GroupName)
        {
            var userAccessGroup = new UserAccessGroup { GroupName = GroupName };

            using (var context = new SystemAdminContext())
            {
                context.AccessGroups.Add(userAccessGroup);
                context.SaveChanges();
            }
        }



        public void InsertServiceRequest(string UserFullName, string RequestType,
            string Details, string AdminOperator, string AdditionalInfo)
        {
            var serviceRequest = new ServiceRequest
            {
                UserFullName = UserFullName,
                RequestType = RequestType,
                Details = Details,
                AdminOperator = AdminOperator,
                AdditionalInfo = AdditionalInfo,
                Status = 0
            };

            using (var context = new SystemAdminContext())
            {
                context.ServiceRequests.Add(serviceRequest);
                context.SaveChanges();
            }
        }
    }
}
