using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Interface.Poco;

namespace StockTracker.BuisnessLogic.Poco
{
	public class Result<T> : IResult<T>
	{
		public Result()
		{
			
		}

		public Result(bool isSuccess)
		{
			this.IsSuccess = isSuccess;
		}

	    public Result(string errorMessage)
	    {
	        IsSuccess = false;
	        Message = errorMessage;
	        Body = (T)Convert.ChangeType(null, typeof(T));
	    }

		public Result(bool isSuccess, string successMessage, string errorMessage)
		{
			Check(isSuccess, successMessage, errorMessage);
		}

		public void Check(bool isSuccess, string successMessage, string errorMessage)
		{
			if (!isSuccess)
				this.IsSuccess = false;
			this.Message = $"{(isSuccess ? successMessage : errorMessage)}\r\n";
		}

		public void Check(bool isSuccess, string errorMessage)
		{
			if (!isSuccess)
				this.IsSuccess = false;
			this.Message += isSuccess ?  "" : errorMessage;
		}

		public bool IsSuccess { get; set; } = true;
		public string Message { get; set; } = "";
		public T Body { get; set; }
	}
}
