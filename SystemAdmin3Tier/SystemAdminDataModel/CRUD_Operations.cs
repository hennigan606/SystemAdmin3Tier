using SystemAdminClasses;
using System.Collections.Generic;
using System.Linq;
using System;

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
                context.Database.Log = Console.WriteLine;
                context.Users.Add(user);
                context.SaveChanges();
            }
        }



        public void InsertUserAccessGroup(string GroupName)
        {
            var userAccessGroup = new UserAccessGroup { GroupName = GroupName };

            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;
                context.AccessGroups.Add(userAccessGroup);
                context.SaveChanges();
            }
        }



        public void InsertServiceRequest(string UserFullName, string RequestType,
            string Details)
        {
            var serviceRequest = new ServiceRequest
            {
                UserFullName = UserFullName,
                RequestType = RequestType,
                Details = Details,
                AdminOperator = "",
                AdditionalInfo = "",
                Status = 0
            };

            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;
                context.ServiceRequests.Add(serviceRequest);
                context.SaveChanges();
            }
        }



        public List<User> GetAllUsers()
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;
                List<User> Users = context.Users.ToList();
                return Users;
            }
        }



        public List<UserAccessGroup> GetAllAccessGroups()
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;
                List<UserAccessGroup> AccessGroups = context.AccessGroups.ToList();
                return AccessGroups;
            }
        }



        public List<ServiceRequest> GetAllServiceRequests()
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;
                List<ServiceRequest> requests = context.ServiceRequests.ToList();
                return requests;
            }
        }



        public void BanUser(int UserID)
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;

                User user = context.Users.Where(n => n.UserID == UserID).FirstOrDefault();
                user.IsBanned = true;
                context.SaveChanges();
            }
        }



        public void LiftBanOnUser(int UserID)
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;

                User user = context.Users.Where(n => n.UserID == UserID).FirstOrDefault();
                user.IsBanned = false;
                context.SaveChanges();
            }
        }



        public void AddUserToGroup(int UserID, int GroupID)
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;

                User user = context.Users.Where(n => n.UserID == UserID).FirstOrDefault();
                UserAccessGroup accessGroup = context.AccessGroups.Where(n =>
                    n.UserAccessGroupID == GroupID).FirstOrDefault();

                accessGroup.Users.Add(user);

                context.AccessGroups.Add(accessGroup);
                context.SaveChanges();
            }
        }



        public void RemoveUserFromGroup(int UserID, int GroupID)
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;

                UserAccessGroup group = context.AccessGroups.Find(GroupID);
                User user = context.Users.Find(UserID);

                context.Entry(group).Collection("Users").Load();
                group.Users.Remove(user);
                context.SaveChanges();
            }
        }



        public void AssignAdminToRequest(int RequestID, string AdminName)
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;

                ServiceRequest request = context.ServiceRequests.Where(
                    n => n.ServiceRequestID == RequestID).FirstOrDefault();

                request.AdminOperator = AdminName;
                request.Status = (RequestStatus)1;
                context.SaveChanges();
            }
        }



        public void ProvideInfo(int RequestID, string AdditionalInfo)
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;

                ServiceRequest request = context.ServiceRequests.Where(
                    n => n.ServiceRequestID == RequestID).FirstOrDefault();

                request.AdditionalInfo = AdditionalInfo;
                context.SaveChanges();
            }
        }



        public void MarkAsComplete(int RequestID)
        {
            using (var context = new SystemAdminContext())
            {
                context.Database.Log = Console.WriteLine;

                ServiceRequest request = context.ServiceRequests.Where(
                    n => n.ServiceRequestID == RequestID).FirstOrDefault();

                request.Status = (RequestStatus)2;
                context.SaveChanges();
            }
        }




    }
}
