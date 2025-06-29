using NUnit.Framework;
using Moq;

namespace MoqAssignment
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [SetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();
            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_ShouldReturnTrue()
        {
            _mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                           .Returns(true);

            bool result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
            _mockMailSender.Verify(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SendMailToCustomer_WhenMailFails_ShouldReturnFalse()
        {
            _mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                           .Returns(false);

            bool result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.False);
            _mockMailSender.Verify(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
