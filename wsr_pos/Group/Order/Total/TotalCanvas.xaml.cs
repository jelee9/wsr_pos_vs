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
	public delegate void DiscountPressedEvent();
	public delegate void CancelPressedEvent();
	public delegate void CheckOutPressedEvent();

	/// <summary>
	/// Interaction logic for TotalCanvas.xaml
	/// </summary>
	public partial class TotalCanvas : UserControl
	{
		public static readonly uint WIDTH = 380;
		public static readonly uint HEIGHT = 470;

		public static readonly uint TEXT_X = 30;
		public static readonly uint TEXT_WIDTH = 150;
		public static readonly uint TEXT_HEIGHT = 70;

		public static readonly uint SUB_TOTAL_TEXT_Y = 50;
		public static readonly uint DISCOUNT_TEXT_Y = SUB_TOTAL_TEXT_Y + TEXT_HEIGHT;
		public static readonly uint TOTAL_TEXT_Y = DISCOUNT_TEXT_Y + TEXT_HEIGHT;

		public static readonly uint VALUE_X = TEXT_X + TEXT_WIDTH;
		public static readonly uint VALUE_WIDTH = 140;
		public static readonly uint VALUE_HEIGHT = 70;

		public static readonly uint SUB_TOTAL_VALUE_Y = 50;
		public static readonly uint DISCOUNT_VALUE_Y = SUB_TOTAL_VALUE_Y + VALUE_HEIGHT;
		public static readonly uint TOTAL_VALUE_Y = DISCOUNT_VALUE_Y + VALUE_HEIGHT;

		public static readonly uint BUTTON_WIDTH = (WIDTH / 2);
		public static readonly uint BUTTON_HEIGHT = 80;



		Label mSubTotalText;
		Label mDiscountText;

		Label mSubTotalPrice;
		Label mDiscountPrice;
		Label mDiscountPercent;
		Label mTotalPrice;

		RectButton mDiscountButton;
		RectButton mSaveButton;
		RectButton mCancelButton;
		RectButton mCheckOutButton;

		Discount mDiscount;

		public TotalCanvas()
		{
			InitializeComponent();

			canvas.Width = WIDTH;
			canvas.Height = HEIGHT;
			canvas.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 3);

			setTextLabel();
			setPriceLabel();
			setButton();
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

			mSubTotalText.Foreground = MetrialColor.getBrush(MetrialColor.Name.Black);
			//mSubTotalText.Background = MetrialColor.getBrush(MetrialColor.Name.Blue);

			canvas.Children.Add(mSubTotalText);

			mDiscountText = new Label();
			setPosition(mDiscountText, TEXT_X, DISCOUNT_TEXT_Y, TEXT_WIDTH, TEXT_HEIGHT);
			mDiscountText.FontSize = 25;
			mDiscountText.HorizontalContentAlignment = HorizontalAlignment.Center;
			mDiscountText.VerticalContentAlignment = VerticalAlignment.Center;
			mDiscountText.Content = "할   인";

			mDiscountText.Foreground = MetrialColor.getBrush(MetrialColor.Name.Black);
			//mDiscountText.Background = MetrialColor.getBrush(MetrialColor.Name.Blue);

			canvas.Children.Add(mDiscountText);
		}

		private void setPriceLabel()
		{
			mSubTotalPrice = new Label();
			setPosition(mSubTotalPrice, VALUE_X, SUB_TOTAL_VALUE_Y, VALUE_WIDTH, VALUE_HEIGHT);
			mSubTotalPrice.FontSize = 25;
			mSubTotalPrice.FontWeight = FontWeights.Bold;
			mSubTotalPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mSubTotalPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mSubTotalPrice.Content = "0";

			mSubTotalPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.Black);
			//mSubTotalPrice.Background = MetrialColor.getBrush(MetrialColor.Name.Brown);

			canvas.Children.Add(mSubTotalPrice);

			mDiscountPrice = new Label();
			setPosition(mDiscountPrice, VALUE_X, DISCOUNT_VALUE_Y, VALUE_WIDTH, VALUE_HEIGHT);
			mDiscountPrice.FontSize = 25;
			mDiscountPrice.FontWeight = FontWeights.Bold;
			mDiscountPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mDiscountPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mDiscountPrice.Content = "0";

			mDiscountPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.Black);
			//mDiscountPrice.Background = MetrialColor.getBrush(MetrialColor.Name.Brown);

			canvas.Children.Add(mDiscountPrice);

			mTotalPrice = new Label();

			setPosition(mTotalPrice, TEXT_X, TOTAL_VALUE_Y, TEXT_WIDTH + VALUE_WIDTH, (uint)(VALUE_HEIGHT * 1.5));
			mTotalPrice.FontSize = 45;
			mTotalPrice.FontWeight = FontWeights.Bold;
			mTotalPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mTotalPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mTotalPrice.Content = "0";

			mTotalPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.Orange, 7);
			//mTotalPrice.Background = MetrialColor.getBrush(MetrialColor.Name.Brown);

			canvas.Children.Add(mTotalPrice);
		}

		private void setButton()
		{
			mDiscountButton = new RectButton(BUTTON_WIDTH, BUTTON_HEIGHT);
			mDiscountButton.setText("할  인");
			mDiscountButton.FontSize = 25;
			mDiscountButton.setBackgroundColor(MetrialColor.Name.Blue);
			Canvas.SetLeft(mDiscountButton, 0);
			Canvas.SetTop(mDiscountButton, (HEIGHT - (BUTTON_HEIGHT * 2) - 1));
			canvas.Children.Add(mDiscountButton);
			mDiscountButton.Click += showDiscountCanvas;

			mSaveButton = new RectButton(BUTTON_WIDTH - 1, BUTTON_HEIGHT);
			mSaveButton.setText("저  장");
			mSaveButton.FontSize = 25;
			mSaveButton.setBackgroundColor(MetrialColor.Name.Blue);
			Canvas.SetLeft(mSaveButton, BUTTON_WIDTH + 1);
			Canvas.SetTop(mSaveButton, (HEIGHT - (BUTTON_HEIGHT * 2) - 1));
			canvas.Children.Add(mSaveButton);

			mCancelButton = new RectButton(BUTTON_WIDTH, BUTTON_HEIGHT);
			mCancelButton.setText("취  소");
			mCancelButton.FontSize = 25;
			mCancelButton.setBackgroundColor(MetrialColor.Name.Blue);
			Canvas.SetLeft(mCancelButton, 0);
			Canvas.SetTop(mCancelButton, (HEIGHT - (BUTTON_HEIGHT)));
			canvas.Children.Add(mCancelButton);
			mCancelButton.Click += cancelOrder;

			mCheckOutButton = new RectButton(BUTTON_WIDTH - 1, BUTTON_HEIGHT);
			mCheckOutButton.setText("계  산");
			mCheckOutButton.FontSize = 25;
			mCheckOutButton.setBackgroundColor(MetrialColor.Name.Blue);
			Canvas.SetLeft(mCheckOutButton, BUTTON_WIDTH + 1);
			Canvas.SetTop(mCheckOutButton, (HEIGHT - (BUTTON_HEIGHT)));
			canvas.Children.Add(mCheckOutButton);
			mCheckOutButton.Click += showCheckOutCanvas;
		}

		public void setPrice(uint sub_total_price, uint discount_price, uint total_price)
		{
			mSubTotalPrice.Content = string.Format("{0:N0}", sub_total_price);
			mDiscountPrice.Content = string.Format("{0:N0}", discount_price);
			mTotalPrice.Content = string.Format("{0:N0}", total_price);
		}

		public event DiscountPressedEvent DiscountPressed;
		public event CancelPressedEvent CancelPressed;
		public event CheckOutPressedEvent CheckOutPressed;

		private void showDiscountCanvas()
		{
			if(DiscountPressed != null)
			{
				DiscountPressed();
			}
		}

		private void cancelOrder()
		{
			if(CancelPressed != null)
			{
				CancelPressed();
			}
		}

		private void showCheckOutCanvas()
		{
			if (CheckOutPressed != null)
			{
				CheckOutPressed();
			}
		}
	}
}
