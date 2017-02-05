using Livet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Main.UserControls.Views
{
    /// <summary>
    /// YearMonthPicker.xaml の相互作用ロジック
    /// </summary>
    public partial class YearMonthPicker : UserControl
    {
        public static readonly DependencyProperty YearProperty = DependencyProperty.Register(
            "Year",
            typeof(int),
            typeof(YearMonthPicker),
            new FrameworkPropertyMetadata(2018));

        public static readonly DependencyProperty MonthProperty = DependencyProperty.Register(
            "Month",
            typeof(int),
            typeof(YearMonthPicker),
            new FrameworkPropertyMetadata(11));

        #region Year変更通知プロパティ
        public int Year
        {
            get
            { return (int)GetValue(YearProperty); }
            set
            {
                int y = (int)GetValue(YearProperty);
                if (y == value) return;
                if (value < 1986 || 3000 < value) return;
                SetValue(YearProperty, value);
            }
        }
        #endregion

        #region Month変更通知プロパティ
        public int Month
        {
            get
            { return (int)GetValue(MonthProperty); }
            set
            {
                int m = (int)GetValue(MonthProperty);
                if (m == value) return;
                if (value < 1 || 12 < value) return;
                SetValue(MonthProperty, value);
            }
        }
        #endregion

        public YearMonthPicker()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) { this.SelectMonthPopup.IsOpen = !this.SelectMonthPopup.IsOpen; }
        private void MinusYearButton_Click(object sender, RoutedEventArgs e) { Year--; }
        private void PlusYearButton_Click(object sender, RoutedEventArgs e) { Year++; }
        private void SelectMonthButtonClick(object sender, RoutedEventArgs e)
        {
            Month = int.Parse(((Button)sender).Content.ToString());
            this.SelectMonthPopup.IsOpen = false;
        }

        private void MinusMonthButton_Click(object sender, RoutedEventArgs e)
        {
            if(Month == 1)
            {
                Year--;
                Month = 12;
            }
            else
            {
                Month--;
            }
        }

        private void PlusMonthButton_Click(object sender, RoutedEventArgs e)
        {
            if(Month == 12)
            {
                Year++;
                Month = 1;
            }
            else
            {
                Month++;
            }
        }
    }
}
