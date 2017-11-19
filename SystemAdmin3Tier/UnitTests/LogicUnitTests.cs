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
        public void AttemptLogon_Calls_GetAllUsers_And_RecordFailedLogon_BothExactlyOnce_WhenCalled_WhenNoUsersOnTheSystem()
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
            MockCRUD.Verify(x => x.RecordFailedLogon(), Times.Once);
        }
    }
}
