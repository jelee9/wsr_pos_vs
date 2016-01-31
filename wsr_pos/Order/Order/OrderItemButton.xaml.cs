using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for OrderItemButton.xaml
	/// </summary>
	public partial class OrderItemButton : UserControl
	{
		public static uint OUTER_PADDING = 20;
		public static uint INNER_PADDING = 40;

		public static uint WIDTH = 880;
		public static uint SCROLL = 20;
		public static uint WIDTH_WITH_SCROLL = (WIDTH + SCROLL);
		public static uint HEIGHT = 60;

		public static uint NAME_X = OUTER_PADDING;
		public static uint NAME_W = 240;
		public static uint NAME_H = 25;
		public static uint NAME_Y = ((HEIGHT - NAME_H) / 2);

		public static uint COMMENT_X = OUTER_PADDING;
		public static uint COMMENT_W = NAME_W;
		public static uint COMMENT_H = 20;
		public static uint NAME_Y_WITH_COMMENT = ((HEIGHT - (NAME_H + COMMENT_H)) / 2);
		public static uint COMMENT_Y = (NAME_Y_WITH_COMMENT + NAME_H);

		public static uint INCREASE_QUANTITY_X = NAME_X + NAME_W + INNER_PADDING;
		public static uint INCREASE_QUANTITY_W = 35;
		public static uint INCREASE_QUANTITY_H = 35;
		public static uint INCREASE_QUANTITY_Y = ((HEIGHT - INCREASE_QUANTITY_H) / 2);

		public static uint QUANTITY_X = INCREASE_QUANTITY_X + INCREASE_QUANTITY_W;
		public static uint QUANTITY_Y = NAME_Y;
		public static uint QUANTITY_W = 50;
		public static uint QUANTITY_H = NAME_H;

		public static uint DECREASE_QUANTITY_X = QUANTITY_X + QUANTITY_W;
		public static uint DECREASE_QUANTITY_W = 35;
		public static uint DECREASE_QUANTITY_H = 35;
		public static uint DECREASE_QUANTITY_Y = ((HEIGHT - DECREASE_QUANTITY_H) / 2);

		public static uint SUBTOTAL_PRICE_X = DECREASE_QUANTITY_X + DECREASE_QUANTITY_W + INNER_PADDING;
		public static uint SUBTOTAL_PRICE_Y = NAME_Y;
		public static uint SUBTOTAL_PRICE_W = 80;
		public static uint SUBTOTAL_PRICE_H = NAME_H;

		public static uint DISCOUNT_PRICE_X = SUBTOTAL_PRICE_X + SUBTOTAL_PRICE_W + INNER_PADDING;
		public static uint DISCOUNT_PRICE_Y = SUBTOTAL_PRICE_Y;
		public static uint DISCOUNT_PRICE_W = SUBTOTAL_PRICE_W;
		public static uint DISCOUNT_PRICE_H = SUBTOTAL_PRICE_H;

		public static uint TOTAL_PRICE_X = DISCOUNT_PRICE_X + DISCOUNT_PRICE_W + INNER_PADDING;
		public static uint TOTAL_PRICE_Y = SUBTOTAL_PRICE_Y;
		public static uint TOTAL_PRICE_W = SUBTOTAL_PRICE_W;
		public static uint TOTAL_PRICE_H = SUBTOTAL_PRICE_H;

		public static uint LINE_X = OUTER_PADDING;
		public static uint LINE_W = WIDTH - (OUTER_PADDING * 2);
		public static uint LINE_H = 2;
		public static uint LINE_Y = HEIGHT - LINE_H;

		private OrderItem mOrderItem;

		private Canvas mLine;
		private Label mName;
		private Label mComment;
		private CircleButton mIncreaseQuantity;
		private Label mQuantity;
		private CircleButton mDecreaseQuantity;
		private Label mSubTotalPrice;
		private Label mDiscountPrice;
		private Label mDiscountPercent;
		private Label mTotalPrice;

		CircleButtonClickEvent mIncreaseEvent;
		CircleButtonClickEvent mDecreaseEvent;

		public OrderItemButton(OrderItem order_item = null, CircleButtonClickEvent increase_event = null, CircleButtonClickEvent decrease_event = null)
		{
			InitializeComponent();

			mOrderItem = order_item;
			mIncreaseEvent = increase_event;
			mDecreaseEvent = decrease_event;

			canvas.Width = WIDTH;
			canvas.Height = HEIGHT;
			canvas.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 7);

			setName();
			setComment();
			setIncreaseQuantity();
			setQuantity();
			setDecreaseQuantity();
			setSubTotalPrice();
			setDiscountPrice();
			setTotalPrice();

			setLine();		
		}

		public Item getItem()
		{
			return mOrderItem.getItem();
		}

		public void refreshOrder(OrderItem order_item = null)
		{
			mOrderItem = order_item;
			mQuantity.Content = mOrderItem.getQuantity();
			mSubTotalPrice.Content = string.Format("{0:N0}", mOrderItem.getSubTotalPrice());
			mDiscountPrice.Content = string.Format("{0:N0}", mOrderItem.getDiscountPrice());
			mTotalPrice.Content = string.Format("{0:N0}", mOrderItem.getTotalPrice());
		}

		private void setPosition(FrameworkElement element, uint x, uint y, uint w, uint h)
		{
			Canvas.SetLeft(element, x);
			Canvas.SetTop(element, y);
			element.Width = w;
			element.Height = h;

			if(element.GetType() == typeof(Label))
			{
				((Label)element).Padding = new Thickness(0, 0, 0, 0);
			}
		}

		private void setName()
		{
			mName = new Label();

			if (mOrderItem.getItem().getComment() != "")
			{
				setPosition(mName, NAME_X, NAME_Y_WITH_COMMENT, NAME_W, NAME_H);
			}
			else
			{
				setPosition(mName, NAME_X, NAME_Y, NAME_W, NAME_H);
			}

			mName.FontSize = 16;
			mName.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mName.Content = mOrderItem.getItem().getName();
			mName.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mName);
		}

		private void setComment()
		{
			if (mOrderItem.getItem().getComment() != "")
			{
				mComment = new Label();
				setPosition(mComment, COMMENT_X, COMMENT_Y, COMMENT_W, COMMENT_H);
				mComment.FontSize = 10;
				mComment.FontStyle = FontStyles.Italic;
				mComment.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
				mComment.Content = mOrderItem.getItem().getComment();
				canvas.Children.Add(mComment);
			}
		}

		private void setIncreaseQuantity()
		{
			mIncreaseQuantity = new CircleButton(mOrderItem.getItem());
			setPosition(mIncreaseQuantity, INCREASE_QUANTITY_X, INCREASE_QUANTITY_Y, INCREASE_QUANTITY_W, INCREASE_QUANTITY_H);
			mIncreaseQuantity.VerticalContentAlignment = VerticalAlignment.Bottom;
			mIncreaseQuantity.Click += mIncreaseEvent;
			canvas.Children.Add(mIncreaseQuantity);
		}

		private void setQuantity()
		{
			mQuantity = new Label();
			setPosition(mQuantity, QUANTITY_X, QUANTITY_Y, QUANTITY_W, QUANTITY_H);
			mQuantity.FontSize = 16;
			mQuantity.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mQuantity.Content = mOrderItem.getQuantity();
			mQuantity.HorizontalContentAlignment = HorizontalAlignment.Center;
			mQuantity.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mQuantity);
		}

		private void setDecreaseQuantity()
		{
			mDecreaseQuantity = new CircleButton(mOrderItem.getItem());
			setPosition(mDecreaseQuantity, DECREASE_QUANTITY_X, DECREASE_QUANTITY_Y, DECREASE_QUANTITY_W, DECREASE_QUANTITY_H);
			//mDecreaseQuantity.Background = MetrialColor.getBrush(MetrialColor.Name.Purple);
			mDecreaseQuantity.VerticalContentAlignment = VerticalAlignment.Bottom;
			mDecreaseQuantity.Click += mDecreaseEvent;
			canvas.Children.Add(mDecreaseQuantity);
		}

		private void setSubTotalPrice()
		{
			mSubTotalPrice = new Label();
			setPosition(mSubTotalPrice, SUBTOTAL_PRICE_X, SUBTOTAL_PRICE_Y, SUBTOTAL_PRICE_W, SUBTOTAL_PRICE_H);
			mSubTotalPrice.FontSize = 16;
			mSubTotalPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mSubTotalPrice.Content = string.Format("{0:N0}", mOrderItem.getSubTotalPrice());
			mSubTotalPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mSubTotalPrice.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mSubTotalPrice);
		}

		private void setDiscountPrice()
		{
			mDiscountPrice = new Label();
			setPosition(mDiscountPrice, DISCOUNT_PRICE_X, DISCOUNT_PRICE_Y, DISCOUNT_PRICE_W, DISCOUNT_PRICE_H);
			mDiscountPrice.FontSize = 16;
			mDiscountPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mDiscountPrice.Content = string.Format("{0:N0}", mOrderItem.getDiscountPrice());
			mDiscountPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mDiscountPrice.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mDiscountPrice);
		}

		private void setTotalPrice()
		{
			mTotalPrice = new Label();
			setPosition(mTotalPrice, TOTAL_PRICE_X, TOTAL_PRICE_Y, TOTAL_PRICE_W, TOTAL_PRICE_H);
			mTotalPrice.FontSize = 16;
			mTotalPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mTotalPrice.Content = string.Format("{0:N0}", mOrderItem.getTotalPrice());
			mTotalPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			mTotalPrice.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mTotalPrice);
		}

		private void setLine()
		{
			mLine = new Canvas();
			Canvas.SetLeft(mLine, LINE_X);
			Canvas.SetTop(mLine, LINE_Y);
			mLine.Width = LINE_W;
			mLine.Height = LINE_H;
			mLine.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 4);
			canvas.Children.Add(mLine);
		}
	}
}
