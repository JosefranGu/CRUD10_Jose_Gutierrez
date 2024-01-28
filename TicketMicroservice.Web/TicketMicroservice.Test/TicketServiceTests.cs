using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.DataAccess;
using TicketMicroservice.Web;

namespace TicketMicroservice.Test
{
    [TestFixture]
    public class TicketServiceTests
    {
        [Test]
        public void Insert_ValidTicketDTO_TicketInsertedSuccessfully()
        {
            // Arrange
            var mockRepository = new Mock<ITicketRepository>();
            var mockChecker = new Mock<Checker>();
            var ticketService = new TicketApplicationService(mockRepository.Object, mockChecker.Object);
            var validTicketDTO = new TicketDTO { /* Populate with valid data */ };

            // Act
            ticketService.Insert(validTicketDTO);

            // Assert
            mockRepository.Verify(repo => repo.Insert(It.IsAny<Ticket>()), Times.Once);
        }

        // Write similar tests for other functionalities...
    }
}
