﻿using Moq;
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

        public void Success(int timesCount = 1)
        {
            if(timesCount == 1)
                Mock.Verify(i => i.LogInformation(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            else if (timesCount > 1)
                Mock.Verify(i => i.LogInformation(It.IsAny<int>(), It.IsAny<string>()), Times.AtLeast(timesCount));
        }

        public void Error(int timesCount = 1)
        {
            if(timesCount == 1)
                Mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            if(timesCount > 1)
                Mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<string>()), Times.AtLeast(timesCount));
        }

        public void ErrorException(int timesCount = 1)
        {
            if(timesCount == 1)
                Mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
            else if(timesCount > 1)
                Mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<Exception>(), It.IsAny<string>()), Times.AtLeast(timesCount));

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
