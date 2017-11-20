using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using SystemAdminClasses;
using SystemAdminDataModel;
using System;
using SystemAdmin_CRUD_Ops;

namespace UnitTests
{
    [TestFixture]
    public class LogicUnitTests
    {
        [Test]
        public void AttemptLogon_Calls_GetAllUsers_ExactlyOnce_WhenCalled_WhenNoUsersOnTheSystem()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            MockCRUD.Verify(x => x.GetAllUsers(), Times.Once);
        }


        [Test]
        public void AttemptLogon_Calls_RecordFailedLogon_ExactlyOnce_WhenCalled_WhenNoUsersOnTheSystem()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_WithNoUsersOnSystem()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "abcd1234";
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AttemptLogon_CallsGetAllUsers_ExactlyTwice_WhenCalled_WhenOneOrMoreUsersOnSystem()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User());
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            MockCRUD.Verify(x => x.GetAllUsers(), Times.Exactly(2));
        }


        [Test]
        public void AttemptLogon_Calls_RecordFailedLogon_ExactlyOnce_WhenCalled_IfEmailProvidedDoesNotBelongToUserOnSystem()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "abcd1234";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User());
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_IfEmailProvidedDoesNotBelongToUserOnSystem()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "abcd1234";
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User());
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AttemptLogon_CallsRecordFailedLogon_ExactlyOnce_WhenCalled_WithIncorrectPassword()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "Incorrect";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = testEmail, Password = "Password" });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_WithIncorrectPassword()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "Incorrect";
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = testEmail, Password = "Password" });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AttemptLogon_CallsRecordFailedLogon_ExactlyOnce_WhenCalled_IfUserIsBanned()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "abcd1234";
            bool testIfBanned = true;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = testEmail, Password = testPassword IsBanned = testIfBanned });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }


        [Test]
        public void AttemptLogon_ReturnsFalse_WhenCalled_IfUserIsBanned()
        {
            //Arrange
            string testEmail = "joe.bloggs@fdm.com";
            string testPassword = "abcd1234";
            bool testIfBanned = true;
            bool expected = false;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();
            List<User> TestUsers = new List<User>();
            TestUsers.Add(new User { Email = testEmail, Password = testPassword IsBanned = testIfBanned });
            MockCRUD.Setup(x => x.GetAllUsers()).Returns(TestUsers);

            LogonService logonService = new LogonService(MockCRUD.Object);

            //Act
            bool actual = logonService.AttemptLogon(testEmail, testPassword);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
