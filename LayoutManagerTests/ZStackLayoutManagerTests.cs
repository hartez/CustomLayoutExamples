using CustomLayouts;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using NSubstitute;
using Xunit;
using static LayoutManagerTests.TestHelpers;

namespace LayoutManagerTests
{
    public class ZStackLayoutManagerTests 
    {
        [Fact]
        public void MeasureWidthEqualsWidestChild()
        {
            var expectedWidth = 200;

            var view = CreateTestView(100, 100);
            var viewNarrow = CreateTestView(50, 100);
            var viewWide = CreateTestView(expectedWidth, 100);

            var stack = new ZStackLayout { view, viewNarrow, viewWide };

            var manager = new ZStackLayoutManager(stack);
            var measure = manager.Measure(double.PositiveInfinity, double.PositiveInfinity);

            Assert.Equal(expectedWidth, measure.Width);
        }

        [Fact]
        public void MeasureHeightEqualsTallestChild()
        {
            var expectedHeight = 200;

            var view = CreateTestView(100, 100);
            var viewShort = CreateTestView(100, 50);
            var viewTall = CreateTestView(100, expectedHeight);

            var stack = new ZStackLayout{ view, viewTall, viewShort };

            var manager = new ZStackLayoutManager(stack);
            var measure = manager.Measure(double.PositiveInfinity, double.PositiveInfinity);

            Assert.Equal(expectedHeight, measure.Height);
        }

        [Fact]
        public void IgnoresCollapsedViews()
        {
            var view = CreateTestView(100, 100);
            var collapsedView = CreateTestView(200, 200);
            collapsedView.Visibility.Returns(Visibility.Collapsed);

            var stack = new ZStackLayout { view, collapsedView };

            var manager = new ZStackLayoutManager(stack);
            var measure = manager.Measure(double.PositiveInfinity, double.PositiveInfinity);
            manager.ArrangeChildren(new Rect(Point.Zero, measure));

            // View is visible, so we expect it to be measured and arranged
            view.Received().Measure(Arg.Any<double>(), Arg.Any<double>());
            view.Received().Arrange(Arg.Any<Rect>());

            // View is collapsed, so we expect it not to be measured or arranged
            collapsedView.DidNotReceive().Measure(Arg.Any<double>(), Arg.Any<double>());
            collapsedView.DidNotReceive().Arrange(Arg.Any<Rect>());
        }

        [Fact]
        public void DoesNotIgnoreHiddenViews()
        {
            var view = CreateTestView(100, 100);
            var hiddenView = CreateTestView(100, 100);
            hiddenView.Visibility.Returns(Visibility.Hidden);

            var stack = new ZStackLayout { view, hiddenView };

            var manager = new ZStackLayoutManager(stack);
            var measure = manager.Measure(double.PositiveInfinity, double.PositiveInfinity);
            manager.ArrangeChildren(new Rect(Point.Zero, measure));

            // View is visible, so we expect it to be measured and arranged
            view.Received().Measure(Arg.Any<double>(), Arg.Any<double>());
            view.Received().Arrange(Arg.Any<Rect>());

            // View is hidden, so we expect it to be measured and arranged (since it'll need to take up space)
            hiddenView.Received().Measure(Arg.Any<double>(), Arg.Any<double>());
            hiddenView.Received().Arrange(Arg.Any<Rect>());
        }

        [Fact]
        public void ArrangeRespectsBounds()
        {
            var view = CreateTestView(100, 100);
            var stack = new ZStackLayout { view };

            var manager = new ZStackLayoutManager(stack);
            var measuredSize = manager.Measure(double.PositiveInfinity, 100);
            manager.ArrangeChildren(new Rect(new Point(10, 15), measuredSize));

            var expectedRectangle0 = new Rect(10, 15, 100, 100);

            stack[0].Received().Arrange(Arg.Is(expectedRectangle0));
        }
    }
}