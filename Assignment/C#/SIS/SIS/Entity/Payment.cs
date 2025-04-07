using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Entity
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public Student Student { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment() { }

        public Payment(int paymentId, Student student, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentId;
            Student = student;
            Amount = amount;
            PaymentDate = paymentDate;
        }

    }
}
