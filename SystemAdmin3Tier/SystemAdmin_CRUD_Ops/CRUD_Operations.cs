using SystemAdminClasses;
using SystemAdminDataModel;
using System.Collections.Generic;
using System.Linq;
using System;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SystemAdmin_CRUD_Ops
{
    public interface ICRUD_Operations
    {
        void InsertUser(string FirstName, string LastName,
            string Email, string Password);
        void InsertUserAccessGroup(string GroupName);
        void InsertServiceRequest(string UserFullName, string RequestType,
            string Details);
        List<User> GetAllUsers();
        List<UserAccessGroup> GetAllAccessGroups();
        List<ServiceRequest> GetAllServiceRequests();
        void BanUser(int UserID);
        void LiftBanOnUser(int UserID);
        void AddUserToGroup(int UserID, int GroupID);
        void RemoveUserFromGroup(int UserID, int GroupID);
        void AssignAdminToRequest(int RequestID, string AdminName);
        void ProvideInfo(int RequestID, string AdditionalInfo);
        void MarkAsComplete(int RequestID);
        void DeleteUser(int UserID);
        void DeleteAccessGroup(int AccessGroupID);
        void DeleteServiceRequest(int RequestID);
        void RecordSuccessfulLogon();
        void RecordFailedLogon();
        void DeleteLogonAttempt(int LogonAttemptID);
        List<LogonAttempt> GetAllLogonAttempts();
    }

    public class CRUD_Operations : ICRUD_Operations
    {

        private SystemAdminContext context;

        public CRUD_Operations(SystemAdminContext context)
        {
            this.context = context;
        }



        public List<User> GetAllUsers()
        {
            context.Database.Log = Console.WriteLine;
            List<User> Users = context.Users.ToList();
            return Users;
        }



        public List<UserAccessGroup> GetAllAccessGroups()
        {
            context.Database.Log = Console.WriteLine;
            List<UserAccessGroup> AccessGroups = context.AccessGroups.ToList();
            return AccessGroups;
        }



        public List<ServiceRequest> GetAllServiceRequests()
        {
            context.Database.Log = Console.WriteLine;
            List<ServiceRequest> requests = context.ServiceRequests.ToList();
            return requests;
        }



        public List<LogonAttempt> GetAllLogonAttempts()
        {
            context.Database.Log = Console.WriteLine;

            List<LogonAttempt> attempts = context.LogonAttempts.ToList();
            return attempts;
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

            context.Database.Log = Console.WriteLine;
            context.Users.Add(user);
            context.SaveChanges(); 
        }



        public void InsertUserAccessGroup(string GroupName)
        {
            var userAccessGroup = new UserAccessGroup { GroupName = GroupName };
            
            context.Database.Log = Console.WriteLine;
            context.AccessGroups.Add(userAccessGroup);
            context.SaveChanges();   
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

            context.Database.Log = Console.WriteLine;
            context.ServiceRequests.Add(serviceRequest);
            context.SaveChanges();
        }



        public void RecordSuccessfulLogon()
        {
            context.Database.Log = Console.WriteLine;

            LogonAttempt success = new LogonAttempt();
            success.LogonSuccessful = true;
            success.LogonDateTime = DateTime.Now;

            context.LogonAttempts.Add(success);
            context.SaveChanges();
        }



        public void RecordFailedLogon()
        {
            context.Database.Log = Console.WriteLine;

            LogonAttempt failed = new LogonAttempt();
            failed.LogonSuccessful = false;
            failed.LogonDateTime = DateTime.Now;

            context.LogonAttempts.Add(failed);
            context.SaveChanges();
        }



        public void DeleteUser(int UserID)
        {
            context.Database.Log = Console.WriteLine;

            User user = context.Users.Find(UserID);
            context.Users.Remove(user);
            context.SaveChanges();
        }



        public void DeleteAccessGroup(int AccessGroupID)
        {
            context.Database.Log = Console.WriteLine;

            UserAccessGroup group = context.AccessGroups.Find(AccessGroupID);
            context.AccessGroups.Remove(group);
            context.SaveChanges();
        }



        public void DeleteServiceRequest(int RequestID)
        {
            context.Database.Log = Console.WriteLine;

            ServiceRequest request = context.ServiceRequests.Find(RequestID);
            context.ServiceRequests.Remove(request);
            context.SaveChanges();
        }        



        public void DeleteLogonAttempt(int LogonAttemptID)
        {
            context.Database.Log = Console.WriteLine;

            LogonAttempt attempt = context.LogonAttempts.Find(LogonAttemptID);

            context.LogonAttempts.Remove(attempt);
            context.SaveChanges();
        }



        public void BanUser(int UserID)
        {
            context.Database.Log = Console.WriteLine;

            //  User user = context.Users.Where(n => n.UserID == UserID).FirstOrDefault();
            User user = context.Users.Find(n => n.UserID == UserID).FirstOrDefault();
            user.IsBanned = true;
            context.SaveChanges();
        }



        public void LiftBanOnUser(int UserID)
        {
            context.Database.Log = Console.WriteLine;

            //  User user = context.Users.Where(n => n.UserID == UserID).FirstOrDefault();
            User user = context.Users.Find(n => n.UserID == UserID).FirstOrDefault();
            user.IsBanned = false;
            context.SaveChanges();
        }



        public void AddUserToGroup(int UserID, int GroupID)
        {
            context.Database.Log = Console.WriteLine;

            //  User user = context.Users.Where(n => n.UserID == UserID).FirstOrDefault();
            //  UserAccessGroup accessGroup = context.AccessGroups.Where(n =>
            //      n.UserAccessGroupID == GroupID).FirstOrDefault();

            User user = context.Users.Find(n => n.UserID == UserID).FirstOrDefault();
            UserAccessGroup accessGroup = context.AccessGroups.Find(n =>
                n.UserAccessGroupID == GroupID).FirstOrDefault();

            accessGroup.Users.Add(user);
            context.SaveChanges();
        }



        public void RemoveUserFromGroup(int UserID, int GroupID)
        {
            context.Database.Log = Console.WriteLine;

            UserAccessGroup group = context.AccessGroups.Find(GroupID);
            User user = context.Users.Find(UserID);

            context.Entry(group).Collection("Users").Load();
            group.Users.Remove(user);
            context.SaveChanges();
        }



        public void AssignAdminToRequest(int RequestID, string AdminName)
        {
            context.Database.Log = Console.WriteLine;

            ServiceRequest request = context.ServiceRequests.Where(
                n => n.ServiceRequestID == RequestID).FirstOrDefault();

            request.AdminOperator = AdminName;
            request.Status = (RequestStatus)1;
            context.SaveChanges();
        }



        public void ProvideInfo(int RequestID, string AdditionalInfo)
        {
            context.Database.Log = Console.WriteLine;

            ServiceRequest request = context.ServiceRequests.Where(
                n => n.ServiceRequestID == RequestID).FirstOrDefault();

            request.AdditionalInfo = AdditionalInfo;
            context.SaveChanges();
        }



        public void MarkAsComplete(int RequestID)
        {
            context.Database.Log = Console.WriteLine;

            ServiceRequest request = context.ServiceRequests.Where(
                n => n.ServiceRequestID == RequestID).FirstOrDefault();

            request.Status = (RequestStatus)2;
            context.SaveChanges();
        }
        
    }
}
