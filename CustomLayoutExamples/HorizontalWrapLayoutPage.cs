using CustomLayouts;
using Microsoft.Maui.Controls;

namespace CustomLayoutExamples
{
    internal class HorizontalWrapLayoutPage : ContentPage
    {
        public HorizontalWrapLayoutPage()
        {
            Title = "Horizontal Wrap Layout";

            var layout = new HorizontalWrapLayout { Margin = 10, Spacing = 5 };

            for (int n = 0; n < 10; n++)
            {
                var button = new Button { Text = $"Button {n}" };
                layout.Add(button);
            }

            var biggerButton = layout[5] as Button;
            biggerButton.WidthRequest = 150;
            biggerButton.HeightRequest = 100;

            Content = layout;
        }
    }
}
