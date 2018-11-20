using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Member;
using StockTracker.Model.Member;

namespace StockTracker.Repository.Interface.Members
{
    public interface IMemberRepo
    {
	    IMember Add(IMember member);
	    IMember Edit(IMember member);
	    IMember Toggle(int memberId, bool isActive);
	    IMember LastActiveDate(int memberId);
    }
}
