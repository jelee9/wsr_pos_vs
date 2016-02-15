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

namespace wsr_pos.Setting.Item
{
	/// <summary>
	/// Interaction logic for SettingItemHeader.xaml
	/// </summary>
	public partial class SettingItemHeader : UserControl
	{
		public static readonly uint CANVAS_HEIGHT = 50;
		public static readonly uint LABEL_H = 50;
		public static readonly uint LABEL_Y = ((CANVAS_HEIGHT - LABEL_H) / 2);

		Label mName;
		Label mCategory;
		Label mmComment;
		Label mPrice;
		Label mDiscount;
		Label mPrintTogether;
		Label mPrintDot;

		public SettingItemHeader()
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
			setPosition(canvas, 50, 0, SettingItemButton.WIDTH, CANVAS_HEIGHT);

			mName = new Label();
			setPosition(mName, SettingItemButton.NAME_X, LABEL_Y, SettingItemButton.NAME_W, LABEL_H);
			mName.FontSize = 16;
			mName.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mName.Content = "이름";
			mName.VerticalContentAlignment = VerticalAlignment.Center;
			mName.HorizontalContentAlignment = HorizontalAlignment.Left;
			canvas.Children.Add(mName);

			mCategory = new Label();
			setPosition(mCategory, SettingItemButton.CATEGORY_X, LABEL_Y, SettingItemButton.CATEGORY_W, LABEL_H);
			mCategory.FontSize = 16;
			mCategory.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mCategory.Content = "카테고리";
			mCategory.VerticalContentAlignment = VerticalAlignment.Center;
			mCategory.HorizontalContentAlignment = HorizontalAlignment.Center;
			canvas.Children.Add(mCategory);

			mmComment = new Label();
			setPosition(mmComment, SettingItemButton.COMMENT_X, LABEL_Y, SettingItemButton.COMMENT_W, LABEL_H);
			mmComment.FontSize = 16;
			mmComment.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mmComment.Content = "설명";
			mmComment.VerticalContentAlignment = VerticalAlignment.Center;
			mmComment.HorizontalContentAlignment = HorizontalAlignment.Center;
			canvas.Children.Add(mmComment);

			mPrice = new Label();
			setPosition(mPrice, SettingItemButton.PRICE_X, LABEL_Y, SettingItemButton.PRICE_W, LABEL_H);
			mPrice.FontSize = 16;
			mPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mPrice.Content = "가격";
			mPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			canvas.Children.Add(mPrice);

			mDiscount = new Label();
			setPosition(mDiscount, SettingItemButton.DISCOUNT_X, LABEL_Y, SettingItemButton.DISCOUNT_W, LABEL_H);
			mDiscount.FontSize = 16;
			mDiscount.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mDiscount.Content = "할인";
			mDiscount.VerticalContentAlignment = VerticalAlignment.Center;
			mDiscount.HorizontalContentAlignment = HorizontalAlignment.Center;
			canvas.Children.Add(mDiscount);

			mPrintTogether = new Label();
			setPosition(mPrintTogether, SettingItemButton.PRINT_TOGETHER_X, LABEL_Y, SettingItemButton.PRINT_TOGETHER_W, LABEL_H);
			mPrintTogether.FontSize = 16;
			mPrintTogether.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mPrintTogether.Content = "모아\n찍기";
			mPrintTogether.VerticalContentAlignment = VerticalAlignment.Center;
			mPrintTogether.HorizontalContentAlignment = HorizontalAlignment.Center;
			canvas.Children.Add(mPrintTogether);

			mPrintDot = new Label();
			setPosition(mPrintDot, SettingItemButton.PRINT_DOT_X, LABEL_Y, SettingItemButton.PRINT_DOT_W, LABEL_H);
			mPrintDot.FontSize = 16;
			mPrintDot.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mPrintDot.Content = "점선\n출력";
			mPrintDot.VerticalContentAlignment = VerticalAlignment.Center;
			mPrintDot.HorizontalContentAlignment = HorizontalAlignment.Center;
			canvas.Children.Add(mPrintDot);
		}
	}
}
