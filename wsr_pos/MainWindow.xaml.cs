using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		public static uint WIDTH = 1280;
		public static uint HEIGHT = 1024;

		public enum MODE
		{
			ORDER,
			SAVED,
			SETTINGS,
		};

		private Canvas mTitleBar;
		private OrderMain mOrderMain;

		private MODE mMode;

		public MainWindow()
        {
            InitializeComponent();

			setWindow();

			mMode = MODE.ORDER;

			setTitle();
			setMode();
			//Discount d = new Discount();
			//d.ShowDialog();
		}

		private void setWindow()
		{
			Top = 0;
			Left = 0;
			Width = WIDTH;
			Height = HEIGHT;

			WindowStyle = WindowStyle.None;
			ResizeMode = ResizeMode.NoResize;
		}

		private void setTitle()
		{
			mTitleBar = new Canvas();
			Canvas.SetTop(mTitleBar, 0);
			Canvas.SetLeft(mTitleBar, 0);
			mTitleBar.Width = 1280;
			mTitleBar.Height = 50;

			mTitleBar.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 7);

			Label title_text = new Label();
			Canvas.SetTop(title_text, 0);
			Canvas.SetLeft(title_text, 440);
			title_text.Width = 400;
			title_text.Height = 50;
			title_text.HorizontalAlignment = HorizontalAlignment.Center;
			title_text.HorizontalContentAlignment = HorizontalAlignment.Center;
			title_text.VerticalContentAlignment = VerticalAlignment.Center;
			title_text.FontSize = 25;
			title_text.Content = "쎄시봉 수상스키장";
			title_text.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mTitleBar.Children.Add(title_text);

			RectButton rb = new RectButton(36, 36);
			rb.setBackgroundImage("menu_white_36x36.png", "menu_white_27x27.png");
			Canvas.SetLeft(rb, 10);
			Canvas.SetTop(rb, 7);
			
			mTitleBar.Children.Add(rb);

			canvas.Children.Add(mTitleBar);
		}

		private void setMode()
		{
			setOrder();
		}

		private void setOrder()
		{
			mOrderMain = new OrderMain();
			Canvas.SetLeft(mOrderMain, 0);
			Canvas.SetTop(mOrderMain, 50);

			canvas.Children.Add(mOrderMain);
		}
    }
}
