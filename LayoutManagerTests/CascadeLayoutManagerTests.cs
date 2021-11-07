using CustomLayouts;
using Xunit;
using static LayoutManagerTests.TestHelpers;

namespace LayoutManagerTests
{
    public class CascadeLayoutManagerTests
    {
        [Fact]
        public void SizeMatchesSingleItem()
        {
            var layout = new CascadeLayout();
            var view = CreateTestView(100, 50);
            layout.Add(view);

            var manager = new CascadeLayoutManager(layout);

            var measure = manager.Measure(double.PositiveInfinity, double.PositiveInfinity);
            Assert.Equal(50, measure.Height);
            Assert.Equal(100, measure.Width);
        }

    }
}