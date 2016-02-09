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
		private Canvas mTitleBar;
		private OrderItemCanvas mOrderItemCanvas;
		private TotalCanvas mTotalCanvas;
		private MenuItemCanvas mMenuItemCanvas;

		public MainWindow()
        {
            InitializeComponent();

			setTitle();
			setOrderItemCanvse();
			setTotalCanvas();
			setMenuItemCanvas();

			//Discount d = new Discount();
			//d.ShowDialog();
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

			/*
			{
				System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
				Stream stream = assembly.GetManifestResourceStream("wsr_pos.Image.menu_white_36x36.png");
				BitmapImage bitmap_image = new BitmapImage();

				bitmap_image.BeginInit();
				bitmap_image.StreamSource = stream;
				bitmap_image.CacheOption = BitmapCacheOption.OnLoad;
				bitmap_image.EndInit();

				RenderOptions.SetBitmapScalingMode(bitmap_image, BitmapScalingMode.HighQuality);

				ImageBrush image_brush = new ImageBrush();
				image_brush.ImageSource = bitmap_image;

				Button menu_button = new Button();
				Canvas.SetLeft(menu_button, 10);
				Canvas.SetTop(menu_button, 7);
				menu_button.Width = 36;
				menu_button.Height = 36;
				menu_button.Background = image_brush;

				mTitleBar.Children.Add(menu_button);
			}
			*/
			RectButton rb = new RectButton(36, 36);
			rb.setBackgroundImage("menu_white_36x36.png", "menu_white_36x36.png");
			//rb.setText("aaaaa");
			//rb.setBackgroundColor(MetrialColor.Name.Indigo);
			Canvas.SetLeft(rb, 10);
			Canvas.SetTop(rb, 7);
			
			mTitleBar.Children.Add(rb);

			canvas.Children.Add(mTitleBar);
		}

		private void setOrderItemCanvse()
		{
			mOrderItemCanvas = new OrderItemCanvas();
			Canvas.SetTop(mOrderItemCanvas, 50);
			Canvas.SetLeft(mOrderItemCanvas, 0);
			canvas.Children.Add(mOrderItemCanvas);
		}

		private void setTotalCanvas()
		{
			mTotalCanvas = new TotalCanvas();
			Canvas.SetTop(mTotalCanvas, 50);
			Canvas.SetLeft(mTotalCanvas, 900);
			canvas.Children.Add(mTotalCanvas);

			mOrderItemCanvas.OrderChange += mTotalCanvas.setPrice;
		}

		private void setMenuItemCanvas()
		{
			mMenuItemCanvas = new MenuItemCanvas(null, mOrderItemCanvas.addOrderItem);
			mMenuItemCanvas.setPosition(0, 400, 1280, 400);
			canvas.Children.Add(mMenuItemCanvas);
		}
    }
}
