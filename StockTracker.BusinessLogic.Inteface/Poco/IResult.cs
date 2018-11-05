using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.BusinessLogic.Inteface.Poco
{
    public interface IResult<T>
    {
	    void Check(bool isSuccess, string successMessage, string errorMessage);
	    void Check(bool isSuccess, string errorMessage);
		bool IsSuccess { get; set; }
	    string Message { get; set; }
	    T Body { get; set; }
	}
}
