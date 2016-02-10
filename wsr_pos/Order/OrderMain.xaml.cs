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
	/// Interaction logic for OrderMain.xaml
	/// </summary>
	public partial class OrderMain : UserControl
	{
		private OrderItemCanvas mOrderItemCanvas;
		private TotalCanvas mTotalCanvas;
		private MenuItemCanvas mMenuItemCanvas;

		public OrderMain()
		{
			InitializeComponent();

			canvas.Width = 1280;
			canvas.Height = 750;

			setOrderItemCanvse();
			setTotalCanvas();
			setMenuItemCanvas();
		}

		private void setOrderItemCanvse()
		{
			mOrderItemCanvas = new OrderItemCanvas();
			Canvas.SetTop(mOrderItemCanvas, 0);
			Canvas.SetLeft(mOrderItemCanvas, 0);
			canvas.Children.Add(mOrderItemCanvas);
		}

		private void setTotalCanvas()
		{
			mTotalCanvas = new TotalCanvas();
			Canvas.SetTop(mTotalCanvas, 0);
			Canvas.SetLeft(mTotalCanvas, 900);
			canvas.Children.Add(mTotalCanvas);

			mOrderItemCanvas.OrderChange += mTotalCanvas.setPrice;
		}

		private void setMenuItemCanvas()
		{
			mMenuItemCanvas = new MenuItemCanvas(null, mOrderItemCanvas.addOrderItem);
			mMenuItemCanvas.setPosition(0, 350, 1280, 400);
			canvas.Children.Add(mMenuItemCanvas);
		}
	}
}
