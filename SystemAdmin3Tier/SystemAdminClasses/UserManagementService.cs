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


            //Add the new user to the list of users in memory
            Users.Add(new User(FirstName, LastName, Email, Password));
            //Add the new user to the database.
            CRUD.InsertUser(FirstName, LastName, Email, Password);
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
                            //Remove access group from user in memory
                            user.AccessGroups.Remove(Group);
                            //Remove user from access group in database
                            CRUD.RemoveUserFromGroup(user.UserID, GroupID);
                        }
                    }
                }
            }


            //Now, delete the user from the system
            foreach (User user in Users)
            {
                //Find the user with the given UserID
                if (user.UserID == UserID)
                {
                    //Delete the user in memory
                    Users.Remove(user);
                    //Delete the user from the database
                    CRUD.DeleteUser(user.UserID);
                }
            }
        }



        
    }
}
