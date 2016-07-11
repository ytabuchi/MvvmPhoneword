using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using MvvmPhoneword.Models;

namespace MvvmPhoneword.ViewModels
{
    public class PhonewordPageViewModel : INotifyPropertyChanged
    {
        
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    // ModelのPhoneNumberをSetします。 TODO: ここで良い？
                    Numbers.Instance.PhoneNumber = phoneNumber;
                    OnPropertyChanged();
                }
            }
        }

        private string translatedNumber;
        public string TranslatedNumber
        {
            get { return translatedNumber; }
            set
            {
                if (translatedNumber != value)
                {
                    translatedNumber = value;
                    OnPropertyChanged();
                    // CallCommandのcanExecuteを再評価させます。
                    CallCommand.ChangeCanExecute();
                }
            }
        }

        public Command CallCommand { get; private set; }
        public Command CallHistoryCommand { get; private set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public PhonewordPageViewModel()
        {
            // ModelにPropertyChangedイベントが発生したらViewModelで受け取ります。
            Numbers.Instance.PropertyChanged += Instance_PropertyChanged;

            // public Command (Action execute, Func<bool> canExecute);
            // 第2引数でbool値を受け取り、ボタンの実行可否が判断されます。
            this.CallCommand = new Command(() =>
            {
                // Dialメソッドを呼び出します。
                Numbers.Instance.Dial();
                // CallHistoryCommandのcanExecuteを再評価します。
                CallHistoryCommand.ChangeCanExecute();
            }, CanCall);


            this.CallHistoryCommand = new Command(() =>
            {
                // MessagingCenterを使用してViewModelからのページ遷移を行います。
                MessagingCenter.Send(this, "ShowCallHistoryPage");
            }, CanShowHistory);
        }

        // CallCommand用のFunc<bool> canExecute
        // ModelのTranslatedNumberがあればTrueを返します。 TODO: ViewModelだけでチェックすべき？
        private bool CanCall()
        {
            return !string.IsNullOrEmpty(Numbers.Instance.TranslatedNumber);
        }

        // CallHistoryCommand用のFunc<bool> canExecute
        // ModelのListのCountが1以上であればTrueを返します。 TODO: これもViewModelだけでチェックすべき？
        private bool CanShowHistory()
        {
            return Numbers.Instance.PhoneNumbers.Count > 0;
        }


        /// <summary>
        /// Do something depending on the PropertyChanged events you catched.
        /// </summary>
        void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Numbers.Instance.PhoneNumber):
                    this.PhoneNumber = Numbers.Instance.PhoneNumber;
                    break;
                case nameof(Numbers.Instance.TranslatedNumber):
                    this.TranslatedNumber = Numbers.Instance.TranslatedNumber;
                    break;
                default:
                    break;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
