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
using System.Windows.Shapes;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for TotalCanvas.xaml
	/// </summary>
	public partial class TotalCanvas : UserControl
	{
		public static uint WIDTH = 380;
		public static uint HEIGHT = 400;

		public static uint TEXT_X = 30;
		public static uint TEXT_WIDTH = 150;
		public static uint TEXT_HEIGHT = 50;

		public static uint SUB_TOTAL_TEXT_Y = 50;
		public static uint DISCOUNT_TEXT_Y = SUB_TOTAL_TEXT_Y + TEXT_HEIGHT;
		public static uint TOTAL_TEXT_Y = DISCOUNT_TEXT_Y + TEXT_HEIGHT;

		public static uint VALUE_X = TEXT_X + TEXT_WIDTH;
		public static uint VALUE_WIDTH = 170;
		public static uint VALUE_HEIGHT = 50;

		public static uint SUB_TOTAL_VALUE_Y = 50;
		public static uint DISCOUNT_VALUE_Y = SUB_TOTAL_VALUE_Y + VALUE_HEIGHT;
		public static uint TOTAL_VALUE_Y = DISCOUNT_VALUE_Y + VALUE_HEIGHT;

		Label mSubTotalText;
		Label mDiscountText;
		Label mTotalText;

		Label mSubTotalPrice;
		Label mDiscountPrice;
		Label mDiscountPercent;
		Label mTotalPrice;

		public TotalCanvas()
		{
			InitializeComponent();

			canvas.Width = WIDTH;
			canvas.Height = HEIGHT;
			canvas.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 6);

			setTextLabel();
			setPriceLabel();
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

		private void setTextLabel()
		{
			mSubTotalText = new Label();
			setPosition(mSubTotalText, TEXT_X, SUB_TOTAL_TEXT_Y, TEXT_WIDTH, TEXT_HEIGHT);
			mSubTotalText.FontSize = 25;
			mSubTotalText.HorizontalContentAlignment = HorizontalAlignment.Center;
			mSubTotalText.VerticalContentAlignment = VerticalAlignment.Center;
			mSubTotalText.Content = "합   계";

			mSubTotalText.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mSubTotalText.Background = MetrialColor.getBrush(MetrialColor.Name.Blue);

			canvas.Children.Add(mSubTotalText);

			mDiscountText = new Label();
			setPosition(mDiscountText, TEXT_X, DISCOUNT_TEXT_Y, TEXT_WIDTH, TEXT_HEIGHT);
			mDiscountText.FontSize = 25;
			mDiscountText.HorizontalContentAlignment = HorizontalAlignment.Center;
			mDiscountText.VerticalContentAlignment = VerticalAlignment.Center;
			mDiscountText.Content = "할   인";

			mDiscountText.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mDiscountText.Background = MetrialColor.getBrush(MetrialColor.Name.Blue);

			canvas.Children.Add(mDiscountText);

			mTotalText = new Label();
			setPosition(mTotalText, TEXT_X, TOTAL_TEXT_Y, TEXT_WIDTH, TEXT_HEIGHT);
			mTotalText.FontSize = 25;
			mTotalText.HorizontalContentAlignment = HorizontalAlignment.Center;
			mTotalText.VerticalContentAlignment = VerticalAlignment.Center;
			mTotalText.Content = "총   계";

			mTotalText.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mTotalText.Background = MetrialColor.getBrush(MetrialColor.Name.Blue);

			canvas.Children.Add(mTotalText);
		}

		private void setPriceLabel()
		{
			mSubTotalPrice = new Label();
			setPosition(mSubTotalPrice, VALUE_X, SUB_TOTAL_VALUE_Y, VALUE_WIDTH, VALUE_HEIGHT);
			mSubTotalPrice.FontSize = 25;
			mSubTotalPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mSubTotalPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mSubTotalPrice.Content = "0";

			mSubTotalPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mSubTotalPrice.Background = MetrialColor.getBrush(MetrialColor.Name.Brown);

			canvas.Children.Add(mSubTotalPrice);

			mDiscountPrice = new Label();
			setPosition(mDiscountPrice, VALUE_X, DISCOUNT_VALUE_Y, VALUE_WIDTH, VALUE_HEIGHT);
			mDiscountPrice.FontSize = 25;
			mDiscountPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mDiscountPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mDiscountPrice.Content = "0";

			mDiscountPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mDiscountPrice.Background = MetrialColor.getBrush(MetrialColor.Name.Brown);

			canvas.Children.Add(mDiscountPrice);

			mTotalPrice = new Label();
			setPosition(mTotalPrice, VALUE_X, TOTAL_VALUE_Y, VALUE_WIDTH, VALUE_HEIGHT);
			mTotalPrice.FontSize = 25;
			mTotalPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mTotalPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mTotalPrice.Content = "0";

			mTotalPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mTotalPrice.Background = MetrialColor.getBrush(MetrialColor.Name.Brown);

			canvas.Children.Add(mTotalPrice);
		}

		public void setPrice(uint sub_total_price, uint discount_price, uint total_price)
		{
			mSubTotalPrice.Content = string.Format("{0:N0}", sub_total_price);
			mDiscountPrice.Content = string.Format("{0:N0}", discount_price);
			mTotalPrice.Content = string.Format("{0:N0}", total_price);
		}
	}
}
