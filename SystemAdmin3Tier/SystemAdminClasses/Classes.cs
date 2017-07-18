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
        public string password { get; set; }
        public bool IsBanned { get; set; }

    }



    public class ServiceRequest
    {
        public ServiceRequest()
        {
        }

        public int RequestID { get; set; }
        public string UserFullName { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string AdminOperator { get; set; }
        public string AdditionalInfo { get; set; }
        public RequestStatus Status { get; set; }

    }

}
