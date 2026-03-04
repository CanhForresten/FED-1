namespace Bilvaerksted;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}
	private void OnThemeToggled(object sender, ToggledEventArgs e)
	{
		// e.Value er true hvis Switchen er slået til
		if (e.Value)
		{
			Application.Current.UserAppTheme = AppTheme.Dark;
		}
		else
		{
			Application.Current.UserAppTheme = AppTheme.Light;
		}
	}
}
