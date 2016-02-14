using System.Collections.Generic;
using System.Windows.Controls;

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
		List<ItemLayout> mItemLayoutList;
		MenuItemButtonClickEvent mMenuItemBUttonClickEvent;

		public MenuItemCanvas(List<ItemLayout> item_layout_list = null, MenuItemButtonClickEvent menu_item_button_click_event = null)
		{
			InitializeComponent();

			mMenuItemBUttonClickEvent = menu_item_button_click_event;

			if (item_layout_list != null)
			{
				mItemLayoutList = item_layout_list;
			}
			else
			{
				mItemLayoutList = DBManager.getInstance().getItemLayoutList();
			}

			Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 2);

			foreach(ItemLayout item_layout in mItemLayoutList)
			{
				MenuItemButton item_button = new MenuItemButton(item_layout);
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
			Item item01 = new Item(0,	01, "수상스키", "",														25000, false, false, false, false);
			Item item02 = new Item(0,	02, "수상스키(초보)",		"",												60000, false, false, false, false);
			Item item03 = new Item(0,	03, "웨이크보드",			"",												25000, false, false, false, false);
			Item item04 = new Item(0,	04, "웨이크보드(초보)",	"",												60000, false, false, false, false);

			Item item05 = new Item(1,	05, "바나나보트",			"",												20000, false, false, false, false);
			Item item06 = new Item(1,	06, "밴드 웨곤",			"",												20000, false, false, false, false);
			Item item07 = new Item(1,	07, "더블땅콩",			"",												25000, false, false, false, false);
			Item item08 = new Item(1,	08, "디스코팡팡",			"",												25000, false, false, false, false);
			Item item09 = new Item(1,	09, "뉴 디스코팡팡",		"",												25000, false, false, false, false);
			Item item10 = new Item(1,	10, "헥사곤",				"",												25000, false, false, false, false);
			Item item11 = new Item(1,	11, "마블",				"",												25000, false, false, false, false);
			Item item12 = new Item(1,	12, "날으는 바나나",		"",												25000, false, false, false, false);

			Item item13 = new Item(1,	13, "보팅 (A)",			"바나나보트/밴드 웨곤/뉴 디스코팡팡/날으는 바나나",		50000, false, false, false, false);
			Item item14 = new Item(1,	14, "보팅 (B)",			"",												100000, false, false, false, false);
			Item item15 = new Item(1,	15, "보팅 (C)",			"수상스키(초보)/날으는 바나나/날으는 바나나",			150000, false, false, false, false);


			Item item16 = new Item(2,	16, "물놀이 패키지 1",		"마블/바나나/밴드웨곤 2종",							28000, false, false, false, false);
			Item item17 = new Item(2,	17, "물놀이 패키지 2",		"물놀이 2종",										30000, false, false, false, false);
			Item item18 = new Item(2,	18, "물놀이 패키지 3",		"물놀이 3종",										45500, false, false, false, false);
			Item item19 = new Item(2,	19, "물놀이 패키지 4",		"물놀이 4종",										59500, false, false, false, false);
			Item item20 = new Item(2,	20, "수상 패키지 1",		"수상스키 2회 + 물놀이",							61000, false, false, false, false);
			Item item21 = new Item(2,	21, "수상 패키지 2",		"수상스키 2회 + 물놀이 2종",						73500, false, false, false, false);

			/*
			mItemLayoutList = new List<Item>();

			mItemLayoutList.Add(item01);
			mItemLayoutList.Add(item02);
			mItemLayoutList.Add(item03);
			mItemLayoutList.Add(item04);
			mItemLayoutList.Add(item05);
			mItemLayoutList.Add(item06);
			mItemLayoutList.Add(item07);
			mItemLayoutList.Add(item08);
			mItemLayoutList.Add(item09);
			mItemLayoutList.Add(item10);
			mItemLayoutList.Add(item11);
			mItemLayoutList.Add(item12);
			mItemLayoutList.Add(item13);
			mItemLayoutList.Add(item14);
			mItemLayoutList.Add(item15);
			mItemLayoutList.Add(item16);
			mItemLayoutList.Add(item17);
			mItemLayoutList.Add(item18);
			mItemLayoutList.Add(item19);
			mItemLayoutList.Add(item20);
			mItemLayoutList.Add(item21);
			*/
		}
	}
}