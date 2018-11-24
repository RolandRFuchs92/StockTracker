using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Interface.Models.Member;
using StockTracker.Repository.Interface.Members;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Seed.Member.Generate;
using StockTracker.Seed.Member.Generic;

namespace StockTracker.Repository.Test.StockTracker.Member
{
    public class MemberRepoTest
    {
        private IMemberRepo _memberRepo;
        private IStockTrackerContext _db;
        private GenerateMember _generateMembers;
        private GenericMember _genericMember;

        public MemberRepoTest()
        {
            _db = new TestDb().Db;
            _generateMembers = new GenerateMember(_db);
            _genericMember = new GenericMember();
        }

        #region Add Test
        [TestMethod]
        public void Add_PassValidClientAndMember_NewMemberObject()
        {
            //Arrange
            _generateMembers.Generate();
            var member = _genericMember.One();
            ((StockTrackerContext)_db).Members.RemoveRange(_genericMember.All());
                    
            //Act
            var result = _memberRepo.Add(member);

            //Assert
            Assertions(result);
        }

        [TestMethod]
        public void Add_PassInvalidClientWithMember_Null()
        {
            //Arrange
            _generateMembers.Generate();
            var member = new Model.Members.Member();
            ((StockTrackerContext)_db).Members.RemoveRange(_genericMember.All());

            //Act
            var result = _memberRepo.Add(member);

            //Assert
            Assertions(result, false);
        }
        #endregion

        #region Edit Test

        

        #endregion

        private IStockTrackerContext StockTracker (Expression<Func<IStockTrackerContext, IMember>> method, IMember result)
        {
            var moq = new Mock<IStockTrackerContext>();
            moq.Setup(method).Returns(result);
            
            return moq.Object;
        }

        private void Assertions(IMember result, bool isValid = true)
        {
            if (isValid)
            {
                Assert.IsInstanceOfType(result, typeof(IMember));
            }
            else
            {
                Assert.IsNull(result);
            }
        }

    }
}
