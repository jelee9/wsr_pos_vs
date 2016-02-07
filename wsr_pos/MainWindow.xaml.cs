using System.Windows;
using System.Windows.Controls;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		private OrderItemCanvas mOrderItemCanvas;
		private TotalCanvas mTotalCanvas;
		private MenuItemCanvas mMenuItemCanvas;

		public MainWindow()
        {
            InitializeComponent();

			setOrderItemCanvse();
			setTotalCanvas();
			setMenuItemCanvas();

			Item item = new Item(0, 0, "이종은", "동해물과 백두산이 마르고 닳도록", 700000, false, false, false, 0, 0, MetrialColor.Name.Brown);
			MenuItemButton item_button = new MenuItemButton(item);
			canvas.Children.Add(item_button);

			Discount d = new Discount();
			d.ShowDialog();
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
			Canvas.SetLeft(mTotalCanvas, 0);
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
