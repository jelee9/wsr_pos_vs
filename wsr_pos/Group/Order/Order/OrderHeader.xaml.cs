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
	/// Interaction logic for OrderHeader.xaml
	/// </summary>
	public partial class OrderHeader : UserControl
	{
		public static readonly uint CANVAS_HEIGHT = 50;
		public static readonly uint LABEL_H = 30;
		public static readonly uint LABEL_Y = ((CANVAS_HEIGHT - LABEL_H) / 2);

		Label mName;
		Label mQuantity;
		Label mSubTotalPrice;
		Label mDiscount;
		Label mTotalPrice;

		public OrderHeader()
		{
			InitializeComponent();

			setHeader();
		}

		private void setPosition(FrameworkElement element, uint x, uint y, uint w, uint h)
		{
			Canvas.SetLeft(element, x);
			Canvas.SetTop(element, y);
			element.Width = w;
			element.Height = h;

			if (element.GetType() == typeof(Label))
			{
				((Label)element).Padding = new Thickness(0, 0, 0, 0);
			}
		}

		private void setHeader()
		{
			setPosition(canvas, 0, 0, OrderItemButton.WIDTH, CANVAS_HEIGHT);

			mName = new Label();
			setPosition(mName, OrderItemButton.NAME_X, LABEL_Y, OrderItemButton.NAME_W, LABEL_H);
			mName.FontSize = 16;
			mName.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mName.Content = "이름";
			mName.VerticalContentAlignment = VerticalAlignment.Center;
			mName.HorizontalContentAlignment = HorizontalAlignment.Left;
			canvas.Children.Add(mName);

			mQuantity = new Label();
			setPosition(mQuantity, OrderItemButton.QUANTITY_X, LABEL_Y, OrderItemButton.QUANTITY_W, LABEL_H);
			mQuantity.FontSize = 16;
			mQuantity.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mQuantity.Content = "수량";
			mQuantity.VerticalContentAlignment = VerticalAlignment.Center;
			mQuantity.HorizontalContentAlignment = HorizontalAlignment.Center;
			canvas.Children.Add(mQuantity);

			mSubTotalPrice = new Label();
			setPosition(mSubTotalPrice, OrderItemButton.SUBTOTAL_PRICE_X, LABEL_Y, OrderItemButton.SUBTOTAL_PRICE_W, LABEL_H);
			mSubTotalPrice.FontSize = 16;
			mSubTotalPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mSubTotalPrice.Content = "합계";
			mSubTotalPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mSubTotalPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			canvas.Children.Add(mSubTotalPrice);

			mDiscount = new Label();
			setPosition(mDiscount, OrderItemButton.DISCOUNT_PRICE_X, LABEL_Y, OrderItemButton.DISCOUNT_PRICE_W, LABEL_H);
			mDiscount.FontSize = 16;
			mDiscount.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mDiscount.Content = "할인";
			mDiscount.VerticalContentAlignment = VerticalAlignment.Center;
			mDiscount.HorizontalContentAlignment = HorizontalAlignment.Right;
			canvas.Children.Add(mDiscount);

			mTotalPrice = new Label();
			setPosition(mTotalPrice, OrderItemButton.TOTAL_PRICE_X, LABEL_Y, OrderItemButton.TOTAL_PRICE_W, LABEL_H);
			mTotalPrice.FontSize = 16;
			mTotalPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mTotalPrice.Content = "총계";
			mTotalPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mTotalPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			canvas.Children.Add(mTotalPrice);
		}
	}
}
