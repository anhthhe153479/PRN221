using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Management
{
    public class BillManagement
    {
        private static BillManagement instance;
        private static readonly object instanceLock = new object();
        private BillManagement() { }
        public static BillManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BillManagement();
                    }
                    return instance;
                }

            }
        }

        public List<Bill> GetListBill()
        {
            List<Bill> bills;

            try
            {
                using (var managerDB = new Management_System_ProjectContext())
                {
                    bills = managerDB.Bills.Select(bill => new Bill
                    {
                        BillId = bill.BillId,
                        UserId = bill.UserId,
                        Date = bill.Date,
                        Name = bill.Name == null ? "" : bill.Name,
                        Phone = bill.Phone == null ? "" : bill.Phone,
                        ProductId = bill.ProductId,
                        Number = bill.Number,
                        NumberGiven = bill.NumberGiven,
                        OriginalPrice = bill.OriginalPrice,
                        FinalPrice = bill.FinalPrice,
                        Event = bill.Event == null ? "" : bill.Event,
                        GoToShop = bill.GoToShop,
                        MoneyTaken = bill.MoneyTaken,
                        MoneyExchange = bill.MoneyExchange,
                        Address = bill.Address == null ? "" : bill.Address,
                        Deposit = bill.Deposit,
                        Ship = bill.Ship,
                        MoneyWillGet = bill.MoneyWillGet,
                        Status = bill.Status,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bills;
        }

        public List<Bill> GetBillList()
        {
            return GetListBill();
        }

        public Bill GetBillById(int billId)
        {
            Bill bill = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                bill = managerDB.Bills.SingleOrDefault(bill => bill.BillId == billId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bill;
        }

        public void AddBill(Bill bill)
        {
            if (bill != null)
            {
                try
                {
                    Bill _Bill = GetBillById(bill.BillId);
                    if (_Bill == null)
                    {
                        var managerDB = new Management_System_ProjectContext();
                        managerDB.Bills.Add(bill);
                        managerDB.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("The Bill is already exist");

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void UpdateBill(Bill bill)
        {
            try
            {
                Bill _bill = GetBillById(bill.BillId);
                if (_bill != null)
                {
                    var managerDB = new Management_System_ProjectContext();
                    managerDB.Entry<Bill>(bill).State = EntityState.Modified;
                    managerDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Bill> GetBillByStatus(string status)
        {
            List<Bill> bills;
            try
            {
                using (var managerDB = new Management_System_ProjectContext())
                {
                    bills = managerDB.Bills.Where(x => x.Status.Contains(status)).Select(bill => new Bill
                    {
                        BillId = bill.BillId,
                        UserId = bill.UserId,
                        Date = bill.Date,
                        Name = bill.Name == null ? "" : bill.Name,
                        Phone = bill.Phone == null ? "" : bill.Phone,
                        ProductId = bill.ProductId,
                        Number = bill.Number,
                        NumberGiven = bill.NumberGiven,
                        OriginalPrice = bill.OriginalPrice,
                        FinalPrice = bill.FinalPrice,
                        Event = bill.Event == null ? "" : bill.Event,
                        GoToShop = bill.GoToShop,
                        MoneyTaken = bill.MoneyTaken,
                        MoneyExchange = bill.MoneyExchange,
                        Address = bill.Address == null ? "" : bill.Address,
                        Deposit = bill.Deposit,
                        Ship = bill.Ship,
                        MoneyWillGet = bill.MoneyWillGet,
                        Status = bill.Status,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return bills;
        }

        public List<Bill> GetListBillByStatusOrderByDate(string status)
        {
            List<Bill> bills;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                if (status.Equals("Xem Đơn Đã Hoành Thành"))
                {
                    bills = GetBillByStatus("Đã Hoàn Thành");
                }
                else if (status.Equals("Xem Đơn Đã Hủy"))
                {
                    bills = GetBillByStatus("Đã Hủy");
                }
                else if (status.Equals("Xem Đơn Chưa Hoàn Thành"))
                {
                    bills = GetBillByStatus("Chưa Hoàn Thành");
                }
                else
                {
                    bills = GetListBill();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return bills;
        }
    }
}

