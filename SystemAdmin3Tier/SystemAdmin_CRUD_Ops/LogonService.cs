using System;
using System.Collections.Generic;
using SystemAdminClasses;

namespace SystemAdmin_CRUD_Ops
{
    public class LogonService
    {
        public CRUD_Operations CRUD = new CRUD_Operations();
        public List<UserAccessGroup> Groups { get; set; }
        public List<User> Users { get; set; }

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(
            "LogonService.cs");

        public LogonService()
        {
            Groups = CRUD.GetAllAccessGroups();
            Users = CRUD.GetAllUsers();
        }



        //Returns true if the user has entered a valid email and password,
        //and has permission to access the system. Otherwise, returns false
        public bool AttemptLogon(String Email, String Password)
        {
            //Return false if there are no users on the system
            if (Users.Count == 0)
            {
                //Record the failed logon attempt in the database
                CRUD.RecordFailedLogon();
                //Log the failed logon attempt
                logger.Info("User logon failed. There are no users on the system.");
                return false;
            }


            int countEmailMatches = 0;
            String checkPassword = "";
            int checkPermissionUserID = 0;
            bool checkPermissionUserIDFound = false;
            bool checkIfBanned = false;

            //Find the user in the system whose email matches the one provided
            foreach (User user in Users)
            {
                if (user.Email == Email)
                {
                    countEmailMatches++;
                    checkPassword = user.Password;
                    checkPermissionUserID = user.UserID;
                    checkIfBanned = user.IsBanned;
                }
            }


            //Return false if the email provided does not belong to a user on the system
            if (countEmailMatches < 1)
            {
                //Record the failed logon attempt in the database
                CRUD.RecordFailedLogon();
                //Log the failed logon attempt
                logger.Info("User logon failed. The email provided" +
                    " does not belong to a user in the system.");
                return false;
            }

            //Return false if the user has entered an incorrect password
            if (checkPassword != Password)
            {
                //Record the failed logon attempt in the database
                CRUD.RecordFailedLogon();
                //Log the failed logon attempt
                logger.Info("User logon failed. The password entered was incorrect.");
                return false;
            }

            //Return false if the user is temporarily banned
            if (checkIfBanned == true)
            {
                //Record the failed logon attempt in the database
                CRUD.RecordFailedLogon();
                //Log the failed logon attempt
                logger.Info("User logon failed. The user has been temporarily " +
                    "banned from the system.");
                return false;
            }

            //Return false if the user does not have permission to access the system
            foreach (UserAccessGroup Group in Groups)
            {
                //Find the admins access group
                if (Group.GroupName == "Admins")
                {
                    foreach (User user in Group.Users)
                    {
                        //Search the access group for a user with the ID of the
                        //user who is attempting to logon
                        if (user.UserID == checkPermissionUserID)
                        {
                            checkPermissionUserIDFound = true;
                        }
                    }
                }
            }

            //If the user is not in the admins access group, return false
            if (checkPermissionUserIDFound == false)
            {
                //Record the failed logon attempt in the database
                CRUD.RecordFailedLogon();
                //Log the failed logon attempt
                logger.Info("User logon failed. The user does not have permission " +
                    "to access this system.");
                return false;
            }

            //Record the successful logon attempt in the database
            CRUD.RecordSuccessfulLogon();
            //Log the successful logon attempt
            logger.Info("User Logon succeeded.");
            return true;
        }
    }
}