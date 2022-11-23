using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace CustomLayoutExamples
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Set up a custom layout manager so we can replace the default manager for Grid
            builder.Services.Add(
                new ServiceDescriptor(typeof(ILayoutManagerFactory), new CustomLayoutManagerFactory()));

            return builder.Build();
        }
    }
}