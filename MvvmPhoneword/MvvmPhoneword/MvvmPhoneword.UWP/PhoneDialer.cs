using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using MvvmPhoneword.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]

namespace MvvmPhoneword.UWP
{
    public class PhoneDialer : Helpers.IDialer
    {
        public bool Dial(string number)
        {
            PhoneCallManager.ShowPhoneCallUI(number, "Phoneword");
            return true;
        }
    }
}
