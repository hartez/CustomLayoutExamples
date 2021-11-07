using CustomLayouts;
using Xunit;
using static LayoutManagerTests.TestHelpers;

namespace LayoutManagerTests
{
    public class HorizontalWrapLayoutManagerTests
    {
        [Fact]
        public void SizeMatchesSingleItem()
        {
            var layout = new HorizontalWrapLayout();
            var view0 = CreateTestView(100, 50);
            layout.Add(view0);

            var manager = new HorizontalWrapLayoutManager(layout);

            var measure = manager.Measure(200, double.PositiveInfinity);
            Assert.Equal(100, measure.Width);
            Assert.Equal(50, measure.Height);
        }

        [Fact]
        public void HeightAccountsForMultipleRows()
        {
            var layout = new HorizontalWrapLayout();
            var view0 = CreateTestView(100, 50);
            var view1 = CreateTestView(100, 50);
            var view2 = CreateTestView(100, 50);
            layout.Add(view0);
            layout.Add(view1);
            layout.Add(view2);

            var manager = new HorizontalWrapLayoutManager(layout);

            var measure = manager.Measure(200, double.PositiveInfinity);
            Assert.Equal(200, measure.Width);
            Assert.Equal(100, measure.Height);
        }
    }
}