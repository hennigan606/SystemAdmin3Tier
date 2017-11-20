using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using SystemAdminClasses;
using SystemAdmin_CRUD_Ops;

namespace UnitTests.LogicUnitTests
{
    [TestFixture]
    public class LogonServiceTests
    {
        [Test]
        public void AttemptLogon_Calls_GetAllUsers_ExactlyOnce_WhenCalled_WhenNoUsersOnTheSystem()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.GetAllUsers(), Times.Once);
        }


        [Test]
        public void AttemptLogon_Calls_RecordFailedLogon_ExactlyOnce_WhenCalled_WhenNoUsersOnTheSystem()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_WithNoUsersOnSystem()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AttemptLogon_CallsGetAllUsers_ExactlyTwice_WhenCalled_WhenOneOrMoreUsersOnSystem()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User());
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.GetAllUsers(), Times.Exactly(2));
        }


        [Test]
        public void AttemptLogon_Calls_RecordFailedLogon_ExactlyOnce_WhenCalled_IfEmailProvidedDoesNotBelongToUserOnSystem()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User());
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_IfEmailProvidedDoesNotBelongToUserOnSystem()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User());
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AttemptLogon_CallsRecordFailedLogon_ExactlyOnce_WhenCalled_WithIncorrectPassword()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "Incorrect";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = TestEmail, Password = "Password" });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_WithIncorrectPassword()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "Incorrect";
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = TestEmail, Password = "Password" });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AttemptLogon_CallsRecordFailedLogon_ExactlyOnce_WhenCalled_IfUserIsBanned()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool testIfBanned = true;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = TestEmail, Password = TestPassword, IsBanned = testIfBanned });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_IfUserIsBanned()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool testIfBanned = true;
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = TestEmail, Password = TestPassword, IsBanned = testIfBanned });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AttemptLogon_CallsGetAllAccessGroups_ExactlyOnce_WhenCalled_WithValidUserCredentials()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool testIfBanned = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = TestEmail, Password = TestPassword, IsBanned = testIfBanned });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            List<UserAccessGroup> testAccessGroups = new List<UserAccessGroup>();
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(testAccessGroups);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.GetAllAccessGroups(), Times.Once);
        }


        [Test]
        public void AttemptLogon_CallsRecordFailedLogonExactlyOnce_WhenCalled_IfUserIsNotInAdminsGroup()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool testIfBanned = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            User TestUser = new User { UserID = 1, Email = TestEmail, Password = TestPassword, IsBanned = testIfBanned };
            List<User> TestUsers = new List<User> { TestUser };
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            UserAccessGroup TestAccessGroup = new UserAccessGroup { GroupName = "Admins", Users = new List<User>() };
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(new List<UserAccessGroup> { TestAccessGroup });

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_IfUserIsNotInAdminsGroup()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool testIfBanned = false;
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            User TestUser = new User { UserID = 1, Email = TestEmail, Password = TestPassword, IsBanned = testIfBanned };
            List<User> TestUsers = new List<User> { TestUser };
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            UserAccessGroup TestAccessGroup = new UserAccessGroup { GroupName = "Admins", Users = new List<User>() };
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(new List<UserAccessGroup> { TestAccessGroup });

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AttemptLogon_CallsRecordSuccessfulLogonExactlyOnce_WhenCalled_IfAllUserCredentialsAreValid()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool testIfBanned = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            User TestUser = new User { UserID = 1, Email = TestEmail, Password = TestPassword, IsBanned = testIfBanned };
            List<User> TestUsers = new List<User> { TestUser };
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            UserAccessGroup TestAccessGroup = new UserAccessGroup { GroupName = "Admins", Users = TestUsers };
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(new List<UserAccessGroup> { TestAccessGroup });

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordSuccessfulLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsTrue_WhenCalled_IfAllUserCredentialsAreValid()
        {
            //Arrange
            string TestEmail = "joe.bloggs@fdm.com";
            string TestPassword = "abcd1234";
            bool testIfBanned = false;
            bool expected = true;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            User TestUser = new User { UserID = 1, Email = TestEmail, Password = TestPassword, IsBanned = testIfBanned };
            List<User> TestUsers = new List<User> { TestUser };
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            UserAccessGroup TestAccessGroup = new UserAccessGroup { GroupName = "Admins", Users = TestUsers };
            MockCRUD.Setup(x => x.GetAllAccessGroups()).Returns(new List<UserAccessGroup> { TestAccessGroup });

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(TestEmail, TestPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
