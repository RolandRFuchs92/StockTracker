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
        private readonly ILoggerAdapter<L> _log;
        private Result<T> _result;

        public bool IsSuccess => _result.IsSuccess;

        public FormulateResult(ILoggerAdapter<L> log)
        {
            _result = new Result<T>();
            _log = log;
        }

        public Result<T> Result
        {
            get
            {
                if (!_result.IsSuccess)
                {
                    _log.LogError((int)LoggingEvent.Error, _result.Message);
                    return _result;
                }

                _log.LogInformation((int)LoggingEvent.Info, _result.Message);
                return _result;
            }
            set => _result = value;
        }

        public void Check(bool isSuccess, string message)
        {
            _result.Check(isSuccess, message);
        }

        public void Check(bool isSuccess, string successMessage, string errorMessage)
        {
            _result.Check(isSuccess, successMessage, errorMessage);
        }

        public void Check(T result, string successMessage, string errorMessage)
        {
            _result.Body = result;
            _result.IsSuccess = result != null;
            _result.Message = !_result.IsSuccess ? errorMessage : successMessage;
        }
    }
}
