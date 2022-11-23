using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using CustomLayouts;

namespace CustomLayoutExamples
{
    public class CustomLayoutManagerFactory : ILayoutManagerFactory
    {
        public ILayoutManager CreateLayoutManager(Layout layout)
        {
            if (layout is Grid) 
            {
                return new CustomGridLayoutManager(layout as IGridLayout);
            }

            return null;
        }
    }
}