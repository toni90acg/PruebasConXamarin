using System;
using Xamarin.Forms;

namespace PruebasConXamarin.Views.Buttons
{
    public class ButtonLoggerPage : ContentPage
    {
        StackLayout loggerLayout = new StackLayout();

        public ButtonLoggerPage()
        {
            // Create the Button and attach Clicked handler. 
            Button button = new Button
            {
                Text = "Log the Click Time"
            };
            button.Clicked += OnButtonClicked;

            Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

            // Assemble the page. 
            Content = new StackLayout
            {
                Children =
                {
                    button,
                    new ScrollView
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = loggerLayout
                    }
                }
            };
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            // Add Label to scrollable StackLayout. 
            loggerLayout.Children.Add(new Label
            {
                Text = "Button clicked at " + DateTime.Now.ToString("T")
            });

            Button button = (Button)sender;
            StackLayout outerLayout = (StackLayout)button.Parent;
            ScrollView scrollView = (ScrollView)outerLayout.Children[1];
            StackLayout loggerLayoutFromTheSender = (StackLayout)scrollView.Content;

            loggerLayoutFromTheSender.Children.Add(new Label
            {
                Text = "From the sender"
            });
        }
    }
}
