using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Management;
using Core.Models;

namespace Core.Repository
{
    public class BillRepository : IBillRepository
    {
        public List<Bill> GetListBillByStatusOrderByDate(string status) => BillManagement.Instance.GetListBillByStatusOrderByDate(status);

        public List<Bill> GetBill() => BillManagement.Instance.GetBillList();
        public Bill GetBillById(int id) => BillManagement.Instance.GetBillById(id);

        public void UpdateBill(Bill bill) => BillManagement.Instance.UpdateBill(bill);

        public void AddBill(Bill bill) => BillManagement.Instance.AddBill(bill);

    }
}
