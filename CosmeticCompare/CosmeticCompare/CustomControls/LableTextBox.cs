using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CosmeticCompare.CustomControls
{
	/// <summary>
	/// </summary>
	public class LableTextBox : TextBox
	{
		public static DependencyProperty LabelTextProperty =
			DependencyProperty.Register(
				"LabelText",
				typeof(string),
				typeof(LableTextBox));

		public static DependencyProperty LabelTextColorProperty =
			DependencyProperty.Register(
				"LabelTextColor",
				typeof(Brush),
				typeof(LableTextBox));

		private static DependencyPropertyKey HasTextPropertyKey =
			DependencyProperty.RegisterReadOnly(
				"HasText",
				typeof(bool),
				typeof(LableTextBox),
				new PropertyMetadata());
		public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

		static LableTextBox()
		{

			DefaultStyleKeyProperty.OverrideMetadata(
				typeof(LableTextBox),
				new FrameworkPropertyMetadata(typeof(LableTextBox)));
		}

		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			base.OnTextChanged(e);
			HasText = Text.Length != 0;
		}

		public string LabelText
		{
			get { return (string)GetValue(LabelTextProperty); }
			set { SetValue(LabelTextProperty, value); }
		}

		public Brush LabelTextColor
		{
			get { return (Brush)GetValue(LabelTextColorProperty); }
			set { SetValue(LabelTextColorProperty, value); }
		}

		public bool HasText
		{
			get { return (bool)GetValue(HasTextProperty); }
			private set { SetValue(HasTextPropertyKey, value); }
		}
	}
}
