using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for TitleBar.xaml
	/// </summary>
	public partial class TitleBar : UserControl
	{
		public static uint HEIGHT = 50;

		public static uint TEXT_W = 400;
		public static uint TEXT_H = HEIGHT;
		public static uint TEXT_X = ((MainWindow.WIDTH - TEXT_W) / 2);
		public static uint TEXT_Y = 0;

		public static uint MENU_BUTTON_W = 36;
		public static uint MENU_BUTTON_H = 36;
		public static uint MENU_BUTTON_X = 10;
		public static uint MENU_BUTTON_Y = ((HEIGHT - MENU_BUTTON_H) / 2);

		private Label mTextLabel;
		private RectButton mMenuButton;

		public TitleBar()
		{
			InitializeComponent();

			setTitle();
		}

		private void setTitle()
		{
			Canvas.SetTop(canvas, 0);
			Canvas.SetLeft(canvas, 0);
			canvas.Width = MainWindow.WIDTH;
			canvas.Height = HEIGHT;
			canvas.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 7);

			mTextLabel = new Label();
			Canvas.SetTop(mTextLabel, 0);
			Canvas.SetLeft(mTextLabel, 440);
			mTextLabel.Width = 400;
			mTextLabel.Height = 50;
			mTextLabel.HorizontalAlignment = HorizontalAlignment.Center;
			mTextLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
			mTextLabel.VerticalContentAlignment = VerticalAlignment.Center;
			mTextLabel.FontSize = 25;
			mTextLabel.Content = "쎄시봉 수상스키장";
			mTextLabel.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			canvas.Children.Add(mTextLabel);

			mMenuButton = new RectButton(36, 36);
			mMenuButton.setBackgroundImage("menu_white_36x36.png", "menu_white_27x27.png");
			Canvas.SetLeft(mMenuButton, 10);
			Canvas.SetTop(mMenuButton, 7);

			canvas.Children.Add(mMenuButton);
		}
	}
}
