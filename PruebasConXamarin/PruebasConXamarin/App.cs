using PruebasConXamarin.Chapter11.TheBindableInfrastructure;
using PruebasConXamarin.Chapter11.TheBindableInfrastructure.AlternativeLabel;
using PruebasConXamarin.Views.Buttons;
using PruebasConXamarin.Views.XAML;
using PruebasConXamarin.Views.XAML.TapGestures;
using Xamarin.Forms;

namespace PruebasConXamarin
{
    public class App : Application
    {
        const string displayLabelText = "displayLabelText";

        public App()
        {//Pagina 246 (267 de 1187)

            if (Properties.ContainsKey(displayLabelText))
            {
                DisplayLabelText = (string) Properties[displayLabelText];
            }

            //MainPage = new ReflectedColorsPage();
            //MainPage = new VerticalOptionsDemoPage();
            //MainPage = new FramedTextPage();
            //MainPage = new ScrollViewInAStackLayoutTheEbookPage();
            //MainPage = new ButtonLoggerPage();
            //MainPage = new TwoButtonsPage();
            //MainPage = new ButtonLambdasPage();
            //MainPage = new SimplestKeypad();
            //MainPage = new PersistentKeypadPage();
            //MainPage = new CodePlusXamlPage();
            //MainPage = new ScaryColorListPage();
            //MainPage = new XamlClock();
            //MainPage = new ColorViewListPage();
            //MainPage = new MonkeyTapPage();
            //MainPage = new PropertySettingsPage();
            //MainPage = new DynamicVsStaticCodePage();
            MainPage = new PointSizedTextPage();

        }

        public string DisplayLabelText { set; get; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Properties[displayLabelText] = DisplayLabelText;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
