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
		private DiscountOption mDiscountOption;
		private Discount mDiscount;
		private PaymentMethod mPaymentMethod;
		private CheckOut mCheckOut;
		
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
			mTotalCanvas.DiscountPressed += showDiscountOptionCanvas;
			mTotalCanvas.CancelPressed += mOrderItemCanvas.deleteAllOrderItem;
			mTotalCanvas.CheckOutPressed += showPaymentMethodCanvas;
		}

		private void setMenuItemCanvas()
		{
			mMenuItemCanvas = new MenuItemCanvas(null, mOrderItemCanvas.addOrderItem);
			mMenuItemCanvas.setPosition(0, 470, 1280, 624);
			canvas.Children.Add(mMenuItemCanvas);
		}

		private void showDiscountOptionCanvas()
		{
			mDiscountOption = new DiscountOption();
			mDiscountOption.DiscountSelected += showDiscountCanvas;

			mDiscountOption.ShowDialog();
		}

		private void showDiscountCanvas(OrderItem.DiscountType discount_type)
		{
			switch(discount_type)
			{
				case OrderItem.DiscountType.Percent:
				{
					mDiscount = new Discount(OrderItem.DiscountType.Percent);
					mDiscount.DonePressed += mOrderItemCanvas.setDiscount;

					mDiscount.ShowDialog();
					break;
				}
				case OrderItem.DiscountType.Price:
				{
					mDiscount = new Discount(OrderItem.DiscountType.Price);
					mDiscount.DonePressed += mOrderItemCanvas.setDiscount;

					mDiscount.ShowDialog();
					break;
				}
				case OrderItem.DiscountType.Pension:
				{
					break;
				}
				case OrderItem.DiscountType.Enuri:
				{
					mDiscount = new Discount(OrderItem.DiscountType.Enuri);
					mDiscount.DonePressed += mOrderItemCanvas.setDiscount;

					mDiscount.ShowDialog();
					break;
				}
				default:
				{
					break;
				}
			}
		}

		private void showPaymentMethodCanvas()
		{
			mPaymentMethod = new PaymentMethod();
			mPaymentMethod.PaymentMethodSelected += showCheckOutCanvas;

			mPaymentMethod.ShowDialog();
		}

		private void showCheckOutCanvas(Order.PaymentMethod payment_method)
		{
			mCheckOut = new CheckOut();
			mCheckOut.ShowDialog();
		}
	}
}
