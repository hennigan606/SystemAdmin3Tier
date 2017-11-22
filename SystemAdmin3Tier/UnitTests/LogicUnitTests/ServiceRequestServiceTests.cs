using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using SystemAdminClasses;
using SystemAdmin_CRUD_Ops;

namespace UnitTests.LogicUnitTests
{
    [TestFixture]
    public class ServiceRequestServiceTests
    {
        [Test]
        public void CreateRequest_CallsInsertServiceRequest_ExactlyOnce_WhenCalled()
        {
            //Arrange
            string TestUserName = "Joe Bloggs";
            string TestRequestType = "Password Reset";
            string TestDetails = "Forgot Password";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            ServiceRequestService RqstService = new ServiceRequestService(MockCRUD.Object);

            //Act
            RqstService.CreateRequest(TestUserName, TestRequestType, TestDetails);

            //Assert
            MockCRUD.Verify(x => x.InsertServiceRequest(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void CreateRequest_CallsInsertServiceRequest_PassingTheInformationProvided_ExactlyOnce_WhenCalled()
        {
            //Arrange
            string TestUserName = "Joe Bloggs";
            string TestRequestType = "Password Reset";
            string TestDetails = "Forgot Password";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            ServiceRequestService RqstService = new ServiceRequestService(MockCRUD.Object);

            //Act
            RqstService.CreateRequest(TestUserName, TestRequestType, TestDetails);

            //Assert
            MockCRUD.Verify(x => x.InsertServiceRequest(
                TestUserName, TestRequestType, TestDetails), Times.Once);
        }
    }
}
