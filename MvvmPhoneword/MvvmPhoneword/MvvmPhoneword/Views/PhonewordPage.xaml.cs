using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MvvmPhoneword.Views
{
    public partial class PhonewordPage : ContentPage
    {
        public PhonewordPage()
        {
            InitializeComponent();

            // VMのsendをSubscribeして、Messageの内容で処理をします。
            MessagingCenter.Subscribe<ViewModels.PhonewordPageViewModel>(
                this,
                "ShowCallHistoryPage",
                async (sender) =>
                {
                    await Navigation.PushAsync(new CallHistoryPage());
                }
            );
        }
    }
}
