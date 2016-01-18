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

			ItemButton item_button = new ItemButton("이름", "하하하하하하하", 1000);

			item_button.setPosition(100, 100, 150, 80);

			canvas.Children.Add(item_button);

			item_button.Click += button_click;
        }

		private void button_click(object sender, RoutedEventArgs e)
		{
			ItemButton item_button = new ItemButton("이종은", "", 1000);
			item_button.setPosition(100, 300, 150, 80);
			canvas.Children.Add(item_button);
		}
    }
}
