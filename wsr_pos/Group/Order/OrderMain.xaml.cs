using System.Windows.Controls;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for OrderMain.xaml
	/// </summary>
	public partial class OrderMain : UserControl
	{
		private OrderItemCanvas mOrderItemCanvas;
		private TotalCanvas mTotalCanvas;
		private MenuItemCanvas mMenuItemCanvas;
		private Discount mDiscount;

		public OrderMain()
		{
			InitializeComponent();

			canvas.Width = 1280;
			canvas.Height = 974;

			setOrderItemCanvse();
			setTotalCanvas();
			setMenuItemCanvas();
		}

		private void setOrderItemCanvse()
		{
			mOrderItemCanvas = new OrderItemCanvas();
			Canvas.SetTop(mOrderItemCanvas, 0);
			Canvas.SetLeft(mOrderItemCanvas, 0);
			canvas.Children.Add(mOrderItemCanvas);
		}

		private void setTotalCanvas()
		{
			mTotalCanvas = new TotalCanvas();
			Canvas.SetTop(mTotalCanvas, 0);
			Canvas.SetLeft(mTotalCanvas, 900);
			canvas.Children.Add(mTotalCanvas);

			mOrderItemCanvas.OrderChange += mTotalCanvas.setPrice;
			mTotalCanvas.DiscountPressed += showDiscountCanvas;
		}

		private void setMenuItemCanvas()
		{
			mMenuItemCanvas = new MenuItemCanvas(null, mOrderItemCanvas.addOrderItem);
			mMenuItemCanvas.setPosition(0, 470, 1280, 624);
			canvas.Children.Add(mMenuItemCanvas);
		}

		private void showDiscountCanvas()
		{
			mDiscount = new Discount();
			mDiscount.DonePressed += mOrderItemCanvas.setDiscount;

			mDiscount.ShowDialog();
		}
	}
}
