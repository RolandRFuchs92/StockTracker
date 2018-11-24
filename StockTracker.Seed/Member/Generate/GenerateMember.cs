using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Model.Members;
using StockTracker.Model.Persons;
using StockTracker.Seed.Clients.Generic;
using StockTracker.Seed.Interface;
using StockTracker.Seed.Member.Generic;
using StockTracker.Seed.Persons;

namespace StockTracker.Seed.Member.Generate
{
    public class GenerateMember : IGenerate
    {
        private IStockTrackerContext _db;
        private Model.Members.Member[] _memberList;
        private Client[] _clientList;
        private MemberRole[] _memberRoleList;
        private Person[] _personList;

        public GenerateMember(IStockTrackerContext db)
        {
            _db = db;
            _memberList = new GenericMember().All();
            _clientList = new GenericClients().All();
            _memberRoleList = new GenericMemberRoles().All();
            _personList = new GenericPerson().All();
        }

        public void Generate()
        {
            Truncate();

            _db.Members.AddRange(_memberList);
            _db.Clients.AddRange(_clientList);
            _db.MemberRoles.AddRange(_memberRoleList);
            _db.Persons.AddRange(_personList);

            ((StockTrackerContext) _db).SaveChanges();
        }

        private void Truncate()
        {
            ((StockTrackerContext)_db).Database.EnsureDeleted();
        }
    }
}
