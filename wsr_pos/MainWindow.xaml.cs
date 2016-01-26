using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using wsr_pos.Order;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		private List<OrderItem> mOrderItemList;
		private ScrollViewer mOrderScrollViewer;
		private StackPanel mORderButtonSTackPanel;

		public MainWindow()
        {
            InitializeComponent();

			mOrderItemList = new List<OrderItem>();
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
			mOrderScrollViewer.Width = 800;
			mOrderScrollViewer.Height = 400;
			Canvas.SetTop(mOrderScrollViewer, 50);
			Canvas.SetLeft(mOrderScrollViewer, 0);
			canvas.Children.Add(mOrderScrollViewer);

			mORderButtonSTackPanel = new StackPanel();
			mOrderScrollViewer.Content = mORderButtonSTackPanel;
		}

		private void addOrderItem(Item item)
		{
			bool is_already_added = false;

			foreach(OrderItem order_item in mOrderItemList)
			{
				if(order_item.getItem().getId() == item.getId())
				{
					order_item.increaseItem();
					is_already_added = true;
					break;
				}
			}

			if(is_already_added == false)
			{
				OrderItem order_item = new OrderItem(item);
				mOrderItemList.Add(order_item);

				OrderItemButton btn = new OrderItemButton(order_item);
				btn.Width = 800;
				btn.Height = 50;
				mORderButtonSTackPanel.Children.Add(btn);
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
