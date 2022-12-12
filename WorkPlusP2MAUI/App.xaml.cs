using WorkPlusP2MAUI.MVVM.Views;

namespace WorkPlusP2MAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new MainView());
    }
}
