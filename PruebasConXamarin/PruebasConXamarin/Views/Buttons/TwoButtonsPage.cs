using System;
using Xamarin.Forms;

namespace PruebasConXamarin.Views.Buttons
{
    public class TwoButtonsPage : ContentPage
    {
        readonly Button _addButton;
        private readonly Button _removeButton;
        readonly StackLayout _loggerLayout = new StackLayout();

        public TwoButtonsPage()
        {
            // Create the Button views and attach Clicked handlers. 
            _addButton = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            _addButton.Clicked += OnButtonClicked;

            _removeButton = new Button
            {
                Text = "Remove",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = false
            };
            _removeButton.Clicked += OnButtonClicked;

            Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

            // Assemble the page. 
            Content = new StackLayout
            {
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            _addButton,
                            _removeButton
                        }
                    },
                    new ScrollView
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = _loggerLayout
                    }
                }
            };
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button) sender;
            if (button == _addButton)
            {
                // Add Label to scrollable StackLayout. 
                _loggerLayout.Children.Add(new Label
                {
                    Text = "Button clicked at " + DateTime.Now.ToString("T")
                });
            }
            else
            {
                // Remove topmost Label from StackLayout. 
                _loggerLayout.Children.RemoveAt(0);
            } 
            // Enable "Remove" button only if children are present. 
            _removeButton.IsEnabled = _loggerLayout.Children.Count > 0;
        }
    }
}
