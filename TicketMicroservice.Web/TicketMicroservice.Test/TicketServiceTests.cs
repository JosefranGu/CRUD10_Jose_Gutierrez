using Moq;
using NUnit.Framework;
using System;
using TicketMicroservice.ApplicationServices;
using TicketMicroservice.Core;
using TicketMicroservice.DataAccess;


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
            var mockChecker = new Mock<IChecker>();
            var ticketService = new TicketService(mockRepository.Object, mockChecker.Object);
            var validTicketDTO = new Ticket { /* Populate with valid data */ };

            // Act
            ticketService.InsertTicket(validTicketDTO);

            // Assert
            mockRepository.Verify(repo => repo.Insert(It.IsAny<Ticket>()), Times.Once);
        }

        // Write similar tests for other functionalities...
    }
}
