using WorkPlusP2MAUI.MVVM.ViewModels;

namespace WorkPlusP2MAUI.MVVM.Views;

public partial class MainView : ContentPage
{
    private MainViewModel mainViewModel = new MainViewModel();
    public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        mainViewModel.ActualizarInformacion();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView
        {
            BindingContext = new NewTaskViewModel
            {
                Tasks = mainViewModel.Tasks,
                Categories = mainViewModel.Categories,
            }
        };

        Navigation.PushAsync(taskView);
    }
}