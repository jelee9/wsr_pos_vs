using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wsr_pos.Setting.Item
{
	/// <summary>
	/// Interaction logic for SettingItemCanvas.xaml
	/// </summary>
	public partial class SettingItemCanvas : UserControl
	{
		public struct Item
		{
			public wsr_pos.Item item;
			public SettingItemButton button;

			public Item(wsr_pos.Item item, SettingItemButton button)
			{
				this.item = item;
				this.button = button;
			}
		}

		List<Item> mItemrList;
		SettingItemHeader mSettingItemHeader;
		ScrollViewer mSettingItemButtonScrollViewer;
		StackPanel mSettingItemButtonStackPanel;

		public SettingItemCanvas()
		{
			InitializeComponent();

			mItemrList = new List<Item>();

			canvas.Width = SettingItemButton.WIDTH;
			canvas.Height = SettingItemButton.HEIGHT * 7;
			canvas.Background = MetrialColor.getBrush(MetrialColor.Name.LightBlue, 0);
			setHeader();

			mSettingItemButtonScrollViewer = new ScrollViewer();
			mSettingItemButtonScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
			mSettingItemButtonScrollViewer.Width = SettingItemButton.WIDTH;
			mSettingItemButtonScrollViewer.Height = SettingItemButton.HEIGHT * 14;
			Canvas.SetTop(mSettingItemButtonScrollViewer, 100);
			Canvas.SetLeft(mSettingItemButtonScrollViewer, 50);
			canvas.Children.Add(mSettingItemButtonScrollViewer);

			mSettingItemButtonStackPanel = new StackPanel();
			mSettingItemButtonStackPanel.Orientation = Orientation.Vertical;
			mSettingItemButtonStackPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
			Canvas.SetTop(mSettingItemButtonStackPanel, 0);
			Canvas.SetLeft(mSettingItemButtonStackPanel, 0);
			mSettingItemButtonScrollViewer.Content = mSettingItemButtonStackPanel;
			mSettingItemButtonStackPanel.Background = MetrialColor.getBrush(MetrialColor.Name.LightBlue, 0);

			updateSettingItemButton();
		}

		private void setHeader()
		{
			mSettingItemHeader = new SettingItemHeader();
			Canvas.SetLeft(mSettingItemHeader, 50);
			Canvas.SetTop(mSettingItemHeader, 50);
			canvas.Children.Add(mSettingItemHeader);
		}

		private void updateSettingItemButton()
		{
			List<wsr_pos.Item> item_list = DBManager.getInstance().getItemList();

			foreach (wsr_pos.Item item in item_list)
			{
				SettingItemButton setting_item_button = new SettingItemButton(item);
				setting_item_button.Width = SettingItemButton.WIDTH;
				setting_item_button.Height = SettingItemButton.HEIGHT;
				setting_item_button.setBackgroundColor(MetrialColor.Name.White);

				mItemrList.Add(new Item(item, setting_item_button));

				mSettingItemButtonStackPanel.Children.Add(setting_item_button);




				


			}
		}
	}
}
