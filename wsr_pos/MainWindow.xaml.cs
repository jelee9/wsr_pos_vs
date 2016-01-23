﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();

			Item item = new Item(0, 0, "이종은", "동해물과 백두산이 마르고 닳도록", 700000, false, false, false, 0, 0, MetrialColor.Name.Brown);
			MenuItemButton item_button = new MenuItemButton(item);

			//item_button.setPosition(100, 100, 150, 80);

			canvas.Children.Add(item_button);

			item_button.Click += button_click;

			MenuItemCanvas item_canvas = new MenuItemCanvas();
			item_canvas.setPosition(0, 400, 1280, 400);
			canvas.Children.Add(item_canvas);


			OrderItemButton btn = new OrderItemButton();
			Canvas.SetTop(btn, 100);
			Canvas.SetLeft(btn, 100);
			canvas.Children.Add(btn);

			CircleButton btn1 = new CircleButton();
			Canvas.SetTop(btn1, 170);
			Canvas.SetLeft(btn1, 100);
			canvas.Children.Add(btn1);

			CircleButton btn2 = new CircleButton();
			Canvas.SetTop(btn2, 240);
			Canvas.SetLeft(btn2, 100);
			canvas.Children.Add(btn2);

			CircleButton btn3 = new CircleButton();
			Canvas.SetTop(btn3, 310);
			Canvas.SetLeft(btn3, 100);
			canvas.Children.Add(btn3);
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
