using ColorChecker.DistributedSystems.Controllers;
using ColorChecker.Domain;
using ColorChecker.Domain.Services;
using ColorChecker.Domain.Services.CustomExceptions;
using ColorChecker.Infrastructure.DataAccess;
using Moq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace ColorChecker.Infrastructure.Controllers
{
    public class ColorsControllerTestSuite
    {

        [Fact]
        public void Post_InvalidIntensityValueInPayload_BadrequestReturn()
        {
            //Arrange
            ColorsController controller = new ColorsController(new PixelsServices(new PixelsRepository()));
            List<string> invalidPayload = new List<string> { "Red", "thisIsNotANumber", "payload1" };

            //Act
            IHttpActionResult result = controller.Post(invalidPayload);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void Post_InvalidColorNameInPayload_BadrequestReturn()
        {
            //Arrange
            ColorsController controller = new ColorsController(new PixelsServices(new PixelsRepository()));
            List<string> invalidPayload = new List<string> { "Yellow", "thisIsNotANumber", "payload1" };

            //Act
            IHttpActionResult result = controller.Post(invalidPayload);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void Post_ValidPayload_OkReturn()
        {
            //Arrange

            // We create an interface mock
            Mock<IPixelsServices> pixelsMock = new Mock<IPixelsServices>();
            // We define one of the methods behaviour
            pixelsMock.Setup(x => x.RegisterNewColor(It.IsAny<PixelDTO>())).Returns((PixelDTO pxDTO) => { return pxDTO; });

            // An incorrect behaviour is simulated
            pixelsMock
                .Setup(x => x.RegisterNewColor(It.Is<PixelDTO>(p => p.Intensity > 100)))
                .Throws(new ParsingReqPayloadException("Intensity must be between 0 and 100"));

            // we create an instance
            IPixelsServices mockedPixelService = pixelsMock.Object;

            //TODO
            ColorsController controller = new ColorsController(mockedPixelService);
            List<string> invalidPayload = new List<string> { "Red", "90", "payload2" };

            //Act
            IHttpActionResult result = controller.Post(invalidPayload);

            //Assert
            Assert.IsType<OkNegotiatedContentResult<PixelDTO>>(result);
        }
    }
}
