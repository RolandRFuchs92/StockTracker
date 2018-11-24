using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Member;
using StockTracker.Interface.Models.Person;
using StockTracker.Model.Member;

namespace StockTracker.Repository.Interface.Members
{
    public interface IMemberRepo
    {
	    IMember Add(IMember member);
	    IMember Edit(IMember member);
        IMember ChangeRole(int memberId, int memberRoleId);
        IMember ChangeClient(int memberId, int clientId);
	    IMember LastActiveDate(int memberId);
        IMember EditPerson(int memberId, IPerson person);
        IMemberRole AddRole(string memberRoleName);
        IMemberRole EditRole(int roleId, string memberRoleName);
    }
}
