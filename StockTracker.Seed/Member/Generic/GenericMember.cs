using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Seed.Abstract;
using StockTracker.Seed.Clients.Generic;
using StockTracker.Seed.Interface;
using StockTracker.Seed.Persons;

namespace StockTracker.Seed.Member.Generic
{
    public class GenericMember : GenericSeed<Model.Members.Member>
    {
        public override void SeedContext(IStockTrackerContext db)
        {
            db.Clients.AddRange(new GenericClients().All());
            db.Persons.AddRange(new GenericPerson().All());
            ((StockTrackerContext) db).SaveChanges();
        }

        public override Model.Members.Member[] All()
        {
            return new[]
            {
                new Model.Members.Member
                {
                    IsActive = true,
                    ClientId = 1,
                    MemberRoleId = 1,
                    LastActiveDate = new DateTime(2018, 11, 29, 8, 0, 0),
                    MemberId = 1,
                    PersonId = 1
                },
                new Model.Members.Member
                {
                    IsActive = true,
                    ClientId = 1,
                    MemberRoleId = 2,
                    LastActiveDate = new DateTime(2018, 10, 29, 9, 0, 0),
                    MemberId = 2,
                    PersonId = 2
                },
                new Model.Members.Member
                {
                    IsActive = true,
                    ClientId = 1,
                    MemberRoleId = 2,
                    LastActiveDate = new DateTime(2018, 11, 20, 8, 0, 0),
                    MemberId = 3,
                    PersonId = 3
                }
            };
        }
    }
}
