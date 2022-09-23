using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MauiCharacterSpacing.Controls;

public class CustomButton : Button
{
	bool _sizeAllocated;

	double _oldCharacterSpacing;

	protected override void OnSizeAllocated(double width, double height)
	{
		if(!_sizeAllocated && WidthRequest == -1 && HorizontalOptions.Alignment != LayoutAlignment.Fill)
		{
			_sizeAllocated = true;
			this.WidthRequest = width + ((Text.Length - 1) * CharacterSpacing);
			return;
		}
		base.OnSizeAllocated(width, height);
	}

	protected override void OnPropertyChanging([CallerMemberName] string propertyName = null)
	{
		base.OnPropertyChanging(propertyName);
		if(propertyName == "Text")
		{
			if (_sizeAllocated)
			{
				WidthRequest = -1;
				_sizeAllocated = false;
			}
		}
	}

	protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		base.OnPropertyChanged(propertyName);
		if (_sizeAllocated && HorizontalOptions.Alignment != LayoutAlignment.Fill)
		{
			if (propertyName == "CharacterSpacing")
			{
				if (CharacterSpacing < _oldCharacterSpacing)
				{
					WidthRequest = Width - ((Text.Length - 1) * (_oldCharacterSpacing - CharacterSpacing));
				}
				if (CharacterSpacing > _oldCharacterSpacing)
				{
					WidthRequest = Width + ((Text.Length - 1) * (CharacterSpacing - _oldCharacterSpacing));
				}
			}
		}
		_oldCharacterSpacing = CharacterSpacing;
	}
}

