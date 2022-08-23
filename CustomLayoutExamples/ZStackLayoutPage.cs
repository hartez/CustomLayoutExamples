using CustomLayouts;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Image = Microsoft.Maui.Controls.Image;

namespace CustomLayoutExamples
{
    internal class ZStackLayoutPage : ContentPage
    {
        public ZStackLayoutPage()
        {
            Title = "ZStack";

            var layout = new ZStackLayout { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };

            var image = new Image 
            { 
                Source = "dotnet_bot.png", 
                WidthRequest = 300, HeightRequest = 372, 
                HorizontalOptions = LayoutOptions.Center 
            };

            var topCaption = new Label
            {
                Text = "Text over the image, aligned to top",
                TextColor = Colors.Orange,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            var midCaption = new Label
            {
                Text = "Text right in the middle",
                TextColor = Colors.LightGreen,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            var bottomCaption = new Label
            {
                Text = "This is an easy way to do captions",
                TextColor = Colors.Red,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center
            };

            layout.Add(image);
            layout.Add(topCaption);
            layout.Add(midCaption);
            layout.Add(bottomCaption);

            Content = layout;
        }
    }
}
