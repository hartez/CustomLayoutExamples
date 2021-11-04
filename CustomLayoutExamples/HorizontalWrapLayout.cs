using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using System;

namespace CustomLayoutExamples
{
    public class HorizontalWrapLayout : StackLayout
    {
        public HorizontalWrapLayout()
        {
        }

        protected override ILayoutManager CreateLayoutManager()
        {
            return new HorizontalWrapLayoutManager(this);
        }
    }
}
