using CustomLayouts;
using Microsoft.Maui.Controls;
using Xunit;

namespace LayoutManagerTests
{
    public class CustomGridLayoutManagerTests
    {
        [Fact]
        public void RowDefinitionsAddedIfNeeded() 
        {
            var grid = new Grid();

            var view0 = new Label { Text = "view0" };
            grid.Add(view0);
            Grid.SetRow(view0, 5);

            var manager = new CustomGridLayoutManager(grid);
            manager.Measure(100, 100);

            Assert.Equal(6, grid.RowDefinitions.Count);
        }

        [Fact]
        public void RowDefinitionsUnchangedIfSufficient()
        {
            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition()
                }
            };

            var view0 = new Label { Text = "view0" };
            grid.Add(view0);
            Grid.SetRow(view0, 5);

            var manager = new CustomGridLayoutManager(grid);
            manager.Measure(100, 100);

            Assert.Equal(7, grid.RowDefinitions.Count);
        }
    }
}