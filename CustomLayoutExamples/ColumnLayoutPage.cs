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
                Text = "This column is using a custom class (ColumnLayout) which subclasses VerticalStackLayout. It adds an " +
                "attached property 'Fill' which can mark an item as 'fill up the remaining available space'. It uses a custom " +
                "layout manager which converts it at layout time into a single-column Grid with rows for each child; by default " +
                "each row uses GridLength.Auto, but the items marked as 'Fill' have their rows marked as GridLength.Star. The final " +
                "result is a single column filling the page.",
                VerticalTextAlignment = TextAlignment.Center, 
                LineBreakMode = LineBreakMode.WordWrap,
                BackgroundColor = Colors.LightBlue,
                Padding = new Thickness(10)
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
