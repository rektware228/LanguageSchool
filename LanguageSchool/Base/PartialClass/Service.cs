using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using LanguageSchool.Base;

namespace LanguageSchool.Base
{
    public partial class Service
    {
        //
        public string costTimeStr
        {
            get
            {
                if (Discount == 0) return $"{Cost:0} рублей за {DurationInSeconds / 60} минут";
                else return $"{CostAfterDiscount:0} рублей за {DurationInSeconds / 60} минут";
            }
        }
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0) return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }
        public string DiscountStr
        {
            get
            {
                if (Discount == 0) return "";
                else return $"* скидка {Discount }%";
            }
        }

        public SolidColorBrush ColorDiscount
        {
            get
            {
                if (Discount == 0)
                    return new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                else
                    return new SolidColorBrush(System.Windows.Media.Color.FromRgb(178, 255, 102));
            }
        }

        public decimal CostAfterDiscount { 
            get
            {
                return Cost - (Cost * (decimal)Discount / 100);
            } 
        }

    }
}
