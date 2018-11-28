using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Member;

namespace StockTracker.Repository.Interface.Members
{
    public interface IMemberRoleRepo
    {
        IMemberRole AddRole(string memberRoleName);
        IMemberRole EditRole(int roleId, string memberRoleName);
    }
}
