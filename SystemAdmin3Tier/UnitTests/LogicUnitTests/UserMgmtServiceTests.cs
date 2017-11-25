using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using SystemAdminClasses;
using SystemAdmin_CRUD_Ops;

namespace UnitTests.LogicUnitTests
{
    [TestFixture]
    public class UserMgmtServiceTests
    {
        [Test]
        public void AddUser_CallsGetAllUsers_ExactlyOnce_WhenCalled()
        {
            //Arrange
            string TestFirstName = "Joe";
            string TestLastName = "Bloggs";
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.AddUser(TestFirstName, TestLastName, TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.GetAllUsers(), Times.Once);
        }


        [Test]
        public void AddUser_ReturnsFalse_WhenCalled_IfEmailProvidedBelongsToAUserOnTheSystem()
        {
            //Arrange
            string TestFirstName = "Joe";
            string TestLastName = "Bloggs";
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool expected = false;

            User TestUser = new User { Email = TestEmail };
            List<User> TestUsers = new List<User> { TestUser };

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            bool actual = UserMgmtService.AddUser(TestFirstName, TestLastName, TestEmail, TestPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AddUser_Calls_InsertUser_ExactlyOnce_WhenCalled_IfEmailDoesNotBelongToAUserOnSystem()
        {
            //Arrange
            string TestFirstName = "Joe";
            string TestLastName = "Bloggs";
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.AddUser(TestFirstName, TestLastName, TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.InsertUser(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>()));
        }


        [Test]
        public void AddUser_Calls_InsertUser_PassingDetailsProvided_ExactlyOnce_WhenCalled_IfEmailDoesNotBelongToAUserOnSystem()
        {
            //Arrange
            string TestFirstName = "Joe";
            string TestLastName = "Bloggs";
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.AddUser(TestFirstName, TestLastName, TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.InsertUser(TestFirstName, TestLastName,
                TestEmail, TestPassword));
        }


        [Test]
        public void AddUser_ReturnsTrue_WhenCalled_IfEmailProvidedDoesNotBelongToAUserOnSystem()
        {
            //Arrange
            string TestFirstName = "Joe";
            string TestLastName = "Bloggs";
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool expected = true;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
             bool actual = UserMgmtService.AddUser(
                 TestFirstName, TestLastName, TestEmail, TestPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void DeleteUser_CallsGetAllUsers_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.DeleteUser(TestUserID);

            //Assert
            MockCRUD.Verify(x => x.GetAllUsers(), Times.Once);
        }


        [Test]
        public void DeleteUser_Calls_RemoveUserFromGroup_ExactlyOnce_WhenCalled_IfUserIsInOneAccessGroup()
        {
            //Arrange
            int TestUserID = 1;
            User TestUser = new User { UserID = TestUserID, AccessGroups = new List<UserAccessGroup>() };
            UserAccessGroup TestGroup = new UserAccessGroup { UserAccessGroupID = 1 };
            TestUser.AccessGroups.Add(TestGroup);

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User> { TestUser });

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.DeleteUser(TestUserID);

            //Assert
            MockCRUD.Verify(x => x.RemoveUserFromGroup(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void DeleteUser_Calls_RemoveUserFromGroup_ExactlyTwice_WhenCalled_IfUserIsInTwoAccessGroups()
        {
            //Arrange
            int TestUserID = 1;
            User TestUser = new User { UserID = TestUserID, AccessGroups = new List<UserAccessGroup>() };

            UserAccessGroup TestGroup = new UserAccessGroup { UserAccessGroupID = 1 };
            UserAccessGroup TestGroup2 = new UserAccessGroup { UserAccessGroupID = 2 };
            TestUser.AccessGroups.Add(TestGroup);
            TestUser.AccessGroups.Add(TestGroup2);

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User> { TestUser });

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.DeleteUser(TestUserID);

            //Assert
            MockCRUD.Verify(x => x.RemoveUserFromGroup(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
        }


        [Test]
        public void DeleteUser_Calls_RemoveUserFromGroup_ExactlyOnce_WhenCalled_IfUserIsInOneAccessGroup_PassingInTheCorrectIDs()
        {
            //Arrange
            int TestUserID = 1;
            User TestUser = new User { UserID = TestUserID, AccessGroups = new List<UserAccessGroup>() };
            UserAccessGroup TestGroup = new UserAccessGroup { UserAccessGroupID = 1 };
            TestUser.AccessGroups.Add(TestGroup);

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User> { TestUser });

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.DeleteUser(TestUserID);

            //Assert
            MockCRUD.Verify(x => x.RemoveUserFromGroup(TestUser.UserID, TestGroup.UserAccessGroupID), Times.Once);
        }


        [Test]
        public void BanUser_CallsCRUD_BanUser_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.BanUser(TestUserID);

            //Assert
            MockCRUD.Verify(x => x.BanUser(It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void BanUser_CallsCRUD_BanUser_PassingTheUserIDProvided_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.BanUser(TestUserID);

            //Assert
            MockCRUD.Verify(x => x.BanUser(TestUserID), Times.Once);
        }


        [Test]
        public void LiftBanOnUser_CallsCRUD_LiftBanOnUser_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.LiftBanOnUser(TestUserID);

            //Assert
            MockCRUD.Verify(x => x.LiftBanOnUser(It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void LiftBanOnUser_CallsCRUD_LiftBanOnUser_PassingTheUserIDProvided_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.LiftBanOnUser(TestUserID);

            //Assert
            MockCRUD.Verify(x => x.LiftBanOnUser(TestUserID), Times.Once);
        }


        [Test]
        public void AddUserToGroup_CallsGetAllAccessGroups_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;
            int TestAccessGroupID = 1;

            User TestUser = new User { UserID = TestUserID };
            UserAccessGroup TestAccessGroup = new UserAccessGroup
            {
                UserAccessGroupID = TestAccessGroupID,
                Users = new List<User> { TestUser }
            };
            List<UserAccessGroup> TestAccessGroups = new List<UserAccessGroup> { TestAccessGroup };

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(TestAccessGroups);

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.AddUserToGroup(TestUserID, TestAccessGroupID);

            //Assert
            MockCRUD.Verify(x => x.GetAllAccessGroups(), Times.Once);
        }


        [Test]
        public void AddUserToGroup_DoesNotCallCRUD_AddUserToGroup_WhenCalled_IfUserIsAlreadyInTheGroup()
        {
            //Arrange
            int TestUserID = 1;
            int TestAccessGroupID = 1;

            User TestUser = new User { UserID = TestUserID };
            UserAccessGroup TestAccessGroup = new UserAccessGroup 
                {
                    UserAccessGroupID = TestAccessGroupID,
                    Users = new List<User> { TestUser }
                };
            List<UserAccessGroup> TestAccessGroups = new List<UserAccessGroup> { TestAccessGroup };
            
            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(TestAccessGroups);

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.AddUserToGroup(TestUserID, TestAccessGroupID);

            //Assert
            MockCRUD.Verify(x => x.AddUserToGroup(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
        }


        [Test]
        public void AddUserToGroup_CallsCRUD_AddUserToGroup_ExactlyOnce_WhenCalled_IfUserIsNotAlreadyInTheGroup()
        {
            //Arrange
            int TestUserID = 1;
            int TestAccessGroupID = 1;

            User TestUser = new User { UserID = 2 };
            UserAccessGroup TestAccessGroup = new UserAccessGroup 
                {
                    UserAccessGroupID = TestAccessGroupID,
                    Users = new List<User> { TestUser }
                };
            List<UserAccessGroup> TestAccessGroups = new List<UserAccessGroup> { TestAccessGroup };
            
            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(TestAccessGroups);
            MockCRUD.Setup(x => x.AddUserToGroup(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.AddUserToGroup(TestUserID, TestAccessGroupID);

            //Assert
            MockCRUD.Verify(x => x.AddUserToGroup(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void AddUserToGroup_CallsCRUD_AddUserToGroup_PassingTheCorrectIDs_ExactlyOnce_WhenCalled_IfUserIsNotAlreadyInTheGroup()
        {
            //Arrange
            int TestUserID = 1;
            int TestAccessGroupID = 1;

            User TestUser = new User { UserID = 2 };
            UserAccessGroup TestAccessGroup = new UserAccessGroup
            {
                UserAccessGroupID = TestAccessGroupID,
                Users = new List<User> { TestUser }
            };
            List<UserAccessGroup> TestAccessGroups = new List<UserAccessGroup> { TestAccessGroup };
            
            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(TestAccessGroups);
            MockCRUD.Setup(x => x.AddUserToGroup(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.AddUserToGroup(TestUserID, TestAccessGroupID);

            //Assert
            MockCRUD.Verify(x => x.AddUserToGroup(TestUserID, TestAccessGroupID), Times.Once);
        }


        [Test]
        public void RemoveUserFromGroup_CallsCRUD_RemoveUserFromGroup_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;
            int TestAccessGroupID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.RemoveUserFromGroup(TestUserID, TestAccessGroupID);

            //Assert
            MockCRUD.Verify(x => x.RemoveUserFromGroup(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void RemoveUserFromGroup_CallsCRUD_RemoveUserFromGroup_PassingTheCorrectIDs_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;
            int TestAccessGroupID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            UserManagementService UserMgmtService = new UserManagementService(MockCRUD.Object);

            //Act
            UserMgmtService.RemoveUserFromGroup(TestUserID, TestAccessGroupID);

            //Assert
            MockCRUD.Verify(x => x.RemoveUserFromGroup(TestUserID, TestAccessGroupID), Times.Once);
        }
    }
}
