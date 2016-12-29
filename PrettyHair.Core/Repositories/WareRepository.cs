using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core
{
    public class WareRepository
    {
        public Dictionary<int, IWare> WareList = new Dictionary<int, IWare>();
        int Id = 1;
        public WareRepository()
        {

        }
        public Dictionary<int, IWare> GetWares()
        {
            return WareList;
        }
        public void AddItem(Ware item)
        {
            WareList.Add(Id++, item);
        }
        public void DeleteWareByID(int ID)
        {
            WareList.Remove(ID);
        }
        public void UpdateQuantity(int ID, int newAmount)
        {
            WareList[ID].Amount = newAmount;
        }
        public void UpdatePrice(int ID, int newPrice)
        {
            WareList[ID].Price = newPrice;
        }
        public void UpdateDesignation(int ID, string newDesignation)
        {
            WareList[ID].Designation = newDesignation;
        }
        public Dictionary<int, IWare> getWares()
        {
            return WareList;
        }
        private Ware getWaresByID(int ID)
        {
            return null;
        }
        public double GetWareTotalPrice(int Id, Dictionary<int, IWare> warelist)
        {
            return warelist[Id].Price * warelist[Id].Amount;
        }
        public double GetTotalPrice(Dictionary<int, IWare> warelist)
        {
            double totalPrice = 0;
            double tempPrice;
            for (int i = 1; i <= warelist.Count; i++)
            {
                tempPrice = warelist[i].Price * warelist[i].Amount;
                totalPrice = totalPrice + tempPrice;
            }

            return totalPrice;
        }
    }
}

