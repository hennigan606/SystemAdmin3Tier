using System.Collections.Generic;
using NUnit.Framework;
using SystemAdmin_CRUD_Ops;
using Moq;
using System.Data.Entity;
using SystemAdminClasses;
using SystemAdminDataModel;
using System.Linq;
using System;

namespace UnitTests
{
    [TestFixture]
    public class DbUnitTests
    {
        [Test]
        public void Test_GetAllUsers_ReturnsAllUsers()
        {
            //Arrange
            var expected = new List<User>
            {
                new User
                {
                    UserID = 1,
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    Email = "joe.bloggs@fdm.com",
                    Password = "abcd1234",
                    IsBanned = false
                },

                new User
                {
                    UserID = 2,
                    FirstName = "Jane",
                    LastName = "Bloggs",
                    Email = "jane.bloggs@fdm.com",
                    Password = "1234abcd",
                    IsBanned = false
                }
            };

            var testData = new List<User>
            {
                new User
                {
                    UserID = 1,
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    Email = "joe.bloggs@fdm.com",
                    Password = "abcd1234",
                    IsBanned = false
                },

                new User
                {
                    UserID = 2,
                    FirstName = "Jane",
                    LastName = "Bloggs",
                    Email = "jane.bloggs@fdm.com",
                    Password = "1234abcd",
                    IsBanned = false
                }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<User>>();
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(testData.Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(testData.Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

            var mockContext = new Mock<SystemAdminContext>();
            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            var actual = classUnderTest.GetAllUsers();

            //Assert
            Assert.AreEqual(2, actual.Count);

            Assert.AreEqual(expected[0].UserID, actual[0].UserID);
            Assert.AreEqual(expected[0].FirstName, actual[0].FirstName);
            Assert.AreEqual(expected[0].LastName, actual[0].LastName);
            Assert.AreEqual(expected[0].Email, actual[0].Email);
            Assert.AreEqual(expected[0].Password, actual[0].Password);
            Assert.AreEqual(expected[0].IsBanned, actual[0].IsBanned);
        }



        [Test]
        public void Test_GetAllAccessGroups_ReturnsAllAccessGroups()
        {
            //Arrange
            var expected = new List<UserAccessGroup>
            {
                new UserAccessGroup
                {
                    UserAccessGroupID = 1,
                    GroupName = "Test"
                },

                new UserAccessGroup
                {
                    UserAccessGroupID = 2,
                    GroupName = "Test test"
                }
            };

            var testData = new List<UserAccessGroup>
            {
                new UserAccessGroup
                {
                    UserAccessGroupID = 1,
                    GroupName = "Test"
                },

                new UserAccessGroup
                {
                    UserAccessGroupID = 2,
                    GroupName = "Test test"
                }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<UserAccessGroup>>();
            mockDbSet.As<IQueryable<UserAccessGroup>>().Setup(m => m.Provider).Returns(testData.Provider);
            mockDbSet.As<IQueryable<UserAccessGroup>>().Setup(m => m.Expression).Returns(testData.Expression);
            mockDbSet.As<IQueryable<UserAccessGroup>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            mockDbSet.As<IQueryable<UserAccessGroup>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

            var mockContext = new Mock<SystemAdminContext>();
            mockContext.Setup(x => x.AccessGroups).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            var actual = classUnderTest.GetAllAccessGroups();

            //Assert
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].UserAccessGroupID, actual[0].UserAccessGroupID);
            Assert.AreEqual(expected[1].UserAccessGroupID, actual[1].UserAccessGroupID);
            Assert.AreEqual(expected[0].GroupName, actual[0].GroupName);
            Assert.AreEqual(expected[1].GroupName, actual[1].GroupName);
        }



        [Test]
        public void Test_GetAllServiceRequests_Returns_AllServiceRequests_WhenCalled()
        {
            //Arrange
            var expected = new List<ServiceRequest>
            {
                new ServiceRequest
                {
                    UserFullName = "Joe Bloggs",
                    RequestType = "Password Reset",
                    Details = "Forgot Password",
                    AdminOperator = "Joe Admin",
                    AdditionalInfo = "N/A",
                    Status = 0
                },

                new ServiceRequest
                {
                    UserFullName = "Jane Bloggs",
                    RequestType = "Password Reset",
                    Details = "Oops, Forgot Password",
                    AdminOperator = "Joe Admin",
                    AdditionalInfo = "N/A",
                    Status = 0
                }
            };

            var testData = new List<ServiceRequest>
            {
                new ServiceRequest
                {
                    UserFullName = "Joe Bloggs",
                    RequestType = "Password Reset",
                    Details = "Forgot Password",
                    AdminOperator = "Joe Admin",
                    AdditionalInfo = "N/A",
                    Status = 0
                },

                new ServiceRequest
                {
                    UserFullName = "Jane Bloggs",
                    RequestType = "Password Reset",
                    Details = "Oops, Forgot Password",
                    AdminOperator = "Joe Admin",
                    AdditionalInfo = "N/A",
                    Status = 0
                }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<ServiceRequest>>();
            mockDbSet.As<IQueryable<ServiceRequest>>().Setup(m => m.Provider).Returns(testData.Provider);
            mockDbSet.As<IQueryable<ServiceRequest>>().Setup(m => m.Expression).Returns(testData.Expression);
            mockDbSet.As<IQueryable<ServiceRequest>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            mockDbSet.As<IQueryable<ServiceRequest>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

            var mockContext = new Mock<SystemAdminContext>();
            mockContext.Setup(x => x.ServiceRequests).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            var actual = classUnderTest.GetAllServiceRequests();

            //Assert
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].ServiceRequestID, actual[0].ServiceRequestID);
            Assert.AreEqual(expected[1].UserFullName, actual[1].UserFullName);
            Assert.AreEqual(expected[0].RequestType, actual[0].RequestType);
            Assert.AreEqual(expected[1].Details, actual[1].Details);
            Assert.AreEqual(expected[0].AdminOperator, actual[0].AdminOperator);
            Assert.AreEqual(expected[1].AdditionalInfo, actual[1].AdditionalInfo);
            Assert.AreEqual(expected[0].Status, actual[0].Status);
        }



        [Test]
        public void Test_GetAllLogonAttempts_ReturnsAllLogonAttempts_WhenCalled()
        {
            //Arrange
            var expected = new List<LogonAttempt>
            {
                new LogonAttempt
                {
                    LogonAttemptID = 1,
                    LogonDateTime = DateTime.Now,
                    LogonSuccessful = true
                },

                new LogonAttempt
                {
                    LogonAttemptID = 2,
                    LogonDateTime = DateTime.Now,
                    LogonSuccessful = false
                }
            };

            var testData = new List<LogonAttempt>
            {
                new LogonAttempt
                {
                    LogonAttemptID = 1,
                    LogonDateTime = DateTime.Now,
                    LogonSuccessful = true
                },

                new LogonAttempt
                {
                    LogonAttemptID = 2,
                    LogonDateTime = DateTime.Now,
                    LogonSuccessful = false
                }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<LogonAttempt>>();
            mockDbSet.As<IQueryable<LogonAttempt>>().Setup(m => m.Provider).Returns(testData.Provider);
            mockDbSet.As<IQueryable<LogonAttempt>>().Setup(m => m.Expression).Returns(testData.Expression);
            mockDbSet.As<IQueryable<LogonAttempt>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            mockDbSet.As<IQueryable<LogonAttempt>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

            var mockContext = new Mock<SystemAdminContext>();
            mockContext.Setup(x => x.LogonAttempts).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            var actual = classUnderTest.GetAllLogonAttempts();

            //Assert
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].LogonAttemptID, actual[0].LogonAttemptID);
            Assert.AreEqual(expected[1].LogonDateTime, actual[1].LogonDateTime);
            Assert.AreEqual(expected[0].LogonSuccessful, actual[0].LogonSuccessful);
        }



