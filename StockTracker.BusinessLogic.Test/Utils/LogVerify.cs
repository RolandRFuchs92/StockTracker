using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StockTracker.Adapter.Interface.Logger;

namespace StockTracker.BusinessLogic.Test.Utils
{
    public class LogVerify<T>
    {

        private readonly Mock<ILoggerAdapter<T>> _mock;

        public LogVerify(Mock<ILoggerAdapter<T>> mock)
        {
            _mock = mock;
        }

        public void Success()
        {
            _mock.Verify(i => i.LogInformation(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        public void Error()
        {
            _mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        public void ErrorException()
        {
            _mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }
    }
}
