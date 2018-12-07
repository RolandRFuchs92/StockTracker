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
				private Mock<ILoggerAdapter<T>> _mock;

				public GenericLoggerCheck(Mock<ILoggerAdapter<T>> mock)
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

				public Mock<ILoggerAdapter<T>> GetMockLogger() 
				{
						var moq = new Mock<ILoggerAdapter<T>>();		
						moq.Setup(i => i.LogInformation(It.IsAny<int>(), It.IsAny<string>()));
						moq.Setup(i => i.LogError(It.IsAny<int>(), It.IsAny<string>()));
						moq.Setup(i => i.LogError(It.IsAny<int>(), It.IsAny<Exception>(), It.IsAny<string>()));

						return moq;
				}
		}
}