        [Test]
        public void InsertUser_Calls_AddOnDbSet_And_SaveChangesOnContext_WhenCalled()
        {
            //Arrange
            string FirstName = "Michael";
            string LastName = "Hennigan";
            string Email = "michael.hennigan@fdm.com";
            string Password = "1234abcd";

            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.InsertUser(FirstName, LastName, Email, Password);

            //Assert
            mockDbSet.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void InsertUserAccessGroup_Calls_AddOnDbSet_And_SaveChangesOnContext_WhenCalled()
        {
            //Arrange
            string GroupName = "Test";

            var mockDbSet = new Mock<DbSet<UserAccessGroup>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.AccessGroups).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.InsertUserAccessGroup(GroupName);

            //Assert
            mockDbSet.Verify(x => x.Add(It.IsAny<UserAccessGroup>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void InsertServiceRequest_Calls_AddOnDbSet_And_SaveChangesOnContext_WhenCalled()
        {
            //Arrange
            string UserFullName = "Joe Bloggs";
            string RequestType = "Password Reset";
            string Details = "Forgot Password";

            var mockDbSet = new Mock<DbSet<ServiceRequest>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.ServiceRequests).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.InsertServiceRequest(UserFullName, RequestType, Details);

            //Assert
            mockDbSet.Verify(x => x.Add(It.IsAny<ServiceRequest>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void RecordSuccessfulLogon_Calls_AddOnDbSet_And_SaveChangesOnContext_WhenCalled()
        {
            //Arrange
            var mockDbSet = new Mock<DbSet<LogonAttempt>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.LogonAttempts).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.RecordSuccessfulLogon();

            //Assert
            mockDbSet.Verify(x => x.Add(It.IsAny<LogonAttempt>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void RecordFailedLogon_Calls_AddOnDbSet_And_SaveChangesOnContext_WhenCalled()
        {
            //Arrange
            var mockDbSet = new Mock<DbSet<LogonAttempt>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.LogonAttempts).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.RecordFailedLogon();

            //Assert
            mockDbSet.Verify(x => x.Add(It.IsAny<LogonAttempt>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void DeleteUser_Calls_RemoveOnDbSet_And_SaveChangesOnContext()
        {
            //Arrange
            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.DeleteUser(1);

            //Assert
            mockDbSet.Verify(x => x.Remove(It.IsAny<User>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void DeleteAccessGroup_Calls_RemoveOnDbSet_And_SaveChangesOnContext()
        {
            //Arrange
            var mockDbSet = new Mock<DbSet<UserAccessGroup>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.AccessGroups).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.DeleteAccessGroup(1);

            //Assert
            mockDbSet.Verify(x => x.Remove(It.IsAny<UserAccessGroup>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void DeleteServiceRequest_Calls_RemoveOnDbSet_And_SaveChangesOnContext()
        {
            //Arrange
            var mockDbSet = new Mock<DbSet<ServiceRequest>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.ServiceRequests).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.DeleteServiceRequest(1);

            //Assert
            mockDbSet.Verify(x => x.Remove(It.IsAny<ServiceRequest>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void DeleteLogonAttempt_Calls_RemoveOnDbSet_And_SaveChangesOnContext()
        {
            //Arrange
            var mockDbSet = new Mock<DbSet<LogonAttempt>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.LogonAttempts).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.DeleteLogonAttempt(1);

            //Assert
            mockDbSet.Verify(x => x.Remove(It.IsAny<LogonAttempt>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void BanUser_Calls_FindOnDbSet_And_SaveChangesOnContext()
        {
            //Arrange
            int UserID = 1;

            //  User user = new User
            //  {
            //      UserID = 1,
            //      FirstName = "Joe",
            //      LastName = "Bloggs",
            //      Email = "joe.bloggs@fdm.com",
            //      Password = "abcd1234",
            //      IsBanned = false
            //  };

            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<SystemAdminContext>();

            //  mockDbSet.Setup(x => x.Find(It.IsAny<User>())).Returns(user);
            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);

            CRUD_Operations classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.BanUser(UserID);

            //Assert
            mockDbSet.Verify(x => x.Find(It.IsAny<User>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void LiftBanOnUser_Calls_FindOnDbSet_And_SaveChangesOnContext()
        {
            //Arrange
            int UserID = 1;

        //    User user = new User
        //    {
        //        UserID = 1,
        //        FirstName = "Joe",
        //        LastName = "Bloggs",
        //        Email = "joe.bloggs@fdm.com",
        //        Password = "abcd1234",
        //        IsBanned = false
        //    };

            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<SystemAdminContext>();

        //    mockDbSet.Setup(x => x.FirstOrDefault()).Returns(user);
            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);

            CRUD_Operations classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.LiftBanOnUser(UserID);

            //Assert
            mockDbSet.Verify(x => x.Find(It.IsAny<User>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void AddUserToGroup_Calls_FindOnBothDbSets_And_SaveChangesOnContext()
        {
            //Arrange
            int TestUserID = 1;
            int TestAccessGroupID = 1;

            var MockUserDbSet = new Mock<DbSet<User>>();
            var MockAccessGroupDbSet = new Mock<DbSet<UserAccessGroup>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.Users).Returns(MockUserDbSet.Object);
            mockContext.Setup(x => x.AccessGroups).Returns(MockAccessGroupDbSet.Object)

            CRUD_Operations classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.AddUserToGroup(TestUserID, TestAccessGroupID);

            //Assert
            MockUserDbSet.Verify(x => x.Find(It.IsAny<User>()), Times.Once);
            MockAccessGroupDbSet.Verify(x => x.Find(It.IsAny<UserAccessGroup>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void RemoveUserFromGroup_Calls_FindOnBothDbSets_And_SaveChangesOnContext_WhenCalled()
        {
            //Arrange
            int TestUserID = 1;
            int TestAccessGroupID = 1;

            var MockUserDbSet = new Mock<DbSet<User>>();
            var MockAccessGroupDbSet = new Mock<DbSet<UserAccessGroup>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.Users).Returns(MockUserDbSet.Object);
            mockContext.Setup(x => x.AccessGroups).Returns(MockAccessGroupDbSet.Object)

            CRUD_Operations classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.RemoveUserFromGroup(TestUserID, TestAccessGroupID);

            //Assert
            MockUserDbSet.Verify(x => x.Find(It.IsAny<User>()), Times.Once);
            MockAccessGroupDbSet.Verify(x => x.Find(It.IsAny<UserAccessGroup>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void AssignAdminToRequest_CallsFindOnDbSetAndSaveChangesOnContext_WhenCalled()
        {
            //Arrange
            int TestRequestID = 1;
            string TestAdminName = "Joe Admin";

            var MockDbSet = new Mock<DbSet<ServiceRequest>>();
            var MockContext = new Mock<SystemAdminContext>();

            MockContext.Setup(x => x.ServiceRequests).Returns(MockDbSet.Object);

            CRUD_Operations ClassUnderTest = new CRUD_Operations(MockContext.Object);

            //Act
            ClassUnderTest.AssignAdminToRequest(TestRequestID, TestAdminName);

            //Assert
            MockDbSet.Verify(x => x.Find(It.IsAny<ServiceRequest>()), Times.Once);
            MockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        public void ProvideInfo_CallsFindOnDbSetAndSaveChangesOnContext_WhenCalled()
        {
            //Arrange
            int TestRequestID = 1;
            string TestInfo = "Request will be complete in 2 hours";

            var MockDbSet = new Mock<DbSet<ServiceRequest>>();
            var MockContext = new Mock<SystemAdminContext>();

            MockContext.Setup(x => x.ServiceRequests).Returns(MockDbSet.Object);

            CRUD_Operations ClassUnderTest = new CRUD_Operations(MockContext.Object);

            //Act
            ClassUnderTest.ProvideInfo(TestRequestID, TestInfo);

            //Assert
            MockDbSet.Verify(x => x.Find(It.IsAny<ServiceRequest>()), Times.Once);
            MockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        public void MarkAsComplete_CallsFindOnDbSetAndSaveChangesOnContext_WhenCalled()
        {
            //Arrange
            int TestRequestID = 1;

            var MockDbSet = new Mock<DbSet<ServiceRequest>>();
            var MockContext = new Mock<SystemAdminContext>();

            MockContext.Setup(x => x.ServiceRequests).Returns(MockDbSet.Object);

            CRUD_Operations ClassUnderTest = new CRUD_Operations(MockContext.Object);

            //Act
            ClassUnderTest.MarkAsComplete(TestRequestID);

            //Assert
            MockDbSet.Verify(x => x.Find(It.IsAny<ServiceRequest>()), Times.Once);
            MockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
