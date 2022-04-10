using CustomLayouts;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui;

namespace CustomLayoutExamples
{
    internal class ColumnLayoutPage : ContentPage
    {
        public ColumnLayoutPage()
        {
            Title = "Column Layout";

            var layout = new ColumnLayout();

            var top = new Label { Text = "Top", Margin = new Thickness(20) };
            var bottom = new Label { Text = "Bottom", Margin = new Thickness(10) };

            var middle = new Label 
            { 
                Text = "Middle", 
                VerticalTextAlignment = TextAlignment.Center, 
                HorizontalTextAlignment = TextAlignment.Center, 
                BackgroundColor = Colors.LightBlue 
            };

            layout.Add(top);
            layout.Add(middle);
            layout.Add(bottom);

            // Mark the middle section of the column as "expand to fill the available space"
            layout.SetFill(middle, true);

            Content = layout;
        }
    }
}
