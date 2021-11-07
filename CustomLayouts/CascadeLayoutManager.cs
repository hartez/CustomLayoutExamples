using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using System.Linq;
using Microsoft.Maui;
using System;

namespace CustomLayouts
{
    public class CascadeLayoutManager : StackLayoutManager
    {
        CascadeLayout _cascade;

        public CascadeLayoutManager(CascadeLayout cascade) : base(cascade)
        {
            _cascade = cascade;
        }

        public override Size Measure(double widthConstraint, double heightConstraint)
        {
            var padding = _cascade.Padding;
            var spacing = _cascade.Spacing;

            widthConstraint -= padding.HorizontalThickness;
            heightConstraint -= padding.VerticalThickness;

            double x = padding.Left;
            double y = padding.Top;
            double totalWidth = 0;
            double totalHeight = 0;

            foreach (var child in _cascade) 
            { 
                var current = child.Measure(widthConstraint, heightConstraint);

                totalWidth = Math.Max(totalWidth, x + current.Width);
                totalHeight = Math.Max(totalHeight, y + current.Height);

                x += spacing;
                y += spacing;

                widthConstraint -= spacing;
                heightConstraint -= spacing;
            }

            return new Size(totalWidth + padding.HorizontalThickness, 
                totalHeight + padding.VerticalThickness);
        }

        public override Size ArrangeChildren(Rectangle bounds)
        {
            var padding = _cascade.Padding;
            var spacing = _cascade.Spacing;

            double x = padding.Left;
            double y = padding.Top;

            double totalWidth = 0;
            double totalHeight = 0;

            foreach (var child in _cascade)
            {
                var width = child.DesiredSize.Width;
                var height = child.DesiredSize.Height; 
                child.Arrange(new Rectangle(x, y, width, height));

                totalWidth = Math.Max(totalWidth, x + width);
                totalWidth = Math.Max(totalHeight, y + height);

                x += spacing;
                y += spacing;
            }

            return new Size(totalWidth + padding.HorizontalThickness,
                totalHeight + padding.VerticalThickness);
        }
    }
}
