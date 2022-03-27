using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_APPLICATION_CLASSES_LIST.BL
{
    class customer_name_pin
    {
        public string name;
        public string pin;
    }
    class customer_name_bill
    {
        public string name;
        public int bill;
    }
    class stock_name_price :IComparable<stock_name_price>
    {
        public string name;
        public int price;
        public int CompareTo(stock_name_price o)
        {
            return this.price.CompareTo(o.price);
        }
    }
    class shop_bill_amount :IComparable<shop_bill_amount>
    {
        public string bill_name;
        public int bill_amount;
        public int CompareTo(shop_bill_amount o)
        {
            return this.bill_amount.CompareTo(o.bill_amount);
        }
    }
    class customer_name_order
    {
        public string name;
        public string order;
    }
}

