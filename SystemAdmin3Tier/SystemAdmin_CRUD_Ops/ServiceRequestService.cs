using System;

namespace SystemAdmin_CRUD_Ops
{
    //ServiceRequestTracker stores a list of all service requests and contains methods
    //for manipulating those requests, including creating requests, assigning an admin
    //operator to a request, providing info on the completion of a request and
    //marking a request as complete
    public class ServiceRequestService
    {
        private ICRUD_Operations CRUD;

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(
            "ServiceRequestService.cs");

        public ServiceRequestService(ICRUD_Operations iCRUD)
        {
            CRUD = iCRUD;
        }



        //Adds a new request to the system
        public void CreateRequest(string UserFullName, string RequestType,
            string Details)
        {
            //Add the new request to the database
            CRUD.InsertServiceRequest(UserFullName, RequestType, Details);

            //Log the creation of a new request
            logger.Info("New service request submitted by user: " + UserFullName);
        }



        //Assigns an admin operator to a service request
        public void AssignOperator(int RequestID, String AdminName)
        {
            //Update the service request in the database
            CRUD.AssignAdminToRequest(RequestID, AdminName);

            //Log the assignment of an admin operator to the request
            logger.Info(AdminName + " has been assigned to request number " + RequestID);
        }



        //Adds additional information on progress to completion to a service request
        public void ProvideInfo(int RequestID, String Info)
        {
            //Update the service request in the database
            CRUD.ProvideInfo(RequestID, Info);

            //Log the addition of information to the service request
            logger.Info("The admin operator assigned to request number "
                + RequestID + " has added addtional information to the request.");
        }



        //Updates the status of a service request to Complete
        public void MarkAsComplete(int RequestID)
        {
            //Update the service request in the database
            CRUD.MarkAsComplete(RequestID);

            //Log the completion of the service request
            logger.Info("Request number " + RequestID + " has been completed.");
        }
    }
}
