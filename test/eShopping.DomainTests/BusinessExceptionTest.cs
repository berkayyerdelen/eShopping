using eShopping.Domain;
using Xunit;

namespace eShopping.DomainTests
{
    public class BusinessExceptionTest
    {
        [Fact]
        public void BusinessException_Shout_CreateException()
        {
            var exception = new BusinessException();
            Assert.NotNull(exception);
        }

        [Fact]
        public void BusinessException_Should_Return_Message()
        {
            var message = "Message";
            var exception = new BusinessException(message);
            Assert.Equal(message,exception.Message);
        }
    }
}