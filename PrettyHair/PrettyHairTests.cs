using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;
using PrettyHair.Core;
using PrettyHair.Core.Repositories;

namespace PrettyHair
{
    [TestClass]
    public class PrettyHairTests
    {
        WareRepository repository = new WareRepository();
        Ware Table = new Ware(1500, 1, "This is a wooden table");
        Ware Shoe = new Ware(200, 30, "This is a pair of shoes");
        Ware Brush = new Ware(150, 25, "This is a brush for brushing hair");

        /* ----- Tests for Check Stock and Receive Products Use cases ----- */
        [TestMethod]
        public void WareExists()
        {
            Assert.AreEqual(1500, Table.Price);
            Assert.AreEqual(1, Table.Amount);
            Assert.AreEqual("This is a wooden table", Table.Designation);
        }
        [TestMethod]
        public void RepositoryExists()
        {
            Assert.AreEqual(0, repository.GetWares().Count);
        }

        [TestMethod]
        public void CanAddItem()
        {
            repository.addItem(Table);
            Assert.AreEqual(1, repository.WareList.Count);

            repository.addItem(Shoe);
            Assert.AreEqual(2, repository.WareList.Count);
        }
        [TestMethod]
        public void CanChangeQuantity()
        {
            repository.addItem(Table);
            Assert.AreEqual(1, repository.WareList[1].Amount);
            repository.UpdateQuantity(1, 20);
            Assert.AreEqual(20, repository.WareList[1].Amount);
        }
        [TestMethod]
        public void CanChangePrice()
        {
            repository.addItem(Table);
            Assert.AreEqual(1500, repository.WareList[1].Price);
            repository.UpdatePrice(1, 1600);
            Assert.AreEqual(1600, repository.WareList[1].Price);
        }
        [TestMethod]
        public void CanChangeDesignation()
        {
            repository.addItem(Table);
            Assert.AreEqual("This is a wooden table", repository.WareList[1].Designation);
            repository.UpdateDesignation(1, "This is a mahogany table");
            Assert.AreEqual("This is a mahogany table", repository.WareList[1].Designation);
        }

        [TestMethod]
        public void CanGetWares()
        {
            Ware Table = new Ware(1500, 1, "This is a wooden table");
            Ware Shoes = new Ware(200, 30, "These are shoes");

        }
        [TestMethod]
        public void CanDeleteWareByID()
        {
            repository.addItem(Table);
            Assert.AreEqual(1, repository.GetWares().Count);
            repository.DeleteWareByID(1);
            Assert.AreEqual(0, repository.GetWares().Count);
        }
        /* ----- Tests for Receive Order use case ----- */


        CustomerRepository CR = new CustomerRepository();
        Customer tina = new Customer("Tina", "Gurli");
        Customer lone = new Customer("Lone", "Fransen");
        Customer ulla = new Customer("Ulla", "Rasmussen");
        Customer karl = new Customer("Karl", "Møller");

        [TestMethod]
        public void EmptyRepo()
        {
            Assert.AreEqual(0, CR.GetAllCustomers().Count);
        }

        [TestMethod]
        public void CanAddCustomers()
        {
            Assert.AreEqual(0, CR.GetAllCustomers().Count);

            CR.AddCustomer(tina);
            CR.AddCustomer(lone);
            CR.AddCustomer(ulla);
            CR.AddCustomer(karl);

            Assert.AreEqual(4, CR.GetAllCustomers().Count);
        }

        [TestMethod]
        public void CanRemove()
        {
            CanAddCustomers();

            CR.RemoveCustomerByID(1);

            Assert.AreEqual(3, CR.GetAllCustomers().Count);
        }

        [TestMethod]
        public void CanClear()
        {
            CanAddCustomers();
            Assert.AreEqual(4, CR.GetAllCustomers().Count);

            CR.Clear();
            Assert.AreEqual(0, CR.GetAllCustomers().Count);
        }

        /*[TestMethod]
        public void CanCheckIfUserExists()
        {
            CanAddCustomers();

            Assert.IsTrue(CR.GetCustomerByID(1));
            Assert.IsFalse(CR.CustomerExistFromID(5));
        }*/

        [TestMethod]
        public void CanGetCustomer()
        {
            CanAddCustomers();

            Assert.AreSame(ulla, CR.GetCustomerByID(3));
        }

        [TestMethod]
        public void CanWriteToString()
        {
            Assert.AreEqual("[Name: Tina Gurli]", tina.ToString());
        }

        /* ----- Tests for Process Order use case ----- */

        /* ----- Tests for Plan Purchases use case ----- */

        /* ----- Tests for Monitoring Finances use case ----- */
        [TestMethod]
        public void CanGetTotalPriceOfInventory()
        {
            double getTotalPrice;
            Assert.AreEqual(0, repository.GetWares().Count);
            repository.addItem(Table);
            repository.addItem(Shoe);
            repository.addItem(Brush);
            getTotalPrice = repository.GetTotalPrice(repository.WareList);
            Assert.AreEqual(11250, getTotalPrice);
        }
        [TestMethod]
        public void CanGetTotalPriceForEveryWare()
        {
            double getWareTotalPrice;
            Assert.AreEqual(0, repository.GetWares().Count);
            repository.addItem(Brush);
            getWareTotalPrice = repository.GetWareTotalPrice(1, repository.WareList);
            Assert.AreEqual(3750, getWareTotalPrice);

            repository.addItem(Shoe);
            getWareTotalPrice = repository.GetWareTotalPrice(2, repository.WareList);
            Assert.AreEqual(6000, getWareTotalPrice);

            repository.addItem(Table);
            getWareTotalPrice = repository.GetWareTotalPrice(3, repository.WareList);
            Assert.AreEqual(1500, getWareTotalPrice);
        }
    }
}
