using System;
using Xamarin.Forms;

namespace PruebasConXamarin.Views.Sizes
{
    public class WhatSizePage : ContentPage //Me quede en 97 (118 de 1187) Esto era un poco rollo...
    {
        private readonly Label label;
        public WhatSizePage()
        {
            label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Content = label;
            SizeChanged += OnPageSizeChanged;
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            label.Text = $"{Width} \u00D7 {Height}";
        }

    }
}
