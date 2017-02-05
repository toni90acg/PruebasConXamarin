using System;
using Xamarin.Forms;

namespace PruebasConXamarin.Views.XAML
{
    public partial class ColorView : ContentView
    {
        ColorTypeConverter colorTypeConv = new ColorTypeConverter();

        string _colorName;
        public string ColorName
        {
            set
            {
                // Set the name. 
                _colorName = value;
                colorNameLabel.Text = value;
                // Get the actual Color and set the other views. 
                Color color = (Color)colorTypeConv.ConvertFrom(_colorName); //obsolete
                var color2 = (Color)colorTypeConv.ConvertFromInvariantString(_colorName);
                boxView.Color = color;
                colorValueLabel.Text = $"{(int) (255*color.R):X2}-{(int) (255*color.G):X2}-{(int) (255*color.B):X2}";
            }
            get
            {
                return _colorName;
            }
        }

        public ColorView()
        {
            InitializeComponent();
        }

        
    }
}
