using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace wsr_pos
{
	public delegate void OrderChangeEvent(uint sub_total_price, uint discount_price, uint total_price);
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
		OrderHeader mOrderHeader;
		ScrollViewer mOrderItemButtonScrollViewer;
		StackPanel mOrderItemButtonStackPanel;

		public OrderItemCanvas()
		{
			InitializeComponent();

			mOrderList = new List<Order>();

			canvas.Width = OrderItemButton.WIDTH;
			canvas.Height = OrderItemButton.HEIGHT * 7;

			setHeader();

			mOrderItemButtonScrollViewer = new ScrollViewer();
			mOrderItemButtonScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
			mOrderItemButtonScrollViewer.Width = OrderItemButton.WIDTH;
			mOrderItemButtonScrollViewer.Height = OrderItemButton.HEIGHT * 7;
			Canvas.SetTop(mOrderItemButtonScrollViewer, 50);
			Canvas.SetLeft(mOrderItemButtonScrollViewer, 0);
			canvas.Children.Add(mOrderItemButtonScrollViewer);

			mOrderItemButtonStackPanel = new StackPanel();
			mOrderItemButtonStackPanel.Orientation = Orientation.Vertical;
			mOrderItemButtonStackPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
			Canvas.SetTop(mOrderItemButtonStackPanel, 0);
			Canvas.SetLeft(mOrderItemButtonStackPanel, 0);
			mOrderItemButtonScrollViewer.Content = mOrderItemButtonStackPanel;
		}

		private void setHeader()
		{
			mOrderHeader = new OrderHeader();
			canvas.Children.Add(mOrderHeader);
		}

		public void addOrderItem(ItemLayout item_layoutm)
		{
			bool is_already_added = false;

			foreach (Order order in mOrderList)
			{
				if (order.item.getItem().getId() == item_layoutm.getId())
				{
					order.item.increaseQuantity();
					is_already_added = true;
					order.button.refreshOrder(order.item);
					break;
				}
			}

			if (is_already_added == false)
			{
				OrderItem order_item = new OrderItem(item_layoutm.getItem());

				OrderItemButton order_item_button = new OrderItemButton(order_item);
				order_item_button.Width = OrderItemButton.WIDTH;
				order_item_button.Height = OrderItemButton.HEIGHT;
				order_item_button.ClickIncrease += increaseQuantity;
				order_item_button.ClickDecrease += decreaseQuantity;
				order_item_button.ClickDelete += deleteOrderItem;

				mOrderList.Add(new Order(order_item, order_item_button));

				mOrderItemButtonStackPanel.Children.Add(order_item_button);
				Debug.Write("Add : " + item_layoutm.getItem().getName());
			}

			onOrderChange();
		}

		private void increaseQuantity(Item item)
		{
			foreach (Order order in mOrderList)
			{
				if (order.item.getItem().getId() == item.getId())
				{
					order.item.increaseQuantity();
					order.button.refreshOrder(order.item);
					Debug.Write("Increase : " + order.item.getItem().getName() + "(" + order.item.getQuantity() + ")");
					break;
				}
			}

			onOrderChange();
		}

		private void decreaseQuantity(Item item)
		{
			foreach (Order order in mOrderList)
			{
				if (order.item.getItem().getId() == item.getId())
				{
					order.item.decreaseQuantity();
					order.button.refreshOrder(order.item);
					Debug.Write("Decrease : " + order.item.getItem().getName() + "(" + order.item.getQuantity() + ")");

					if (order.item.getQuantity() == 0)
					{
						mOrderItemButtonStackPanel.Children.Remove(order.button);
						mOrderList.Remove(order);

						Debug.Write("Remove : " + order.item.getItem().getName());
						break;
					}

					break;
				}
			}

			onOrderChange();
		}

		private void deleteOrderItem(Item item)
		{
			foreach (Order order in mOrderList)
			{
				if (order.item.getItem().getId() == item.getId())
				{
					mOrderItemButtonStackPanel.Children.Remove(order.button);
					mOrderList.Remove(order);

					Debug.Write("Delete : " + order.item.getItem().getName());
					break;
				}
			}

			onOrderChange();
		}

		public void deleteAllOrderItem()
		{
			for(;mOrderList.Count > 0;)
			{
				Order order = mOrderList[0];
				mOrderItemButtonStackPanel.Children.Remove(order.button);
				mOrderList.Remove(order);

				Debug.Write("Delete : " + order.item.getItem().getName());
			}

			onOrderChange();
		}

		public event OrderChangeEvent OrderChange;

		public void onOrderChange()
		{
			if(OrderChange != null)
			{
				uint sub_total_price = 0;
				uint discount_price = 0;
				uint total_price = 0;

				foreach (Order order in mOrderList)
				{
					sub_total_price += order.item.getSubTotalPrice();
					discount_price += order.item.getDiscountPrice();
					total_price += order.item.getTotalPrice();
				}

				OrderChange(sub_total_price, discount_price, total_price);
			}
		}

		public void setDiscount(OrderItem.DiscountType discount_type, uint value)
		{
			if(discount_type == OrderItem.DiscountType.Price)
			{
				setDiscountPrice(value);
			}
			else if(discount_type == OrderItem.DiscountType.Percent)
			{
				setDiscountPercent(value);
			}
			else if (discount_type == OrderItem.DiscountType.Enuri)
			{
				setEnuriPrice(value);
			}
		}

		public void setDiscountPrice(uint discount_price)
		{
			uint sub_total_price = 0;
			uint discounted_item_count = 0;

			foreach (Order order in mOrderList)
			{
				if (order.item.getItem().getDiscount() == true)
				{
					discounted_item_count++;
					sub_total_price += order.item.getSubTotalPrice();
				}
			}

			uint total_discount_price = 0;

			foreach (Order order in mOrderList)
			{
				OrderItem order_item = order.item;

				if (order.item.getItem().getDiscount() == true)
				{
					discounted_item_count--;
					if (discounted_item_count != 0)
					{
						uint sub_discount_price = (uint)(order_item.getSubTotalPrice() * (((uint)((float)discount_price / sub_total_price * 100)) / (float)100.0));
						order_item.setDiscountPrice(sub_discount_price);
						total_discount_price = total_discount_price + sub_discount_price;
					}
					else
					{
						order_item.setDiscountPrice(discount_price - total_discount_price);
					}

					order.button.refreshOrder(order_item);
				}
			}

			onOrderChange();
		}

		public void setDiscountPercent(uint discount_percent)
		{
			for (int i = 0; i < mOrderList.Count; i++)
			{
				OrderItem order_item = mOrderList[i].item;

				if (order_item.getItem().getDiscount() == true)
				{
					uint discount_price = (uint)(((double)order_item.getSubTotalPrice()) * (discount_percent / 100.0));
					order_item.setDiscountPrice(discount_price);
					mOrderList[i].button.refreshOrder(order_item);
				}
			}

			onOrderChange();
		}

		public void setEnuriPrice(uint enuri_price)
		{
			uint sub_total_price = 0;

			foreach (Order order in mOrderList)
			{
				sub_total_price += order.item.getSubTotalPrice();
			}

			uint total_enuri_price = 0;

			for(int i = 0; i < mOrderList.Count; i++)
			{
				Order order = mOrderList[i];

				if (i < mOrderList.Count - 1)
				{
					uint sub_enuri_price = (uint)(order.item.getSubTotalPrice() * (((uint)((float)enuri_price / sub_total_price * 100)) / (float)100.0));
					order.item.setEnuriPrice(sub_enuri_price);
					total_enuri_price = total_enuri_price + sub_enuri_price;
				}
				else
				{
					order.item.setEnuriPrice(enuri_price - total_enuri_price);
				}

				order.button.refreshOrder(order.item);
			}

			onOrderChange();
		}
	}
}
