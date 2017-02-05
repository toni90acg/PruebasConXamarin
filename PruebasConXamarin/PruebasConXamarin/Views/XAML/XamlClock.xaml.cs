using System;
using Xamarin.Forms;

namespace PruebasConXamarin.Views.XAML
{
    public partial class XamlClock : ContentPage
    {
        public XamlClock()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        bool OnTimerTick()
        {
            DateTime dt = DateTime.Now;
            timeLabel.Text = dt.ToString("T");
            dateLabel.Text = dt.ToString("D");
            return true;
        }
    }
}
