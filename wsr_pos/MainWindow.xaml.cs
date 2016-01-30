using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using wsr_pos.Order;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		private List<OrderItem> mOrderItemList;
		private List<OrderItemButton> mOrderItemButtonList;
		private ScrollViewer mOrderScrollViewer;
		private StackPanel mOrderButtonSTackPanel;

		public MainWindow()
        {
            InitializeComponent();

			mOrderItemList = new List<OrderItem>();
			mOrderItemButtonList = new List<OrderItemButton>();

			setOrderListView();

			Item item = new Item(0, 0, "이종은", "동해물과 백두산이 마르고 닳도록", 700000, false, false, false, 0, 0, MetrialColor.Name.Brown);
			MenuItemButton item_button = new MenuItemButton(item);
			canvas.Children.Add(item_button);

			MenuItemCanvas item_canvas = new MenuItemCanvas(null, addOrderItem);
			item_canvas.setPosition(0, 400, 1280, 400);
			canvas.Children.Add(item_canvas);
		}

		private void setOrderListView()
		{
			mOrderScrollViewer = new ScrollViewer();
			mOrderScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
			mOrderScrollViewer.Width = OrderItemButton.WIDTH_WITH_SCROLL;
			mOrderScrollViewer.Height = 300;
			Canvas.SetTop(mOrderScrollViewer, 100);
			Canvas.SetLeft(mOrderScrollViewer, 0);
			canvas.Children.Add(mOrderScrollViewer);

			mOrderButtonSTackPanel = new StackPanel();
			mOrderButtonSTackPanel.Orientation = Orientation.Vertical;
			Canvas.SetTop(mOrderButtonSTackPanel, 0);
			Canvas.SetLeft(mOrderButtonSTackPanel, 0);
			mOrderScrollViewer.Content = mOrderButtonSTackPanel;
		}

		private void addOrderItem(Item item)
		{
			bool is_already_added = false;

			foreach(OrderItem order_item in mOrderItemList)
			{
				if(order_item.getItem().getId() == item.getId())
				{
					order_item.increaseQuantity();
					is_already_added = true;

					foreach (OrderItemButton order_item_button in mOrderItemButtonList)
					{
						if (order_item_button.getItem().getId() == order_item.getItem().getId())
						{
							order_item_button.refreshOrder(order_item);
							break;
						}
					}
					break;
				}
			}

			if(is_already_added == false)
			{
				OrderItem order_item = new OrderItem(item);
				mOrderItemList.Add(order_item);

				OrderItemButton order_item_button = new OrderItemButton(order_item, increaseQuantity, decreaseQuantity);
				order_item_button.Width = OrderItemButton.WIDTH;
				order_item_button.Height = OrderItemButton.HEIGHT;
				mOrderItemButtonList.Add(order_item_button);

				mOrderButtonSTackPanel.HorizontalAlignment = HorizontalAlignment.Left;
				mOrderButtonSTackPanel.Children.Add(order_item_button);
			}
		}

		private void increaseQuantity(Item item)
		{
			foreach (OrderItem order_item in mOrderItemList)
			{
				if (order_item.getItem().getId() == item.getId())
				{
					order_item.increaseQuantity();
					Debug.Write("Increase : " + order_item.getQuantity());
					break;
				}
			}

			foreach (OrderItemButton order_item_button in mOrderItemButtonList)
			{
				foreach (OrderItem order_item in mOrderItemList)
				{
					if (order_item_button.getItem().getId() == order_item.getItem().getId())
					{
						order_item_button.refreshOrder(order_item);
						break;
					}
				}
			}
		}

		private void decreaseQuantity(Item item)
		{
			foreach (OrderItem order_item in mOrderItemList)
			{
				if (order_item.getItem().getId() == item.getId())
				{
					order_item.decreaseQuantity();
					Debug.Write("Decrease : " + order_item.getQuantity());
					break;
				}
			}

			foreach (OrderItemButton order_item_button in mOrderItemButtonList)
			{
				foreach (OrderItem order_item in mOrderItemList)
				{
					if (order_item_button.getItem().getId() == order_item.getItem().getId())
					{
						order_item_button.refreshOrder(order_item);
						if(order_item.getQuantity() == 0)
						{
							mOrderButtonSTackPanel.Children.Remove(order_item_button);
							mOrderItemButtonList.Remove(order_item_button);
							mOrderItemList.Remove(order_item);

							Debug.Write("Button is removing : " + order_item.getItem().getName());
							return;
						}
					}
				}
			}

		}

		private void button_click(object sender, RoutedEventArgs e, Item item)
		{
			for (int i = 0; i < 10000; i++)
			{
				Item item2 = new Item(0, 0, "신선주", "", 1234567890, false, false, false, 0, 0, MetrialColor.Name.DeepOrange);
				MenuItemButton item_button = new MenuItemButton(item2);
				//item_button.setPosition(100, 300, 150, 80);
				canvas.Children.Add(item_button);

				if(i % 100 == 0)
				{
					Content = null;
				}
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
		}
    }
}
