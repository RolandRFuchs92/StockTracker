using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Remotion.Linq.Utilities;
using StockTracker.Interface.Models.Member;
using StockTracker.Repository.Interface.Members;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Person;
using StockTracker.Model.Persons;
using StockTracker.Repository.Member;
using StockTracker.Seed.Member.Generate;
using StockTracker.Seed.Member.Generic;
using StockTracker.Seed.Persons;

namespace StockTracker.Repository.Test.StockTracker.Member
{
    [TestClass]
    public class MemberRepoTest
    {
        private IMemberRepo _memberRepo;
        private IStockTrackerContext _db;
        private GenerateMember _generateMembers;
        private GenericMember _genericMember;
        private GenericPerson _genericPerson;

        public MemberRepoTest()
        {
            _db = new TestDbFactory().Db();
            _generateMembers = new GenerateMember(_db);
            _genericMember = new GenericMember();
            _genericPerson = new GenericPerson();
            _memberRepo = new MemberRepo(_db);
            
        }

        #region Add Test
        [TestMethod]
        public void Add_PassValidClientAndMember_NewMemberObject()
        {
            //Arrange
            _generateMembers.Generate();
            var member = new Model.Members.Member
            {
                IsActive = true,
                ClientId = 1,
                LastActiveDate =  DateTime.Now,
                PersonId = 0,
                MemberRoleId = 1
            };

            var person = _genericPerson.One();

            member.MemberId = 0;
            person.PersonId = 0;

            //Act
            var result = _memberRepo.Add(member, person);

            //Assert
            Assertions(result);
        }

        [TestMethod]
        public void Add_PassInvalidClientWithMember_Null()
        {
            //Arrange
            _generateMembers.Truncate();
            var member = _genericMember.One();
            var person = (IPerson)null;

            member.ClientId = 100;
            member.MemberId = 0;

            //Act
            var result = _memberRepo.Add(member, person);

            //Assert
            Assertions(result, false);
        }
        #endregion

        #region Edit Test
        [TestMethod]
        public void Edit_PassValidClient_FullMember()
        {
            //Arrange
            _generateMembers.Generate();
            var member = _genericMember.One();
            var isMemberActive = false;
            var clientId = 3;
            member.IsActive = isMemberActive;
            member.ClientId = clientId;

            //Act
            var result = _memberRepo.Edit(member);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IMember));
            Assert.AreEqual(result.IsActive, isMemberActive);
            Assert.AreEqual(result.ClientId, clientId);
        }

        [TestMethod]
        public void Edit_PassValidClient_NullMember()
        {
            //Arrange
            _generateMembers.Generate();
            var member = _genericMember.One();
            member.ClientId = 0;

            //Act
            var result = _memberRepo.Edit(member);

            //Assert
            Assert.IsNull(result);
        }

        #endregion

        #region ChangeRole Test
        [TestMethod]
        public void ChangeRole_PassValidRole_PassMemberWithNewMemberRole()
        {
            //Arrange
            _generateMembers.Generate();
            var newRoleId = 3;
            var memberId = 1;

            //Act
            var result = _memberRepo.ChangeRole(memberId, newRoleId);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IMember));
            Assert.AreEqual(result.MemberRoleId, newRoleId);
        }

        [TestMethod]
        public void ChangeRole_PassInvalidMemberId_ReturnNull()
        {
            //Arrange
            _generateMembers.Generate();
            var memberId = 0;

            //Act
            var result = _memberRepo.ChangeRole(memberId, 3);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ChangeRole_PassInvalidMemberRoleId_ReturnNull()
        {
            //Arrange
            _generateMembers.Generate();
            var memberId = 1;
            var memberRoleId = 100;

            //Act
            var result = _memberRepo.ChangeRole(memberId, memberRoleId);

            //Assert
            Assert.IsNull(result);
        }
        #endregion

        #region ChangeClient Test
        [TestMethod]
        public void ChangeClient_PassValidMemberAndClient_ChangedMemberWithClientReference()
        {
            //Arrange
            _generateMembers.Generate();
            var memberId = 1;
            var clientId = 2;

            //Act
            var result = _memberRepo.ChangeClient(memberId, clientId);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IMember));
            Assert.AreEqual(result.ClientId, clientId);
        }

        [TestMethod]
        public void ChangeClient_PassInvalidMember_ReturnNull()
        {
            //Arrange
            _generateMembers.Generate();
            var memberId = 0;
            var clientId = 1;

            //Act
            var result = _memberRepo.ChangeClient(memberId, clientId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ChangeClient_PassInvalidClientId_ReturnNull()
        {
            //Arrange
            _generateMembers.Generate();
            var memberId = 1;
            var clientId = 0;

            //Act
            var result = _memberRepo.ChangeClient(memberId, clientId);

            //Assert
            Assert.IsNull(result);
        }
        #endregion

        #region LastActiveDate Test
        [TestMethod]
        public void LastActiveDate_PassedValidMember_ReturnUpdateMemberId()
        {
            //Arrange
            _generateMembers.Generate();
            var member = _genericMember.One();
            var lastUpdateDate = member.LastActiveDate;

            //Act
            var result = _memberRepo.LastActiveDate(member.MemberId);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IMember));
            Assert.AreNotEqual(result.LastActiveDate, lastUpdateDate);
        }

        [TestMethod]
        public void LastActiveDate_PassInvalidMemberId_null()
        {
            //Arrange
            _generateMembers.Generate();
            var badMemberId = 100;

            //Act
            var result = _memberRepo.LastActiveDate(badMemberId);

            //Assert
            Assert.IsNull(result);
        }
        #endregion

        #region EditPerson Test

        [TestMethod]
        public void EditPerson_PassValidMemberIdWithFullPerson_ReturnMemberWithNewPersonRef()
        {
            //Arrange
            _generateMembers.Generate();
            var member = _genericMember.One();
            var person = new Person()
            {
                Email = "roland@telkomplace.co.za",
                Mobile = "0730531234",
                WhatsApp = "0320771234",
                PersonName = "Roland",
                PersonSurname = "Moodude"
            };

            //Act
            var result = _memberRepo.EditPerson(member.MemberId, person);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IMember));
            Assert.AreEqual((result as Model.Members.Member).Person, person);
        }

        [TestMethod]
        public void EditPerson_PassValidMemberEditPersonData_ReturnMember()
        {
            //Arrange
            _generateMembers.Generate();
            var member = _genericMember.One();
            var personId = member.PersonId;
            var personEmail = "ro@ro.co.za";
            var personMobile = "087123456";
            var personCurrentWhatsapp = _db.Persons.FirstOrDefault(i => i.PersonId == personId).WhatsApp;

            var person = new Person
            {
                Email = personEmail,
                Mobile = personMobile
            };

            //Act
            var result = _memberRepo.EditPerson(member.MemberId, person);
            var personResult = _db.Persons.FirstOrDefault(i => i.PersonId == personId);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IMember));
            Assert.AreEqual(personResult.Email, personEmail);
            Assert.AreEqual(personResult.Mobile, personMobile);
            Assert.AreEqual(personResult.WhatsApp, personCurrentWhatsapp);
        }

        [TestMethod]
        public void EditPerson_PassInvalidMemberId_ReturnNull()
        {
            //Arrange
            _generateMembers.Generate();
            
            //Act
            var result = _memberRepo.EditPerson(100, new Person());

            //Assert
            Assert.IsNull(result);
        }
        #endregion

        #region Dry Code
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
        #endregion
    }
}
