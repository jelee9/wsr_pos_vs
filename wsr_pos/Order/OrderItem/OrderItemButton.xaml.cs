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
		static public uint PADDING = 20;

		static public uint W = 800;
		static public uint H = 50;

		static public uint NAME_X = PADDING;
		static public uint NAME_Y = ((H - NAME_H) / 2);
		static public uint name_Y_With_comment = 0;
		static public uint NAME_W = 400;
		static public uint NAME_H = 25;

		static public uint COMMENT_X = PADDING;
		static public uint COMMENT_Y = name_Y_With_comment + NAME_H;
		static public uint COMMENT_W = NAME_W;
		static public uint COMMENT_H = 20;

		static public uint LINE_X = PADDING;
		static public uint LINE_Y = H - LINE_H;
		static public uint LINE_W = W - (PADDING * 2);
		static public uint LINE_H = 2;

		private OrderItem mOrderItem;

		private Canvas mLine;
		private Label mItemName;
		private Label mItemComment;
		private CircleButton mIncreaseAmount;
		private TextBlock mAmount;
		private CircleButton mDecreaseAmount;
		private TextBlock mPrice;
		private TextBlock mSubTotalPrice;
		private TextBlock mDiscountPrice;
		private TextBlock mDiscountPercent;
		private TextBlock mTotalPrice;

		public OrderItemButton(OrderItem order_item = null)
		{
			InitializeComponent();

			mOrderItem = order_item;

			canvas.Width = W;
			canvas.Height = H;

			mLine = new Canvas();
			Canvas.SetLeft(mLine, LINE_X);
			Canvas.SetTop(mLine, LINE_Y);
			mLine.Width = LINE_W;
			mLine.Height = LINE_H;
			mLine.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 4);
			canvas.Children.Add(mLine);

			mItemName = new Label();
			Canvas.SetLeft(mItemName, NAME_X);
			Canvas.SetTop(mItemName, NAME_Y);
			mItemName.Width = NAME_W;
			mItemName.Height = NAME_H;
			mItemName.FontSize = 18;
			mItemName.Background = MetrialColor.getBrush(MetrialColor.Name.Purple);
			mItemName.Content = mOrderItem.getItem().getName();
			mItemName.Padding = new Thickness(0, 0, 0, 0);
			mItemName.VerticalContentAlignment = VerticalAlignment.Bottom;
			
			if(mOrderItem.getItem().getComment() != "")
			{
				Canvas.SetTop(mItemName, name_Y_With_comment);

				mItemComment = new Label();
				Canvas.SetLeft(mItemComment, COMMENT_X);
				Canvas.SetTop(mItemComment, COMMENT_Y);
				mItemComment.Width = COMMENT_W;
				mItemComment.Height = COMMENT_H;
				mItemComment.FontSize = 12;
				mItemComment.Padding = new Thickness(0, 0, 0, 0);
				mItemComment.FontStyle = FontStyles.Italic;
				mItemComment.Background = MetrialColor.getBrush(MetrialColor.Name.Pink);
				mItemComment.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
				mItemComment.Content = mOrderItem.getItem().getComment();
				canvas.Children.Add(mItemComment);
			}
			else
			{
				Canvas.SetTop(mItemName, 10);
			}

			canvas.Children.Add(mItemName);
		}
	}
}
