using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookUsing_ADODOTNet;

namespace AdressBook_Test
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookModel model = new AddressBookModel();
        AddressBookrRepo repo = new AddressBookrRepo();

        [TestMethod]
        public void AddingThePerson_shouldReturnTrue()
        {
            model.FirstName = "pradeepa";
            model.LastName = "Vanampally";
            model.Address = "BNReddy";
            model.City = "RR";
            model.State = "Ts";
            model.Zip = "500002";
            model.PhoneNumber = "9874103544";
            model.Email = "pradeepa@gmail.com";
            bool result = repo.AddPersonToDB(model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpadatingPersonDetails_ShouldReturnTrue()
        {
            model.FirstName = "pradeepa";
            model.City = "HN";
            bool result = repo.UpadatePersonDetails(model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DeletingPersonDetails_ShouldReturnTrue()
        {
            model.FirstName = "Anitha";
            bool result = repo.DeletePersonFromDb(model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddingTheRelationShipType_ShouldReturnTrue()
        {
            model.RelationShip_name = "Friends";
            bool result = repo.AddRelationShip_TypeToDB(model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddingRelationShipTypeToPerson_ShouldReturnTrue()
        {
            model.ID = 1;
            model.Relationship_ID = 2;
            bool result = repo.AddpersonsTypeToDB(model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddingsamePersonTodiffTypes_ShouldReturnTrue()
        {
            model.ID = 1;
            model.Relationship_ID = 3;
            bool result = repo.AddpersonsTypeToDB(model);
            Assert.IsTrue(result);
        }

    }
}
