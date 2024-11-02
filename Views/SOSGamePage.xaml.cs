using SOS_NET_MAUI.ViewModel;

namespace SOS_NET_MAUI.Views;

public partial class SOSGamePage : ContentPage
{
	public SOSGamePage()
	{
		InitializeComponent();
		this.BindingContext = new SOSGamePageViewModel();
	}
}