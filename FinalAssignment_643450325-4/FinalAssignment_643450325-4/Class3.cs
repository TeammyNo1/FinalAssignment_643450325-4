using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment_643450325_4
{
    internal class Class3
    {
        double totalPrice = 0;
        public void Bill(double pay, double getmoney)
        {
            this.totalPrice = getmoney - pay;
        }
        public double payBill()
        {
            return totalPrice;
        }
    }
}
