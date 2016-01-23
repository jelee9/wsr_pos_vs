using System.Windows.Controls;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for OrderItemButton.xaml
	/// </summary>
	public partial class OrderItemButton : UserControl
	{
		private OrderItem mOrderItem;
		public OrderItemButton(OrderItem order_item = null)
		{
			InitializeComponent();

			mOrderItem = order_item;

			CircleButton cb = new CircleButton();
			Canvas.SetTop(cb, 0);
			Canvas.SetLeft(cb, 200);
			canvas.Children.Add(cb);
		}
	}
}
