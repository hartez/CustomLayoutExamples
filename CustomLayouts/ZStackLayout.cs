using Microsoft.Maui.Layouts;

namespace CustomLayouts
{
    public class ZStackLayout : StackBase
    {
        protected override ILayoutManager CreateLayoutManager() => new ZStackLayoutManager(this);
    }
}
