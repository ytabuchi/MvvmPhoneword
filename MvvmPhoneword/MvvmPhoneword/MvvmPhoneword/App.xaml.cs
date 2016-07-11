using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MvvmPhoneword
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new Views.PhonewordPage());
            if (Device.OS == TargetPlatform.iOS)
                nav.BarBackgroundColor = Color.FromHex("#b765b8");
            else if (Device.OS == TargetPlatform.Android)
                nav.BarBackgroundColor = Color.FromHex("#75c465");
            else
                nav.BarBackgroundColor = Color.FromHex("#3498db");
            nav.BarTextColor = Color.White;
            MainPage = nav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
