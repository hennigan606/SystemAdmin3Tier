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
    }
}