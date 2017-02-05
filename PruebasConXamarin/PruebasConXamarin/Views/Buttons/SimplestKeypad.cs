using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PruebasConXamarin.Views.Buttons
{
    public class SimplestKeypad : ContentPage
    {
        Label displayLabel;
        Button backspaceButton;

        public SimplestKeypad()
        {
            // Create a vertical stack for the entire keypad.
            StackLayout mainStack = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            // First row is the Label.
            displayLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End
            };
            mainStack.Children.Add(displayLabel);

            // Second row is the backspace Button.
            backspaceButton = new Button
            {
                Text = "\u21E6",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                IsEnabled = false
            };
            backspaceButton.Clicked += OnBackspaceButtonClicked;
            mainStack.Children.Add(backspaceButton);

            // Now do the 10 number keys.
            StackLayout rowStack = null;
            for (int num = 1; num <= 10; num++)
            {
                if ((num - 1)%3 == 0)
                {
                    rowStack = new StackLayout {Orientation = StackOrientation.Horizontal};
                    mainStack.Children.Add(rowStack);
                }
                Button digitButton = new Button
                {
                    Text = (num%10).ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    StyleId = (num%10).ToString()
                };
                digitButton.Clicked += OnDigitButtonClicked;

                // For the zero button, expand to fill horizontally.
                if (num == 10)
                {
                    digitButton.HorizontalOptions = LayoutOptions.FillAndExpand;
                }
                rowStack.Children.Add(digitButton);
            }
            Content = mainStack;

            IDictionary<string, object> properties = Application.Current.Properties;
            if (properties.ContainsKey("displayLabelText"))
            {
                displayLabel.Text = properties["displayLabelText"] as string;
                backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
            }
        }

        void OnDigitButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button) sender;
            displayLabel.Text += (string) button.StyleId;
            backspaceButton.IsEnabled = true;
            Application.Current.Properties["displayLabelText"] = displayLabel.Text;
        }

        void OnBackspaceButtonClicked(object sender, EventArgs args)
        {
            string text = displayLabel.Text;
            displayLabel.Text = text.Substring(0, text.Length - 1);
            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
            Application.Current.Properties["displayLabelText"] = displayLabel.Text;
        }
    }
}
