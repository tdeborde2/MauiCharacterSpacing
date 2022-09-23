using MauiCharacterSpacing.Controls;

namespace MauiCharacterSpacing;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	void CharacterSpacingButton_Clicked(object sender, EventArgs e)
	{
		var btn = (Button)sender;
		var spacing = btn.CharacterSpacing == 5 ? 0 : btn.CharacterSpacing + 1;

		btn.CharacterSpacing = spacing;
	}

	void TextButton_Clicked(object sender, EventArgs e)
	{
		var btn = (Button)sender;
		btn.Text = btn.Text == "Change Text" ? "Change Text Back" : "Change Text";
	}
}


