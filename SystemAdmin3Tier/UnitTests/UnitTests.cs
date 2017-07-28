﻿using System;
using NUnit.Framework;
using SystemAdmin_CRUD_Ops;
using Moq;
using System.Data.Entity;
using SystemAdminClasses;
using SystemAdminDataModel;

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
                    UserID = 1,
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
                    UserID = 1,
                    FirstName = "Jane",
                    LastName = "Bloggs",
                    Email = "jane.bloggs@fdm.com",
                    Password = "1234abcd",
                    IsBanned = false
                }
            }.AsQueryable();

            var mockDbSet = new Mock<IDbSet<User>>();
            mockDbSet.Setup(m => m.Provider).Returns(testData.Provider);
            mockDbSet.Setup(m => m.Expression).Returns(testData.Expression);
            mockDbSet.Setup(m => m.ElementType).Returns(testData.ElementType);
            mockDbSet.Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

            var mockContext = new Mock<SystemAdminContext>();
            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            var actual = classUnderTest.GetAllUsers();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }



        [Test]
        public void RemoveUserFromGroup_Calls_RemoveOnDbSet_And_SaveChangesOnContext_WhenCalled()
        {
            //Arrange
            var mockDbSet = new Mock<DbSet<UserAccessGroup>>();
            var mockContext = new Mock<SystemAdminContext>();

            mockContext.Setup(x => x.AccessGroups).Returns(mockDbSet.Object);

            var classUnderTest = new CRUD_Operations(mockContext.Object);

            //Act
            classUnderTest.RemoveUserFromGroup(1, 1);

            //Assert
            mockDbSet.Verify(x => x.Users.Remove(It.IsAny<User>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }



        [Test]
        public void DeleteUser_Calls_RemoveOnDbSet_And_SaveChangesOnContext()
        {
            
        }
    }
}
