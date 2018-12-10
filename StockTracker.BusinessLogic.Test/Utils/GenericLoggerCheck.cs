using Moq;
using StockTracker.Adapter.Interface.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.BusinessLogic.Test
{
    public class GenericLoggerCheck<T>
    {
        public Mock<ILoggerAdapter<T>> Mock { get; }

        public GenericLoggerCheck()
        {
            Mock = GetMockLogger();
        }

        public void Success()
        {
            Mock.Verify(i => i.LogInformation(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        public void Error()
        {
            Mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        public void ErrorException()
        {
            Mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }

        private Mock<ILoggerAdapter<T>> GetMockLogger()
        {
            var moq = new Mock<ILoggerAdapter<T>>();
            moq.Setup(i => i.LogInformation(It.IsAny<int>(), It.IsAny<string>()));
            moq.Setup(i => i.LogError(It.IsAny<int>(), It.IsAny<string>()));
            moq.Setup(i => i.LogError(It.IsAny<int>(), It.IsAny<Exception>(), It.IsAny<string>()));

            return moq;
        }
    }
}
