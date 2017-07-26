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
        public CRUD_Operations CRUD = new CRUD_Operations();

        public List<ServiceRequest> Requests { get; set;}

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



        //Assigns an admin operator to a service request
        public void AssignOperator(int RequestID, String AdminName)
        {
            //Update the service request in the database
            CRUD.AssignAdminToRequest(RequestID, AdminName);
            //Update the list of service requests in memory to reflect change to database
            Requests = CRUD.GetAllServiceRequests();
        }



        //Adds additional information on progress to completion to a service request
        public void ProvideInfo(int RequestID, String Info)
        {
            //Update the service request in the database
            CRUD.ProvideInfo(RequestID, Info);
            //Update the list of service requests in memory to reflect change to database
            Requests = CRUD.GetAllServiceRequests();
        }



        //Updates the status of a service request to Complete
        public void MarkAsComplete(int RequestID)
        {
            //Update the service request in the database
            CRUD.MarkAsComplete(RequestID);
            //Update the list of service requests in memory to reflect change to database
            Requests = CRUD.GetAllServiceRequests();
        }
    }
}
