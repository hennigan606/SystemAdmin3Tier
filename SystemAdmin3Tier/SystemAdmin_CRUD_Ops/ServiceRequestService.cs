using System;
using System.Collections.Generic;
using SystemAdminClasses;
using SystemAdminDataModel;

namespace SystemAdmin_CRUD_Ops
{
    //ServiceRequestTracker stores a list of all service requests and contains methods
    //for manipulating those requests, including creating requests, assigning an admin
    //operator to a request, providing info on the completion of a request and
    //marking a request as complete
    public class ServiceRequestService
    {
        private SystemAdminContext context;
        public CRUD_Operations CRUD;
        public List<ServiceRequest> Requests { get; set;}

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(
            "ServiceRequestService.cs");

        public ServiceRequestService()
        {
            CRUD = new CRUD_Operations(context);
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
            //Log the creation of a new request
            logger.Info("New service request submitted by user: " + UserFullName);
        }



        //Assigns an admin operator to a service request
        public void AssignOperator(int RequestID, String AdminName)
        {
            //Update the service request in the database
            CRUD.AssignAdminToRequest(RequestID, AdminName);
            //Update the list of service requests in memory to reflect change to database
            Requests = CRUD.GetAllServiceRequests();
            //Log the assignment of an admin operator to the request
            logger.Info(AdminName + " has been assigned to request number " + RequestID);
        }



        //Adds additional information on progress to completion to a service request
        public void ProvideInfo(int RequestID, String Info)
        {
            //Update the service request in the database
            CRUD.ProvideInfo(RequestID, Info);
            //Update the list of service requests in memory to reflect change to database
            Requests = CRUD.GetAllServiceRequests();
            //Log the addition of information to the service request
            logger.Info("The admin operator assigned to request number "
                + RequestID + " has added addtional information to the request.");
        }



        //Updates the status of a service request to Complete
        public void MarkAsComplete(int RequestID)
        {
            //Update the service request in the database
            CRUD.MarkAsComplete(RequestID);
            //Update the list of service requests in memory to reflect change to database
            Requests = CRUD.GetAllServiceRequests();
            //Log the completion of the service request
            logger.Info("Request number " + RequestID + " has been completed.");
        }
    }
}
