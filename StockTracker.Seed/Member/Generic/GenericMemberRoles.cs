using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Members;
using StockTracker.Seed.Abstract;
using StockTracker.Seed.Interface;

namespace StockTracker.Seed.Member.Generic
{
    public class GenericMemberRoles : GenericSeed<MemberRole>
    {
        public override MemberRole[] All()
        {
            return new[]
            {
                new MemberRole
                {
                    IsActive = true,
                    MemberRoleName = "Manager"
                },
                new MemberRole
                {
                    IsActive = true,
                    MemberRoleName = "Head Cheff"
                },
                new MemberRole
                {
                    IsActive = true,
                    MemberRoleName = "Cheff"
                },
                new MemberRole
                {
                    IsActive = true,
                    MemberRoleName = "Waiter"
                },
            };
        }
    }
}
