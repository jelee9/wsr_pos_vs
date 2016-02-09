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
		ScrollViewer mOrderItemButtonScrollViewer;
		StackPanel mOrderItemButtonStackPanel;

		public OrderItemCanvas()
		{
			InitializeComponent();

			mOrderList = new List<Order>();

			canvas.Width = OrderItemButton.WIDTH;
			canvas.Height = OrderItemButton.HEIGHT * 5;

			setHeaderBar();

			mOrderItemButtonScrollViewer = new ScrollViewer();
			mOrderItemButtonScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
			mOrderItemButtonScrollViewer.Width = OrderItemButton.WIDTH;
			mOrderItemButtonScrollViewer.Height = OrderItemButton.HEIGHT * 5;
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
		private void setPosition(FrameworkElement element, uint x, uint y, uint w, uint h)
		{
			Canvas.SetLeft(element, x);
			Canvas.SetTop(element, y);
			element.Width = w;
			element.Height = h;

			if (element.GetType() == typeof(Label))
			{
				((Label)element).Padding = new Thickness(0, 0, 0, 0);
			}
		}

		private void setHeaderBar()
		{
			Canvas header_canvas;
			Label name;
			Label quantity;
			Label sub_total_price;
			Label discount;
			Label total_price;

			uint CANVAS_HEIGHT = 50;
			uint LABEL_H = 30;
			uint LABEL_Y = ((CANVAS_HEIGHT - LABEL_H) / 2);

			header_canvas = new Canvas();
			header_canvas.Height = 50;
			header_canvas.Width = canvas.Width;
			Canvas.SetTop(header_canvas, 0);
			Canvas.SetLeft(header_canvas, 0);
			canvas.Children.Add(header_canvas);

			name = new Label();
			setPosition(name, OrderItemButton.NAME_X, LABEL_Y, OrderItemButton.NAME_W, LABEL_H);
			name.FontSize = 16;
			name.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			name.Content = "이름";
			name.VerticalContentAlignment = VerticalAlignment.Center;
			name.HorizontalContentAlignment = HorizontalAlignment.Left;
			header_canvas.Children.Add(name);

			quantity = new Label();
			setPosition(quantity, OrderItemButton.QUANTITY_X, LABEL_Y, OrderItemButton.QUANTITY_W, LABEL_H);
			quantity.FontSize = 16;
			quantity.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			quantity.Content = "수량";
			quantity.VerticalContentAlignment = VerticalAlignment.Center;
			quantity.HorizontalContentAlignment = HorizontalAlignment.Center;
			header_canvas.Children.Add(quantity);

			sub_total_price = new Label();
			setPosition(sub_total_price, OrderItemButton.SUBTOTAL_PRICE_X, LABEL_Y, OrderItemButton.SUBTOTAL_PRICE_W, LABEL_H);
			sub_total_price.FontSize = 16;
			sub_total_price.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			sub_total_price.Content = "합계";
			sub_total_price.VerticalContentAlignment = VerticalAlignment.Center;
			sub_total_price.HorizontalContentAlignment = HorizontalAlignment.Right;
			header_canvas.Children.Add(sub_total_price);

			discount = new Label();
			setPosition(discount, OrderItemButton.DISCOUNT_PRICE_X, LABEL_Y, OrderItemButton.DISCOUNT_PRICE_W, LABEL_H);
			discount.FontSize = 16;
			discount.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			discount.Content = "할인";
			discount.VerticalContentAlignment = VerticalAlignment.Center;
			discount.HorizontalContentAlignment = HorizontalAlignment.Right;
			header_canvas.Children.Add(discount);

			total_price = new Label();
			setPosition(total_price, OrderItemButton.TOTAL_PRICE_X, LABEL_Y, OrderItemButton.TOTAL_PRICE_W, LABEL_H);
			total_price.FontSize = 16;
			total_price.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			total_price.Content = "총계";
			total_price.VerticalContentAlignment = VerticalAlignment.Center;
			total_price.HorizontalContentAlignment = HorizontalAlignment.Right;
			header_canvas.Children.Add(total_price);
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

				OrderItemButton order_item_button = new OrderItemButton(order_item);
				order_item_button.Width = OrderItemButton.WIDTH;
				order_item_button.Height = OrderItemButton.HEIGHT;
				order_item_button.ClickIncrease += increaseQuantity;
				order_item_button.ClickDecrease += decreaseQuantity;

				mOrderList.Add(new Order(order_item, order_item_button));

				mOrderItemButtonStackPanel.Children.Add(order_item_button);
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
					Debug.Write("Increase : " + order.item.getQuantity());
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
					Debug.Write("Decrease : " + order.item.getQuantity());

					if (order.item.getQuantity() == 0)
					{
						mOrderItemButtonStackPanel.Children.Remove(order.button);
						mOrderList.Remove(order);

						Debug.Write("Button is removing : " + order.item.getItem().getName());
						break;
					}

					break;
				}
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
	}
}
