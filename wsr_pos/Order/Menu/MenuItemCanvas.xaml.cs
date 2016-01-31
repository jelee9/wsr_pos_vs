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

namespace wsr_pos
{
	public struct Menu
	{
		public MenuItem item;
		public MenuItemButton button;

		public Menu(MenuItem item, MenuItemButton button)
		{
			this.item = item;
			this.button = button;
		}
	}

	/// <summary>
	/// Interaction logic for ItemCanvas.xaml
	/// </summary>
	public partial class MenuItemCanvas : UserControl
	{
		List<Item> mItemList;
		MenuItemButtonClickEvent mMenuItemBUttonClickEvent;

		public MenuItemCanvas(List<Item> item_list = null, MenuItemButtonClickEvent menu_item_button_click_event = null)
		{
			InitializeComponent();

			mMenuItemBUttonClickEvent = menu_item_button_click_event;

			if (item_list != null)
			{
				mItemList = item_list;
			}
			else
			{
				setTestData();
			}

			Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 2);

			foreach(Item item in mItemList)
			{
				MenuItemButton item_button = new MenuItemButton(item);
				item_button.Click += mMenuItemBUttonClickEvent;
				canvas.Children.Add(item_button);
			}
		}

		public void setPosition(int x, int y, int w, int h)
		{
			Canvas.SetLeft(this, x);
			Canvas.SetTop(this, y);
			Width = w;
			Height = h;
		}

		private void setTestData()
		{
			Item item01 = new Item(0,	01, "수상스키",			"",								25000, false, false, false, 0, 0, MetrialColor.Name.Green);
			Item item02 = new Item(0,	02, "수상스키(초보)",	"",								60000, false, false, false, 1, 0, MetrialColor.Name.Green);
			Item item03 = new Item(0,	03, "웨이크보드",		"",								25000, false, false, false, 0, 1, MetrialColor.Name.Green);
			Item item04 = new Item(0,	04, "웨이크보드(초보)",	"",								60000, false, false, false, 1, 1, MetrialColor.Name.Green);

			Item item05 = new Item(1,	05, "바나나보트",		"",								20000, false, false, false, 2, 0, MetrialColor.Name.Blue);
			Item item06 = new Item(1,	06, "더블땅콩",			"",								25000, false, false, false, 3, 0, MetrialColor.Name.Blue);
			Item item07 = new Item(1,	07, "디스코팡팡",		"",								25000, false, false, false, 4, 0, MetrialColor.Name.Blue);
			Item item08 = new Item(1,	08, "헥사곤",			"",								25000, false, false, false, 2, 1, MetrialColor.Name.Blue);
			Item item09 = new Item(1,	09, "마블",				"",								25000, false, false, false, 3, 1, MetrialColor.Name.Blue);
			Item item10 = new Item(1,	10, "날으는 바나나",	"",								25000, false, false, false, 4, 1, MetrialColor.Name.Blue);
			Item item11 = new Item(1,	11, "밴드 웨곤",		"",								20000, false, false, false, 2, 2, MetrialColor.Name.Blue);

			Item item12 = new Item(1,	12, "보팅 (A)",			"",								50000, false, false, false, 5, 0, MetrialColor.Name.DeepOrange);
			Item item13 = new Item(1,	13, "보팅 (B)",			"",								100000, false, false, false, 6, 0, MetrialColor.Name.DeepOrange);
			Item item14 = new Item(1,	14, "보팅 (C)",			"",								150000, false, false, false, 7, 0, MetrialColor.Name.DeepOrange);
			Item item15 = new Item(2,	15, "물놀이 패키지 1",	"마블/바나나/밴드웨곤 2종",		28000, false, false, false, 5, 1, MetrialColor.Name.DeepOrange);
			Item item16 = new Item(2,	16, "물놀이 패키지 2",	"물놀이 2종",					30000, false, false, false, 6, 1, MetrialColor.Name.DeepOrange);
			Item item17 = new Item(2,	17, "물놀이 패키지 3",	"물놀이 3종",					45500, false, false, false, 7, 1, MetrialColor.Name.DeepOrange);
			Item item18 = new Item(2,	18, "물놀이 패키지 4",	"물놀이 4종",					59500, false, false, false, 5, 2, MetrialColor.Name.DeepOrange);
			Item item19 = new Item(2,	19, "수상 패키지 1",	"수상스키 2회 + 물놀이",		61000, false, false, false, 6, 2, MetrialColor.Name.DeepOrange);
			Item item20 = new Item(2,	20, "수상 패키지 2",	"수상스키 2회 + 물놀이 2종",	73500, false, false, false, 7, 2, MetrialColor.Name.DeepOrange);

			mItemList = new List<Item>();

			mItemList.Add(item01);
			mItemList.Add(item02);
			mItemList.Add(item03);
			mItemList.Add(item04);
			mItemList.Add(item05);
			mItemList.Add(item06);
			mItemList.Add(item07);
			mItemList.Add(item08);
			mItemList.Add(item09);
			mItemList.Add(item10);
			mItemList.Add(item11);
			mItemList.Add(item12);
			mItemList.Add(item13);
			mItemList.Add(item14);
			mItemList.Add(item15);
			mItemList.Add(item16);
			mItemList.Add(item17);
			mItemList.Add(item18);
			mItemList.Add(item19);
			mItemList.Add(item20);
		}
	}
}