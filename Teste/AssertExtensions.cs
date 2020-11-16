using System;
using System.Threading.Tasks;
using Xunit;

namespace Teste
{
    public static class AssertExtensions
    {
        public static void ThrowsWithMessage(Action testCode, string messageExpected)
        {
            var message = Assert.Throws<Exception>(testCode).Message;
            Assert.Equal(messageExpected, message);
        }

        public static void ThrowsWithMessageAsync(Func<Task> testCode, string messageExpected)
        {
            var result = Assert.ThrowsAsync<Exception>(testCode).Result;
            Assert.Equal(messageExpected, result.Message);
        }
    }
}