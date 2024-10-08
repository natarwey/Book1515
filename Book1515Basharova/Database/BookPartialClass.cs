using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Book1515Basharova.Database;
using Book1515Basharova.Classes;

namespace Book1515Basharova.Database
{
    public partial class Book
    {
        public SolidColorBrush DiscountColor
        {
            get
            {
                if (MaxDiscount?.Value == 10)
                    return Brushes.Pink;
                else if (MaxDiscount?.Value == 5)
                    return Brushes.SeaGreen;
                else if (DatabaseConnectionClass.DatabaseConnection.MaxDiscount.Where(c => c.MaxDiscountId == MaxDiscountId).First().Value >= 15) return Brushes.Chartreuse;
                else return Brushes.Transparent;
            }
        }
        public string Newprice
        {
            get
            {
                if (ActiveDiscountId != null)
                {
                    string a = Convert.ToString(Price - (Price / 100 * DatabaseConnectionClass.DatabaseConnection.ActiveDiscount.Where(c => c.ActiveDiscountId == ActiveDiscountId).First().Value));
                    return "\t" + a;
                }
                else return null;
            }
        }
    }
}
