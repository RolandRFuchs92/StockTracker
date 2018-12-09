using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.Repository.Enums;

namespace StockTracker.BuisnessLogic.Util
{
    public class FormulateResult<T, L>
    {
        private ILoggerAdapter<L> _log;
        private Result<T> _result;

        public FormulateResult(ILoggerAdapter<L> log)
        {
            _result = new Result<T>();
            _log = log;
        }

        public Result<T> Result()
        {
            if (!_result.IsSuccess)
            {
                _log.LogError((int)LoggingEvent.Error, _result.Message);
                return _result;
            }

            _log.LogInformation((int)LoggingEvent.Info, _result.Message);
            return _result;
        }

        public void Check(bool isSuccess, string message)
        {
            _result.Check(isSuccess, message);
        }
    }
}
