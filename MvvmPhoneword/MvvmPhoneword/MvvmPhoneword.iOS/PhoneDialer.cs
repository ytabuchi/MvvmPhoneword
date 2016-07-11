using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;
using Xamarin.Forms;
using MvvmPhoneword.iOS;

[assembly: Dependency(typeof(PhoneDialer))]

namespace MvvmPhoneword.iOS
{
    public class PhoneDialer : Helpers.IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}
