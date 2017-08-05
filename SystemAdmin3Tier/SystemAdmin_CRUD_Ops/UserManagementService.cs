using System;
using System.Collections.Generic;
using System.Linq;
using SystemAdminClasses;
using SystemAdminDataModel;

namespace SystemAdmin_CRUD_Ops
{
    //UserManagementService stores a list of all users and has methods
    //for manipulating both individual users and the list of users
    //including adding users, deleting users, temporarily banning users
    //and setting the access permissions of a user
    public class UserManagementService
    {
        private SystemAdminContext context;
        public CRUD_Operations CRUD;
        public List<User> Users { get; set; }

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(
            "UserManagementService.cs");

        public UserManagementService()
        {
            context = new SystemAdminContext();
            CRUD = new CRUD_Operations(context);
            Users = CRUD.GetAllUsers();
        }



        //Adds a new user, if the email provided does not belong to an existing user
        //Returns true if the user was added, returns false if the user could not be added.
        public bool AddUser(String FirstName, String LastName, String Email, String Password)
        {
            foreach (User user in Users)
            {
                //If the email provided matches the email of a user that already
                //exists in the system, return false
                if (user.Email.Equals(Email))
                {
                    //Log the failure to add the new user
                    logger.Info("Add new user operation failed as a user already exists on the "
                        + "system with the email provided.");
                    return false;
                }
            }


            //Add the new user to the list of users in the database
            CRUD.InsertUser(FirstName, LastName, Email, Password);
            //Update the list of users in memory to reflect new user in database
            Users = CRUD.GetAllUsers();
            //Log the addition of the new user to the system
            logger.Info("New user " + FirstName + " " + LastName +
                " has been added to the system.");
            return true;
        }



        //Deletes the user with the given UserID from the system
        public void DeleteUser(int UserID)
        {
            //First, check if the user is a member of any access groups
            //If they are, remove them from the group
            foreach (User user in Users)
            {
                //Find the user with the given UserID
                if (user.UserID == UserID)
                {
                    //Check if the user is a member of any access groups
                    if (user.AccessGroups.Count > 0)
                    {
                        foreach (UserAccessGroup Group in user.AccessGroups)
                        {
                            int GroupID = Group.UserAccessGroupID;
                            //Remove user from access group in database
                            CRUD.RemoveUserFromGroup(user.UserID, GroupID);
                        }
                    }
                }
            }


            //Now, delete the user from the system
            //Delete the user from the database
            CRUD.DeleteUser(UserID);
            //Update list of users in memory to reflect change to database
            Users = CRUD.GetAllUsers();
            //Log the deletion of the user
            logger.Info("User with ID " + UserID + " has been deleted from the system.");
        }



        //Temporarily bans the user with the given UserID from accessing the system
        public void BanUser(int UserID)
        {
            //Ban the user in the database
            CRUD.BanUser(UserID);
            //Update the list of users in memory to reflect change in database
            Users = CRUD.GetAllUsers();
            //Log that the user has been temporarily banned
            logger.Info("User with ID " + UserID + " has been temporarily banned " +
                "from accessing the system.");
        }



        //Removes the temporary ban on the user with the given UserID accessing the system
        public void LiftBanOnUser(int UserID)
        {
            //Lift the ban on the user in the database
            CRUD.LiftBanOnUser(UserID);
            //Update the list of users in memory to reflect change in database
            Users = CRUD.GetAllUsers();
            //Log that the ban on the user has been lifted
            logger.Info("Temporary ban on user with ID " + UserID + " from accessing the " +
                "system has been removed.");
        }



        //Adds the given UserID to the User Access Group with the given ID
        public void AddUserToGroup(int UserID, int UserAccessGroupID)
        {
            //Find the access group with the given ID
            UserAccessGroup group = CRUD.GetAllAccessGroups().Where(x
                => x.UserAccessGroupID == UserAccessGroupID).FirstOrDefault();

            foreach (User user in group.Users)
            {
                //Check if the user with the given ID is already in the group
                if (user.UserID == UserID)
                {
                    //Log that no action was taken as the user is already in the group
                    logger.Info("Add user to group operation cancelled as user "
                        + user.FirstName + " " + user.LastName + " is already a member of group "
                        + group.GroupName);
                    //If the user is already in the access group, do nothing
                    return;
                }
                else
                {
                    //Otherwise, add the user to the access group
                    //Add the user to the group in the database
                    CRUD.AddUserToGroup(UserID, UserAccessGroupID);
                    //Update the list of users in memory to reflect change to database
                    Users = CRUD.GetAllUsers();
                    //Log the addition of the user to the access group
                    logger.Info("User with ID " + UserID + " has been added to the " +
                        "user access group with ID " + UserAccessGroupID);
                    return;
                }
            }
        }



        //Removes the given UserID from the user access group with the given ID
        public void RemoveUserFromGroup(int UserID, int UserAccessGroupID)
        {
            //Remove the user from the access group in the database
            CRUD.RemoveUserFromGroup(UserID, UserAccessGroupID);
            //Update the list of users in memory to reflect change to database
            Users = CRUD.GetAllUsers();
            //Log the removal of the user from the access group
            logger.Info("User with ID " + UserID + " has been removed from " +
                "user access group with ID " + UserAccessGroupID);
        }
        
    }
}
