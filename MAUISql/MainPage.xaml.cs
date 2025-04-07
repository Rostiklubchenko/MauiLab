using MAUISql.ViewModels;
using Microsoft.Maui.Devices;

namespace MAUISql;

public partial class MainPage : ContentPage
{
    private readonly ProductsViewModel _viewModel;

    public MainPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext= viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadProductsAsync();
        string info = $"Назва пристрою: {DeviceInfo.Name}\n" + $"Версія ОС: {DeviceInfo.VersionString}\n";
        DeviceInfoLabel.Text = info;
#if ANDROID
        EntryPrice.BackgroundColor = Colors.Transparent;
        EntryName.BackgroundColor = Colors.Transparent;
        EntryPrice.PlaceholderColor = Colors.Gray;
        EntryName.PlaceholderColor = Colors.Gray;
#elif WINDOWS10_0_17763_0_OR_GREATER
        EntryPrice.BackgroundColor = Colors.LightGray;
        EntryName.BackgroundColor = Colors.LightGray;
        EntryPrice.PlaceholderColor = Colors.Black;
        EntryName.PlaceholderColor = Colors.Black;
#endif
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        EntryName.Focus();
    }
}

