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
                TestEmail, TestPassword);
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
            User TestUser = new User { UserID = TestUserID };
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
    }
}
