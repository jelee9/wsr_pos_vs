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

namespace wsr_pos.Order
{
	/// <summary>
	/// Interaction logic for ItemCanvas.xaml
	/// </summary>
	public partial class MenuItemCanvas : UserControl
	{
		List<Item> mItemList;

		public MenuItemCanvas(List<Item> item_list = null)
		{
			InitializeComponent();

			if(item_list != null)
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
			Item item1 = new Item(0, 0, "수상스키",			"",							25000, false, false, false, 0, 0, MetrialColor.Name.Green);
			Item item2 = new Item(0, 0, "수상스키(초보)",	"",							60000, false, false, false, 1, 0, MetrialColor.Name.Green);
			Item item3 = new Item(0, 0, "웨이크보드",		"",							25000, false, false, false, 0, 1, MetrialColor.Name.Green);
			Item item4 = new Item(0, 0, "웨이크보드(초보)", "",							60000, false, false, false, 1, 1, MetrialColor.Name.Green);

			Item item5 = new Item(0, 0, "바나나보트",		"",							20000, false, false, false, 2, 0, MetrialColor.Name.Blue);
			Item item6 = new Item(0, 0, "더블땅콩",			"",							25000, false, false, false, 3, 0, MetrialColor.Name.Blue);
			Item item7 = new Item(0, 0, "디스코팡팡",		"",							25000, false, false, false, 4, 0, MetrialColor.Name.Blue);
			Item item8 = new Item(0, 0, "헥사곤",			"",							25000, false, false, false, 2, 1, MetrialColor.Name.Blue);
			Item item9 = new Item(0, 0, "마블",				"",							25000, false, false, false, 3, 1, MetrialColor.Name.Blue);
			Item item10 = new Item(0, 0, "날으는 바나나",	"",							25000, false, false, false, 4, 1, MetrialColor.Name.Blue);
			Item item11 = new Item(0, 0, "밴드 웨곤",		"",							20000, false, false, false, 2, 2, MetrialColor.Name.Blue);

			Item item12 = new Item(0, 0, "보팅 (A)",		"",							50000, false, false, false, 5, 0, MetrialColor.Name.DeepOrange);
			Item item13 = new Item(0, 0, "보팅 (B)",		"",							100000, false, false, false, 6, 0, MetrialColor.Name.DeepOrange);
			Item item14 = new Item(0, 0, "보팅 (C)",		"",							150000, false, false, false, 7, 0, MetrialColor.Name.DeepOrange);
			Item item15 = new Item(0, 0, "패키지 (A)",		"수상스키2회 + 물놀이",		28000, false, false, false, 5, 1, MetrialColor.Name.DeepOrange);
			Item item16 = new Item(0, 0, "패키지 (B)",		"수상스키2회 + 물놀이 2종", 30000, false, false, false, 6, 1, MetrialColor.Name.DeepOrange);
			Item item17 = new Item(0, 0, "패키지 (C)",		"",							45500, false, false, false, 7, 1, MetrialColor.Name.DeepOrange);
			Item item18 = new Item(0, 0, "패키지 (D)",		"",							59500, false, false, false, 5, 2, MetrialColor.Name.DeepOrange);

			mItemList = new List<Item>();

			mItemList.Add(item1);
			mItemList.Add(item2);
			mItemList.Add(item3);
			mItemList.Add(item4);
			mItemList.Add(item5);
			mItemList.Add(item6);
			mItemList.Add(item7);
			mItemList.Add(item8);
			mItemList.Add(item9);
			mItemList.Add(item10);
			mItemList.Add(item11);
			mItemList.Add(item12);
			mItemList.Add(item13);
			mItemList.Add(item14);
			mItemList.Add(item15);
			mItemList.Add(item16);
			mItemList.Add(item17);
			mItemList.Add(item18);
		}
	}
}