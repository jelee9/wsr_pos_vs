using System;
using System.Collections.Generic;
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
			/*
			OrderItemButton btn = new OrderItemButton();
			stack_panel.Children.Add(btn);

			OrderItemButton btn1 = new OrderItemButton();
			stack_panel.Children.Add(btn1);

			OrderItemButton btn2 = new OrderItemButton();
			stack_panel.Children.Add(btn2);

			
			OrderItemButton btn3 = new OrderItemButton();
			stack_panel.Children.Add(btn3);

			OrderItemButton btn4 = new OrderItemButton();
			stack_panel.Children.Add(btn4);

			OrderItemButton btn5 = new OrderItemButton();
			stack_panel.Children.Add(btn5);

			OrderItemButton btn6 = new OrderItemButton();
			stack_panel.Children.Add(btn6);

			OrderItemButton btn7 = new OrderItemButton();
			stack_panel.Children.Add(btn7);
			*/
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

				OrderItemButton order_item_button = new OrderItemButton(order_item);
				order_item_button.Width = OrderItemButton.WIDTH;
				order_item_button.Height = OrderItemButton.HEIGHT;
				mOrderItemButtonList.Add(order_item_button);

				mOrderButtonSTackPanel.HorizontalAlignment = HorizontalAlignment.Left;
				mOrderButtonSTackPanel.Children.Add(order_item_button);
			}
		}

		private void increateQuantity(Item item)
		{
			foreach (OrderItem order_item in mOrderItemList)
			{
				if (order_item.getItem().getId() == item.getId())
				{
					order_item.increaseQuantity();
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
