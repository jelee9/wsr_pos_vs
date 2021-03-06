﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		public static readonly uint WIDTH = 1280;
		public static readonly uint HEIGHT = 1024;

		public enum MODE
		{
			ORDER,
			SAVED,
			SETTINGS,
		};

		private Canvas mTitleBar;
		private MenuCanvas mMenuCanvas;
		private OrderMain mOrderMain;
		private wsr_pos.Setting.Item.SettingItemCanvas mSettingItemCanvas;

		private MODE mMode;

		public MainWindow()
        {
            InitializeComponent();

			setWindow();

			mMode = MODE.ORDER;

			setTitle();
			setMode();
			//Discount d = new Discount();
			//d.ShowDialog();

			Item item01 = new Item(0, 01, "수상스키", "", 25000, false, false, false, false);

			//DBManager dbm = DBManager.getInstance();
			//dbm.addItem(item01);
			/*
			DateTime dt = DateTime.Now;
			long ab = dt.Ticks;
			string a = string.Format("{0:yyyy/MM/dd-HH:mm:ss}", dt);
			Debug.Print(a);
			*/

			mMenuCanvas = new MenuCanvas(0, 50, 300, 1024 - 50);
			canvas.Children.Add(mMenuCanvas);
			mMenuCanvas.Visibility = Visibility.Hidden;
		}

		private void setWindow()
		{
			Top = 0;
			Left = 0;
			Width = WIDTH;
			Height = HEIGHT;

			WindowStyle = WindowStyle.None;
			ResizeMode = ResizeMode.NoResize;
		}

		private void setTitle()
		{
			mTitleBar = new Canvas();
			Canvas.SetTop(mTitleBar, 0);
			Canvas.SetLeft(mTitleBar, 0);
			mTitleBar.Width = 1280;
			mTitleBar.Height = 50;

			mTitleBar.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 7);

			Label title_text = new Label();
			Canvas.SetTop(title_text, 0);
			Canvas.SetLeft(title_text, 440);
			title_text.Width = 400;
			title_text.Height = 50;
			title_text.HorizontalAlignment = HorizontalAlignment.Center;
			title_text.HorizontalContentAlignment = HorizontalAlignment.Center;
			title_text.VerticalContentAlignment = VerticalAlignment.Center;
			title_text.FontSize = 25;
			title_text.Content = "쎄시봉 수상스키장";
			title_text.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mTitleBar.Children.Add(title_text);

			RectButton rb = new RectButton(36, 36);
			rb.setBackgroundImage("menu_white_36x36.png", "menu_white_27x27.png");
			Canvas.SetLeft(rb, 10);
			Canvas.SetTop(rb, 7);

			rb.Click += showMenu;


			mTitleBar.Children.Add(rb);

			canvas.Children.Add(mTitleBar);
		}

		private void setMode()
		{
			setOrder();
			//setSettingItem();
		}

		private void setOrder()
		{
			mOrderMain = new OrderMain();
			Canvas.SetLeft(mOrderMain, 0);
			Canvas.SetTop(mOrderMain, 50);

			canvas.Children.Add(mOrderMain);
		}

		private void setSettingItem()
		{
			mSettingItemCanvas = new wsr_pos.Setting.Item.SettingItemCanvas();
			Canvas.SetLeft(mSettingItemCanvas, 0);
			Canvas.SetTop(mSettingItemCanvas, 50);

			canvas.Children.Add(mSettingItemCanvas);
		}

		private void showMenu()
		{
			if (mMenuCanvas.Visibility == Visibility.Hidden)
			{
				mMenuCanvas.Visibility = Visibility.Visible;
			}
			else
			{
				mMenuCanvas.Visibility = Visibility.Hidden;
			}
		}
    }
}
