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

namespace StockTracker.Repository.Test.StockTracker.Member
{
    public class MemberRepoTest
    {
        private IMemberRepo _memberRepo;
        private IStockTrackerContext _db;

        public MemberRepoTest()
        {
            _db = new TestDb().Db;
        }

        [TestMethod]
        public void Add_PassValidClientAndMember_NewMemberObject()
        {
            //Arrange
            var member = new Model.Members.Member();
            

            //Act
            //var result = _memberRepo.Add();

            //Assert

        }

        private IStockTrackerContext StockTracker (Expression<Func<IStockTrackerContext, IMember>> method, IMember result)
        {
            var moq = new Mock<IStockTrackerContext>();
            moq.Setup(method).Returns(result);
            
            return moq.Object;
        }

    }
}
