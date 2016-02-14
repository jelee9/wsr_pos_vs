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

namespace wsr_pos.Setting.ItemManage
{
	/// <summary>
	/// Interaction logic for SettingItemButton.xaml
	/// </summary>
	public partial class SettingItemButton : UserControl
	{
		private Item mItem;
		public SettingItemButton(Item item)
		{
			InitializeComponent();
		}

		private void setLayout()
		{

		}
	}
}
