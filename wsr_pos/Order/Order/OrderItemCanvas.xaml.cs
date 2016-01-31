using System.Collections.Generic;
using System.Windows.Controls;

namespace wsr_pos
{
	public struct Order
	{
		public OrderItem item;
		public OrderItemButton button;

		public Order(OrderItem item, OrderItemButton button)
		{
			this.item = item;
			this.button = button;
		}
	}

	/// <summary>
	/// Interaction logic for OrderItemCanvas.xaml
	/// </summary>
	public partial class OrderItemCanvas : UserControl
	{
		List<Order> mOrderItemsList;

		public OrderItemCanvas()
		{
			InitializeComponent();
		}
	}
}
