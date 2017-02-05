using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Main.Models;

namespace Main.UserControls.Views
{
    /// <summary>
    /// AccountBookList.xaml の相互作用ロジック
    /// </summary>
    public partial class AccountBookListBox : UserControl
    {
        public AccountBookListBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PaymentsListProperty = DependencyProperty.Register(
            "PaymentsList",
            typeof(ObservableCollection<Payments>),
            typeof(AccountBookListBox),
            new PropertyMetadata(new ObservableCollection<Payments>()));
        public ObservableCollection<Payments> PaymentsList
        {
            get { return (ObservableCollection<Payments>)GetValue(PaymentsListProperty); }
            set { SetValue(PaymentsListProperty, (ObservableCollection<Payments>)value); }
        }

        private void TotalButton_Click(object sender, RoutedEventArgs e)
        {
            // 金額編集用のリストを表示する。
            AmountEditor dialog = new AmountEditor();
            dialog.ShowDialog();
        }
    }
}
