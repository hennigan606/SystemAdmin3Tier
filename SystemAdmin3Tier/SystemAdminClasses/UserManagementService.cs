using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemAdmin_CRUD_Ops;

namespace SystemAdminClasses
{
    //UserManagementService stores a list of all users and has methods
    //for manipulating both individual users and the list of users
    //including adding users, deleting users, temporarily banning users
    //and setting the access permissions of a user
    public class UserManagementService
    {
        public CRUD_Operations CRUD = new CRUD_Operations();
        public List<User> Users { get; set; }


        public UserManagementService()
        {
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
                    return false;
                }
            }


            //Add the new user to the list of users in the database
            CRUD.InsertUser(FirstName, LastName, Email, Password);
            //Update the list of users in memory to reflect new user in database
            Users = CRUD.GetAllUsers();
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
        }



        //Temporarily bans the user with the given UserID from accessing the system
        public void BanUser(int UserID)
        {
            //Ban the user in the database
            CRUD.BanUser(UserID);
            //Update the list of users in memory to reflect change in database
            Users = CRUD.GetAllUsers();
        }



        //Removes the temporary ban on the user with the given UserID accessing the system
        public void LiftBanOnUser(int UserID)
        {
            //Lift the ban on the user in the database
            CRUD.LiftBanOnUser(UserID);
            //Update the list of users in memory to reflect change in database
            Users = CRUD.GetAllUsers();
        }



        //Adds the given UserID to the User Access Group with the given ID
        public void AddUserToGroup(int UserID, int UserAccessGroupID)
        {  
            List<UserAccessGroup> groups = CRUD.GetAllAccessGroups();

            foreach (UserAccessGroup Group in groups)
            {
                //Find the access group with the given ID
                if (Group.UserAccessGroupID == UserAccessGroupID)
                {
                    foreach (User user in Group.Users)
                    {
                        //Check if the user with the given ID is already in the group
                        if (user.UserID == UserID)
                        {
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
                        }
                    }
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
        }
        
    }
}
