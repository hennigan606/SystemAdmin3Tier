using System.Collections.Generic;
using NUnit.Framework;
using SystemAdmin_CRUD_Ops;
using Moq;
using System.Data.Entity;
using SystemAdminClasses;
using SystemAdminDataModel;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {
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
            //CollectionAssert.AreEqual(expected, actual);

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("Joe", actual[0].FirstName);
            Assert.AreEqual("Jane", actual[1].FirstName);

            Assert.AreEqual(expected[0].UserID, actual[0].UserID);
            Assert.AreEqual(expected[0].FirstName, actual[0].FirstName);
            Assert.AreEqual(expected[0].LastName, actual[0].LastName);
            Assert.AreEqual(expected[0].Email, actual[0].Email);
            Assert.AreEqual(expected[0].Password, actual[0].Password);
            Assert.AreEqual(expected[0].IsBanned, actual[0].IsBanned);
        }



        //[Test]
        //public void RemoveUserFromGroup_Calls_RemoveOnDbSet_And_SaveChangesOnContext_WhenCalled()
        //{
        //    //Arrange
        //    var mockDbSet = new Mock<DbSet<UserAccessGroup>>();
        //    var mockDbSet2 = new Mock<DbSet<User>>();
        //    var mockContext = new Mock<SystemAdminContext>();

        //    mockContext.Setup(x => x.AccessGroups).Returns(mockDbSet.Object);
        //    mockContext.Setup(x => x.Users).Returns(mockDbSet2.Object);

        //    var classUnderTest = new CRUD_Operations(mockContext.Object);

        //    //Act
        //    classUnderTest.RemoveUserFromGroup(1, 1);

        //    //Assert
        //    mockDbSet.Verify(x => x.Find(1), Times.Once);
        //    mockDbSet2.Verify(x => x.Find(1), Times.Once);
        //    mockContext.Verify(x => x.SaveChanges(), Times.Once);
        //}



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
        public void BanUser_Calls_FirstOrDefaultOnDbSet_And_SaveChangesOnContext()
        {
            //Arrange
            int UserID = 1;
            User user = new User
                {
                    UserID = 1,
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    Email = "joe.bloggs@fdm.com",
                    Password = "abcd1234",
                    IsBanned = false
                }

            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockDbSet.Setup(x => x.FirstOrDefault()).Returns(user);
            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);

            CRUD_Operations classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.BanUser(UserID);

            //Assert
            mockDbSet.Verify(x => x.FirstOrDefault(), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        
    }
}
