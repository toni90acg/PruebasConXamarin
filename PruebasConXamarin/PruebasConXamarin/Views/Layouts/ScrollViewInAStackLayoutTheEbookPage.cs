using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace PruebasConXamarin.Views.Layouts
{
    public class ScrollViewInAStackLayoutTheEbookPage : ContentPage
    {
        public ScrollViewInAStackLayoutTheEbookPage()
        {
            var mainStackLayout = new StackLayout();
            var textStackLayout = new StackLayout()
            {
                Padding = new Thickness(5),
                Spacing = 10
            };

            // Get access to the text resource. 
            var assembly = GetType().GetTypeInfo().Assembly;
            const string resource = "PruebasConXamarin.Texts.TheBlackCat.txt";

            using (var stream = assembly.GetManifestResourceStream(resource))
            {
                using (var reader = new StreamReader(stream))
                {
                    bool gotTitle = false;
                    string line;

                    // Read in a line (which is actually a paragraph).

                    while (null != (line = reader.ReadLine()))
                    {
                        Label label = new Label
                        {
                            Text = line,

                            // Black text for ebooks! 
                            TextColor = Color.Black
                        };

                        if (!gotTitle)
                        {
                            // Add first label (the title) to mainStack. 
                            label.HorizontalOptions = LayoutOptions.Center;
                            label.FontSize = Device.GetNamedSize(NamedSize.Medium, label);
                            label.FontAttributes = FontAttributes.Bold;
                            mainStackLayout.Children.Add(label); gotTitle = true;
                        }
                        else
                        {
                            // Add subsequent labels to textStack. 
                            textStackLayout.Children.Add(label);
                        }
                    }
                }
            }

            // Put the textStack in a ScrollView with FillAndExpand. 
            var scrollView = new ScrollView
            {
                Content = textStackLayout,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5, 0),
            };
            // Add the ScrollView as a second child of mainStack. 
            mainStackLayout.Children.Add(scrollView);
            // Set page content to mainStack. 
            Content = mainStackLayout;
            // White background for ebooks! 
            BackgroundColor = Color.White;
            // Add some iOS padding for the page. 
            Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
        }
    }
}
