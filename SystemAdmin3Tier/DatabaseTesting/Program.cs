using System;
using SystemAdmin_CRUD_Ops;

namespace DatabaseTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            CRUD_Operations test = new CRUD_Operations();
            //test.InsertUser("Joe", "Bloggs", "joe.bloggs@fdm.com", "abcd1234");
            //test.InsertUserAccessGroup("Admins");
            //test.InsertServiceRequest("Joe Bloggs", "Password Reset", "Forgot Password");

            //List<User> users = test.GetAllUsers();
            //foreach (User user in users)
            //{
            //    Console.WriteLine("User ID: " + user.UserID);
            //    Console.WriteLine("User First Name: " + user.FirstName);
            //}

            //List<UserAccessGroup> groups = test.GetAllAccessGroups();
            //foreach (UserAccessGroup group in groups)
            //{
            //    Console.WriteLine("Group ID: " + group.UserAccessGroupID);
            //    Console.WriteLine("Group Name: " + group.GroupName);
            //}

            //List<ServiceRequest> requests = test.GetAllServiceRequests();
            //foreach (ServiceRequest request in requests)
            //{
            //    Console.WriteLine("Request ID: " + request.ServiceRequestID);
            //    Console.WriteLine("Request from user: " + request.UserFullName);
            //}

            //test.BanUser(1);
            //List<User> users = test.GetAllUsers();
            //foreach (User user in users)
            //{
            //    Console.WriteLine("User ID: " + user.UserID);
            //    Console.WriteLine("Is this user banned? " + user.IsBanned);
            //}

            //test.LiftBanOnUser(1);
            //List<User> users = test.GetAllUsers();
            //foreach (User user in users)
            //{
            //    Console.WriteLine("User ID: " + user.UserID);
            //    Console.WriteLine("Is this user banned? " + user.IsBanned);
            //}

            //test.AddUserToGroup(1, 1);

            //test.RemoveUserFromGroup(1, 2);

            //test.AssignAdminToRequest(1, "Admin McAdminface");
            //List<ServiceRequest> requests = test.GetAllServiceRequests();
            //foreach (ServiceRequest request in requests)
            //{
            //    Console.WriteLine("Request ID: " + request.ServiceRequestID);
            //    Console.WriteLine("Assigned Admin Operator: " + request.AdminOperator);
            //    Console.WriteLine("Request Status: " + request.Status);
            //}

            //test.ProvideInfo(1, "Request will be complete within 24 hours.");
            //List<ServiceRequest> requests = test.GetAllServiceRequests();
            //foreach (ServiceRequest request in requests)
            //{
            //    Console.WriteLine("Request ID: " + request.ServiceRequestID);
            //    Console.WriteLine("Additional Info: " + request.AdditionalInfo);
            //}

            //test.MarkAsComplete(1);
            //List<ServiceRequest> requests = test.GetAllServiceRequests();
            //foreach (ServiceRequest request in requests)
            //{
            //    Console.WriteLine("Request ID: " + request.ServiceRequestID);
            //    Console.WriteLine("Request Status: " + request.Status);
            //}

            //test.DeleteUser(1);

            //test.DeleteAccessGroup(1);

            //test.DeleteServiceRequest(1);

            //test.RecordSuccessfulLogon();

            //test.RecordFailedLogon();

            //test.DeleteLogonAttempt(1);
            //test.DeleteLogonAttempt(3);

            //List<LogonAttempt> attempts = test.GetAllLogonAttempts();
            //foreach (LogonAttempt attempt in attempts)
            //{
            //    Console.WriteLine("LogonAttemptID: " + attempt.LogonAttemptID);
            //    Console.WriteLine("Logon Attempt Time: " + attempt.LogonDateTime);
            //    Console.WriteLine("Logon Attempt Successful? " + attempt.LogonSuccessful);
            //}



            //Add some sample data to the database
            //test.InsertUser("Joe", "Bloggs", "joe.bloggs@fdm.com", "abcd1234");
            //test.InsertUser("Jane", "Bloggs", "jane.bloggs@fdm.com", "1234abcd");
            //test.InsertUser("Jessica", "Bloggs", "jess.bloggs@fdm.com", "efgh5678");
            //test.InsertUserAccessGroup("Admins");
            //test.InsertServiceRequest("Joe Bloggs", "Password Reset", "Forgot Password");
            //test.InsertServiceRequest("Jessica Bloggs", "Password Reset", "Forgot Password");
            //test.InsertServiceRequest("Jane Bloggs", "Password Reset", "Forgot Password");
            //test.AddUserToGroup(2, 5);

            Console.ReadLine();
        }
    }
}
