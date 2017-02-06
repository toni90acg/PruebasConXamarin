using Xamarin.Forms;

namespace PruebasConXamarin.Chapter11.TheBindableInfrastructure.AlternativeLabel
{
    public class AlternativeLabel : Label
    {
        public static readonly BindableProperty PointSizeProperty =
            BindableProperty.Create("PointSize", // propertyName 
                typeof(double), // returnType 
                typeof(AlternativeLabel), // declaringType 
                8.0, // defaultValue 
                propertyChanged: OnPointSizeChanged);

        public AlternativeLabel()
        {
            SetLabelFontSize((double) PointSizeProperty.DefaultValue);
        }

        public double PointSize
        {
            set { SetValue(PointSizeProperty, value); }
            get { return (double)GetValue(PointSizeProperty); }
        }

        private static void OnPointSizeChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AlternativeLabel)bindable).OnPointSizeChanged((double)newvalue);
        }

        private void OnPointSizeChanged(double newValue)
        {
            SetLabelFontSize(newValue);
        }

        private void SetLabelFontSize(double pointSize)
        {
            FontSize = 160 * pointSize / 72;
        }
    }


}
