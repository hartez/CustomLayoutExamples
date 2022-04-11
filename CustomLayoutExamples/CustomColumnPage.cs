using CustomLayouts;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui;

namespace CustomLayoutExamples
{
    internal class CustomColumnPage : ContentPage
    {
        public CustomColumnPage()
        {
            Title = "Column Layout 2";

            var header = new Label 
            { 
                Text = "This is the column header", FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(20), HorizontalTextAlignment = TextAlignment.Center 
            };

            var footer = new Label 
            { 
                Text = "This is the footer", FontAttributes = FontAttributes.Italic, 
                FontSize = 10, Margin = new Thickness(2) 
            };
            
            var content = new Label
            {
                Text = "This is the content view. This layout is pre-made to have the 'Content' view fill up the remaining vertical space " +
                "after the header and footer have been laid out. The layout is a subclass of Layout which implements IGridLayout; it takes " +
                "a header, content, and footer view in its constuctor and lays them out in a single column. No custom layout manager is required; " +
                "it simply uses the built-in GridLayoutManager.",
                LineBreakMode = LineBreakMode.WordWrap,
                BackgroundColor = Colors.LightBlue,
                Padding = new Thickness(10)
            };

            // Once we've got the layout class created, this is all we need to do in order to use it
            Content = new ContentColumnLayout(header, content, footer); 
        }
    }
}
