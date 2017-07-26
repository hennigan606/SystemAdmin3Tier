using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemAdmin_CRUD_Ops;

namespace SystemAdminClasses
{
    //ServiceRequestTracker stores a list of all service requests and contains methods
    //for manipulating those requests, including creating requests, assigning an admin
    //operator to a request, providing info on the completion of a request and
    //marking a request as complete
    public class ServiceRequestService
    {
        CRUD_Operations CRUD = new CRUD_Operations();

        List<ServiceRequest> Requests = new List<ServiceRequest>();

        public ServiceRequestService()
        {
            Requests = CRUD.GetAllServiceRequests();
        }



        //Adds a new request to the system
        public void CreateRequest(string UserFullName, string RequestType,
            string Details)
        {
            //Add the new request to the database
            CRUD.InsertServiceRequest(UserFullName, RequestType, Details);
            //Update the list of service requests in memory to include new
            //request added to the database
            Requests = CRUD.GetAllServiceRequests();
        }



        
    }
}
