using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Data;

namespace SecretSanta.Business.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_NullItem_ThrowsArgumentException()
        {
            UserRepository sut = new();

            sut.Create(null!);
    
        }

        [TestMethod]
        public void Create_WithItem_CanGetItem()
        {
            UserRepository sut = new();

            User user = new()
            {
                Id = 42
            };
            sut.Remove(user.Id);

            User createdUser = sut.Create(user);
            User? retrievedUser = sut.GetItem(createdUser.Id);

            Assert.AreEqual(user, retrievedUser);
            sut.Remove(createdUser.Id);
        }

        [TestMethod]
        public void GetItem_WithBadId_ReturnsNull()
        {
            UserRepository sut = new();

            User? user = sut.GetItem(-1);

            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetItem_WithValidId_ReturnsUser()
        {
            UserRepository sut = new();

            User newUser = new(){
                Id = 42, 
                FirstName = "First",
                LastName = "Last"
            };
            //clearing data base to avoid conflicts.
            sut.Remove(newUser.Id);
            sut.Create(newUser);
            
            User? user = sut.GetItem(42);

            Assert.AreEqual(42, user?.Id);
            Assert.AreEqual("First", user!.FirstName);
            Assert.AreEqual("Last", user.LastName);
        }

        //declare that it is a test method. Once declared we can pass in params using datarow. 
        [TestMethod]
        [DataRow(-1, false)]
        [DataRow(42, true)]
        public void Remove_WithInvalidId_ReturnsTrue(int id, bool expected)
        {
            UserRepository sut = new();
            User newUser = new(){
                Id = 42, 
                FirstName = "First",
                LastName = "Last"
            };
            //clearing data base to avoid conflicts.
            sut.Remove(newUser.Id);
            sut.Create(newUser);  

            Assert.AreEqual(expected, sut.Remove(id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_NullItem_ThrowsArgumentException()
        {
            UserRepository sut = new();

            sut.Save(null!);
        }

        [TestMethod]
        [DataRow(21)]
        public void Save_WithValidItem_SavesItem(int id)
        {
            UserRepository sut = new();

            User newUser = new(){
                Id = id, 
                FirstName = "First",
                LastName = "Last"
            };
            //clearing data base to avoid conflicts.
            sut.Remove(newUser.Id);
            sut.Create(newUser);  
            sut.Save(newUser);

            Assert.IsNotNull(sut.GetItem(id));
            Assert.AreNotEqual(42, sut.GetItem(id)?.Id);
            Assert.AreEqual(id, sut.GetItem(id)?.Id);
        }
    }
}
