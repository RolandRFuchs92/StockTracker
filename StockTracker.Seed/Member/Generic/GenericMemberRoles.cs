using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Model.Members;
using StockTracker.Seed.Interface;

namespace StockTracker.Seed.Member.Generic
{
    public class GenericMemberRoles : IGeneric<MemberRole>
    {
        public MemberRole[] All()
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

        public MemberRole One()
        {
            return All()[0];
        }

        public MemberRole One(int index)
        {
            return All()[index];
        }
    }
}
