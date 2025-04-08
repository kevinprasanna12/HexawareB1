using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Dao
{
    public interface IPayment_operation
    {
        void GetStudent(int paymentid);
        void GetpaymentAmount(int studid);
        void GetPaymentDate(int paymentid);
        void MakePayment(string paymentid, string studid, string amount, string date);
    }
}
