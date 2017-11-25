using NUnit.Framework;
using Moq;
using SystemAdmin_CRUD_Ops;
using System;

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


        [Test]
        public void AssignOperator_CallsAssignAdminToRequest_ExactlyOnce_WhenCalled()
        {
            int TestRequestID = 1;
            String TestAdminName = "Joe Admin";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            ServiceRequestService RqstService = new ServiceRequestService(MockCRUD.Object);

            //Act
            RqstService.AssignOperator(TestRequestID, TestAdminName);

            //Assert
            MockCRUD.Verify(x => x.AssignAdminToRequest(It.IsAny<int>(), It.IsAny<String>()), Times.Once);
        }


        [Test]
        public void AssignOperator_CallsAssignAdminToRequest_PassingTheIDAndAdminNameProvided_ExactlyOnce_WhenCalled()
        {
            int TestRequestID = 1;
            String TestAdminName = "Joe Admin";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            ServiceRequestService RqstService = new ServiceRequestService(MockCRUD.Object);

            //Act
            RqstService.AssignOperator(TestRequestID, TestAdminName);

            //Assert
            MockCRUD.Verify(x => x.AssignAdminToRequest(TestRequestID, TestAdminName), Times.Once);
        }


        [Test]
        public void ProvideInfo_CallsCRUD_ProvideInfo_ExactlyOnce_WhenCalled()
        {
            int TestRequestID = 1;
            String TestInfo = "Request will be complete in 2 hours";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            ServiceRequestService RqstService = new ServiceRequestService(MockCRUD.Object);

            //Act
            RqstService.ProvideInfo(TestRequestID, TestInfo);

            //Assert
            MockCRUD.Verify(x => x.ProvideInfo(It.IsAny<int>(), It.IsAny<String>()), Times.Once);
        }


        [Test]
        public void ProvideInfo_CallsCRUD_ProvideInfo_PassingTheIDAndInfoProvided_ExactlyOnce_WhenCalled()
        {
            int TestRequestID = 1;
            String TestInfo = "Request will be complete in 2 hours";

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            ServiceRequestService RqstService = new ServiceRequestService(MockCRUD.Object);

            //Act
            RqstService.ProvideInfo(TestRequestID, TestInfo);

            //Assert
            MockCRUD.Verify(x => x.ProvideInfo(TestRequestID, TestInfo), Times.Once);
        }


        [Test]
        public void MarkAsComplete_CallsCRUD_MarkAsComplete_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestRequestID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            ServiceRequestService RqstService = new ServiceRequestService(MockCRUD.Object);

            //Act
            RqstService.MarkAsComplete(TestRequestID);

            //Assert
            MockCRUD.Verify(x => x.MarkAsComplete(It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void MarkAsComplete_CallsCRUD_MarkAsComplete_PassingItTheProvidedID_ExactlyOnce_WhenCalled()
        {
            //Arrange
            int TestRequestID = 1;

            Mock<ICRUD_Operations> MockCRUD = new Mock<ICRUD_Operations>();

            ServiceRequestService RqstService = new ServiceRequestService(MockCRUD.Object);

            //Act
            RqstService.MarkAsComplete(TestRequestID);

            //Assert
            MockCRUD.Verify(x => x.MarkAsComplete(TestRequestID), Times.Once);
        }
    }
}
