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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

			Item item = new Item(0, 0, "이종은", "동해물과 백두산이 마르고 닳도록", 700000, false, false, false, 0, 0, MetrialColor.Name.Brown);
			ItemButton item_button = new ItemButton(item);

			item_button.setPosition(100, 100, 150, 80);

			canvas.Children.Add(item_button);

			item_button.Click += button_click;
        }

		private void button_click(object sender, RoutedEventArgs e)
		{
			Item item = new Item(0, 0, "신선주", "", 1234567890, false, false, false, 0, 0, MetrialColor.Name.DeepOrange);
			ItemButton item_button = new ItemButton(item);
			item_button.setPosition(100, 300, 150, 80);
			canvas.Children.Add(item_button);
		}
    }
}
