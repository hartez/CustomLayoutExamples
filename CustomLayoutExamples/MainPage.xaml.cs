using Microsoft.Maui.Controls;

namespace CustomLayoutExamples
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			CascadeLayoutButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new CascadeLayoutPage()); };
			HorizontalWrapLayoutButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new HorizontalWrapLayoutPage()); };
			ColumnLayoutButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new ColumnLayoutPage()); };
			CustomColumnButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new CustomColumnPage()); };
		}
	}
}
