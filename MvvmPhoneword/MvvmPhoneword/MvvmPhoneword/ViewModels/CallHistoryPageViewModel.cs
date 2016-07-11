using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmPhoneword.Models;


namespace MvvmPhoneword.ViewModels
{
    public class CallHistoryPageViewModel : INotifyPropertyChanged
    {
        private List<Number> phoneNumbers;
        public List<Number> PhoneNumbers
        {
            get { return phoneNumbers; }
            set
            {
                if (phoneNumbers != value)
                {
                    phoneNumbers = value;
                    OnPropertyChanged();
                }
            }
        }

        public CallHistoryPageViewModel()
        {
            this.PhoneNumbers = Numbers.Instance.PhoneNumbers;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}