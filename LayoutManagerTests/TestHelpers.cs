using Microsoft.Maui;
using NSubstitute;
using Microsoft.Maui.Graphics;

namespace LayoutManagerTests
{
    public static class TestHelpers
    {
        public static IView CreateTestView(double width, double height)
        {
            var view = Substitute.For<IView>();
            view.DesiredSize.Returns(new Size(width, height));
            view.Measure(Arg.Any<double>(), Arg.Any<double>()).Returns(new Size(width, height));
            return view;
        }
    }
}