using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using Main.Models;

namespace Main.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        /* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom   : ViewModelCommand
         *  lvcomn  : ViewModelCommand(CanExecute無)
         *  llcom   : ListenerCommand(パラメータ有のコマンド)
         *  llcomn  : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop   : 変更通知プロパティ(.NET4.5ではlpropn)
         *  
         * を使用してください。
         * 
         * Modelが十分にリッチであるならコマンドにこだわる必要はありません。
         * View側のコードビハインドを使用しないMVVMパターンの実装を行う場合でも、ViewModelにメソッドを定義し、
         * LivetCallMethodActionなどから直接メソッドを呼び出してください。
         * 
         * ViewModelのコマンドを呼び出せるLivetのすべてのビヘイビア・トリガー・アクションは
         * 同様に直接ViewModelのメソッドを呼び出し可能です。
         */

        /* ViewModelからViewを操作したい場合は、View側のコードビハインド無で処理を行いたい場合は
         * Messengerプロパティからメッセージ(各種InteractionMessage)を発信する事を検討してください。
         */

        /* Modelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedEventListenerや
         * CollectionChangedEventListenerを使うと便利です。各種ListenerはViewModelに定義されている
         * CompositeDisposableプロパティ(LivetCompositeDisposable型)に格納しておく事でイベント解放を容易に行えます。
         * 
         * ReactiveExtensionsなどを併用する場合は、ReactiveExtensionsのCompositeDisposableを
         * ViewModelのCompositeDisposableプロパティに格納しておくのを推奨します。
         * 
         * LivetのWindowテンプレートではViewのウィンドウが閉じる際にDataContextDisposeActionが動作するようになっており、
         * ViewModelのDisposeが呼ばれCompositeDisposableプロパティに格納されたすべてのIDisposable型のインスタンスが解放されます。
         * 
         * ViewModelを使いまわしたい時などは、ViewからDataContextDisposeActionを取り除くか、発動のタイミングをずらす事で対応可能です。
         */

        /* UIDispatcherを操作する場合は、DispatcherHelperのメソッドを操作してください。
         * UIDispatcher自体はApp.xaml.csでインスタンスを確保してあります。
         * 
         * LivetのViewModelではプロパティ変更通知(RaisePropertyChanged)やDispatcherCollectionを使ったコレクション変更通知は
         * 自動的にUIDispatcher上での通知に変換されます。変更通知に際してUIDispatcherを操作する必要はありません。
         */

        public void Initialize()
        {
            _dataManager = new DataManager(CommonConst.DBFileName);
            Year = 2016;
            Month = 10;
            DateTime yearMonth = new DateTime(Year, Month, 1);
            this.RefreshData(yearMonth);
        }

        #region フィールド

        private DataManager _dataManager = null;

        #endregion

        #region プライベートメソッド

        private void RefreshData(DateTime month)
        {
            MonthlyData monthlyData = _dataManager.GetMonthlyData(month);

            SpendingList = new ObservableCollection<Payments>();
            foreach (Payments ps in monthlyData.spendings)
            {
                SpendingList.Add(ps);
            }

            IncomeList = new ObservableCollection<Payments>();
            foreach (Payments ps in monthlyData.incomes)
            {
                IncomeList.Add(ps);
            }
        }

        #endregion

        #region Year変更通知プロパティ
        private int _Year = 2016;

        public int Year
        {
            get
            { return _Year; }
            set
            { 
                if (_Year == value)
                    return;
                _Year = value;
                DateTime yearMonth = new DateTime(value, Month, 1);
                this.RefreshData(yearMonth);
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Month変更通知プロパティ
        private int _Month = 10;

        public int Month
        {
            get
            { return _Month; }
            set
            { 
                if (_Month == value)
                    return;
                _Month = value;
                DateTime yearMonth = new DateTime(Year, value, 1);
                this.RefreshData(yearMonth);
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IncomeList変更通知プロパティ
        private ObservableCollection<Payments> _IncomeList;

        public ObservableCollection<Payments> IncomeList
        {
            get
            { return _IncomeList; }
            set
            { 
                if (_IncomeList == value)
                    return;
                _IncomeList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SpendingList変更通知プロパティ
        private ObservableCollection<Payments> _SpendingList;

        public ObservableCollection<Payments> SpendingList
        {
            get
            { return _SpendingList; }
            set
            { 
                if (_SpendingList == value)
                    return;
                _SpendingList = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }
}
