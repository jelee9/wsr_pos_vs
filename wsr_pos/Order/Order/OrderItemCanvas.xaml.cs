using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for OrderItemCanvas.xaml
	/// </summary>
	public partial class OrderItemCanvas : UserControl
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

		List<Order> mOrderList;
		ScrollViewer mOrderItemButtonScrollViewer;
		StackPanel mOrderItemButtonStackPanel;

		public OrderItemCanvas()
		{
			InitializeComponent();

			mOrderList = new List<Order>();

			canvas.Width = OrderItemButton.WIDTH_WITH_SCROLL;
			canvas.Height = OrderItemButton.HEIGHT * 5;

			mOrderItemButtonScrollViewer = new ScrollViewer();
			mOrderItemButtonScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
			mOrderItemButtonScrollViewer.Width = OrderItemButton.WIDTH_WITH_SCROLL;
			mOrderItemButtonScrollViewer.Height = OrderItemButton.HEIGHT * 5;
			Canvas.SetTop(mOrderItemButtonScrollViewer, 0);
			Canvas.SetLeft(mOrderItemButtonScrollViewer, 0);
			canvas.Children.Add(mOrderItemButtonScrollViewer);

			mOrderItemButtonStackPanel = new StackPanel();
			mOrderItemButtonStackPanel.Orientation = Orientation.Vertical;
			mOrderItemButtonStackPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
			Canvas.SetTop(mOrderItemButtonStackPanel, 0);
			Canvas.SetLeft(mOrderItemButtonStackPanel, 0);
			mOrderItemButtonScrollViewer.Content = mOrderItemButtonStackPanel;
		}

		public void addOrderItem(Item item)
		{
			bool is_already_added = false;

			foreach (Order order in mOrderList)
			{
				if (order.item.getItem().getId() == item.getId())
				{
					order.item.increaseQuantity();
					is_already_added = true;
					order.button.refreshOrder(order.item);
					break;
				}
			}

			if (is_already_added == false)
			{
				OrderItem order_item = new OrderItem(item);

				OrderItemButton order_item_button = new OrderItemButton(order_item, increaseQuantity, decreaseQuantity);
				order_item_button.Width = OrderItemButton.WIDTH;
				order_item_button.Height = OrderItemButton.HEIGHT;

				mOrderList.Add(new Order(order_item, order_item_button));

				mOrderItemButtonStackPanel.Children.Add(order_item_button);
			}
		}

		private void increaseQuantity(Item item)
		{
			foreach (Order order in mOrderList)
			{
				if (order.item.getItem().getId() == item.getId())
				{
					order.item.increaseQuantity();
					order.button.refreshOrder(order.item);
					Debug.Write("Increase : " + order.item.getQuantity());
					break;
				}
			}
		}

		private void decreaseQuantity(Item item)
		{
			foreach (Order order in mOrderList)
			{
				if (order.item.getItem().getId() == item.getId())
				{
					order.item.decreaseQuantity();
					order.button.refreshOrder(order.item);
					Debug.Write("Decrease : " + order.item.getQuantity());

					if (order.item.getQuantity() == 0)
					{
						mOrderItemButtonStackPanel.Children.Remove(order.button);
						mOrderList.Remove(order);

						Debug.Write("Button is removing : " + order.item.getItem().getName());
						return;
					}

					break;
				}
			}
		}
	}
}
