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
	/// Interaction logic for SettingItemButton.xaml
	/// </summary>
	public partial class SettingItemButton : UserControl
	{
		public static readonly uint OUTER_PADDING = 20;
		public static readonly uint INNER_PADDING = 40;

		public static readonly uint WIDTH = 1180;
		public static readonly uint SCROLL = 20;
		public static readonly uint HEIGHT = 50;

		public static readonly uint NAME_X = OUTER_PADDING;
		public static readonly uint NAME_W = 200;
		public static readonly uint NAME_H = 25;
		public static readonly uint NAME_Y = ((HEIGHT - NAME_H) / 2);

		public static readonly uint CATEGORY_X = NAME_X + NAME_W + INNER_PADDING;
		public static readonly uint CATEGORY_Y = NAME_Y;
		public static readonly uint CATEGORY_W = 70;
		public static readonly uint CATEGORY_H = NAME_H;

		public static readonly uint COMMENT_X = CATEGORY_X + CATEGORY_W + INNER_PADDING;
		public static readonly uint COMMENT_Y = CATEGORY_Y;
		public static readonly uint COMMENT_W = 280;
		public static readonly uint COMMENT_H = CATEGORY_H;

		public static readonly uint PRICE_X = COMMENT_X + COMMENT_W + INNER_PADDING;
		public static readonly uint PRICE_Y = COMMENT_Y;
		public static readonly uint PRICE_W = 100;
		public static readonly uint PRICE_H = COMMENT_H;

		public static readonly uint DISCOUNT_X = PRICE_X + PRICE_W + INNER_PADDING;
		public static readonly uint DISCOUNT_Y = PRICE_Y;
		public static readonly uint DISCOUNT_W = 50;
		public static readonly uint DISCOUNT_H = PRICE_H;

		public static readonly uint PRINT_TOGETHER_X = DISCOUNT_X + DISCOUNT_W + INNER_PADDING;
		public static readonly uint PRINT_TOGETHER_Y = DISCOUNT_Y;
		public static readonly uint PRINT_TOGETHER_W = 50;
		public static readonly uint PRINT_TOGETHER_H = DISCOUNT_H;

		public static readonly uint PRINT_DOT_X = PRINT_TOGETHER_X + PRINT_TOGETHER_W + INNER_PADDING;
		public static readonly uint PRINT_DOT_Y = PRINT_TOGETHER_Y;
		public static readonly uint PRINT_DOT_W = 50;
		public static readonly uint PRINT_DOT_H = PRINT_TOGETHER_H;

		public static readonly uint DELETE_X = PRINT_DOT_X + PRINT_DOT_W + INNER_PADDING;
		public static readonly uint DELETE_W = 35;
		public static readonly uint DELETE_H = 35;
		public static readonly uint DELETE_Y = ((HEIGHT - DELETE_H) / 2);

		public static readonly uint LINE_X = OUTER_PADDING;
		public static readonly uint LINE_W = WIDTH - SCROLL - (OUTER_PADDING * 2);
		public static readonly uint LINE_H = 2;
		public static readonly uint LINE_Y = HEIGHT - LINE_H;

		private Label mName;
		private Label mCategory;
		private Label mComment;
		private Label mPrice;
		private Label mDiscount;
		private Label mPrintTogether;
		private Label mPrintDot;
		private Canvas mLine;

		private  RectButton mDelete;

		private wsr_pos.Item mItem;

		public SettingItemButton(wsr_pos.Item item)
		{
			InitializeComponent();

			mItem = item;

			setLayout();
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

		private void setLayout()
		{
		//	setPosition(button, 0, 0, WIDTH, HEIGHT);
			button.Padding = new Thickness(0, 0, 0, 0);
			setPosition(canvas, 0, 0, WIDTH, HEIGHT);
			button.HorizontalAlignment = HorizontalAlignment.Left;

			mName = new Label();
			setPosition(mName, NAME_X, NAME_Y, NAME_W, NAME_H);
			mName.FontSize = 14;
			mName.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mName.Content = mItem.getName();
			mName.VerticalContentAlignment = VerticalAlignment.Center;
			mName.HorizontalContentAlignment = HorizontalAlignment.Left;
			canvas.Children.Add(mName);

			mCategory = new Label();
			setPosition(mCategory, CATEGORY_X, CATEGORY_Y, CATEGORY_W, CATEGORY_H);
			mCategory.FontSize = 14;
			mCategory.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);

			List<wsr_pos.Category> category_list = DBManager.getInstance().getCategoryList();

			foreach(wsr_pos.Category category in category_list)
			{
				if(category.getId() == mItem.getCategoryId())
				{
					mCategory.Content = category.getName();
				}
			}

			mCategory.HorizontalContentAlignment = HorizontalAlignment.Center;
			mCategory.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mCategory);

			mComment = new Label();
			setPosition(mComment, COMMENT_X, COMMENT_Y, COMMENT_W, COMMENT_H);
			mComment.FontSize = 14;
			mComment.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mComment.Content = mItem.getComment();
			mComment.HorizontalContentAlignment = HorizontalAlignment.Center;
			mComment.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mComment);

			mPrice = new Label();
			setPosition(mPrice, PRICE_X, PRICE_Y, PRICE_W, PRICE_H);
			mPrice.FontSize = 16;
			mPrice.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mPrice.Content = string.Format("{0:N0}", mItem.getPrice());
			mPrice.VerticalContentAlignment = VerticalAlignment.Center;
			mPrice.HorizontalContentAlignment = HorizontalAlignment.Right;
			canvas.Children.Add(mPrice);

			mDiscount = new Label();
			setPosition(mDiscount, DISCOUNT_X, DISCOUNT_Y, DISCOUNT_W, DISCOUNT_H);
			mDiscount.FontSize = 16;
			mDiscount.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mDiscount.Content = (mItem.getDiscount() ? "O" : "X");
			mDiscount.HorizontalContentAlignment = HorizontalAlignment.Center;
			mDiscount.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mDiscount);

			mPrintTogether = new Label();
			setPosition(mPrintTogether, PRINT_TOGETHER_X, PRINT_TOGETHER_Y, PRINT_TOGETHER_W, PRINT_TOGETHER_H);
			mPrintTogether.FontSize = 16;
			mPrintTogether.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mPrintTogether.Content = (mItem.getPrintTogether() ? "O" : "X");
			mPrintTogether.HorizontalContentAlignment = HorizontalAlignment.Center;
			mPrintTogether.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mPrintTogether);

			mPrintDot = new Label();
			setPosition(mPrintDot, PRINT_DOT_X, PRINT_DOT_Y, PRINT_DOT_W, PRINT_DOT_H);
			mPrintDot.FontSize = 16;
			mPrintDot.Foreground = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			mPrintDot.Content = (mItem.getPrintDot() ? "O" : "X");
			mPrintDot.HorizontalContentAlignment = HorizontalAlignment.Center;
			mPrintDot.VerticalContentAlignment = VerticalAlignment.Center;
			canvas.Children.Add(mPrintDot);

			mDelete = new RectButton(DELETE_W, DELETE_H);
			setPosition(mDelete, DELETE_X, DELETE_Y, DELETE_W, DELETE_H);
			mDelete.setBackgroundImage("delete.png", "delete.png");
			canvas.Children.Add(mDelete);

			mLine = new Canvas();
			setPosition(mLine, LINE_X, LINE_Y, LINE_W, LINE_H);
			mLine.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 4);
			canvas.Children.Add(mLine);
		}

		public void setBackgroundColor(MetrialColor.Name color = MetrialColor.Name.DeepOrange, int normal = 3, int press = 5)
		{
			Style style = new Style();

			style.Setters.Add(new Setter(ForegroundProperty, MetrialColor.getBrush(MetrialColor.Name.White)));

			// Normal
			ControlTemplate normal_button_template = new ControlTemplate(typeof(Button));

			FrameworkElementFactory normal_button_shape = new FrameworkElementFactory(typeof(Rectangle));
			normal_button_shape.SetValue(Shape.FillProperty, MetrialColor.getBrush(color, normal));
			//normal_button_shape.SetValue(Shape.StrokeProperty, Brushes.White);
			//normal_button_shape.SetValue(Shape.StrokeThicknessProperty, 2.0);

			FrameworkElementFactory normal_button_content_presenter = new FrameworkElementFactory(typeof(ContentPresenter));
			normal_button_content_presenter.SetValue(ContentProperty, new TemplateBindingExtension(ContentProperty));
			normal_button_content_presenter.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Center);
			normal_button_content_presenter.SetValue(VerticalAlignmentProperty, VerticalAlignment.Center);

			FrameworkElementFactory normal_button_merged_element = new FrameworkElementFactory(typeof(Grid));
			normal_button_merged_element.AppendChild(normal_button_shape);
			normal_button_merged_element.AppendChild(normal_button_content_presenter);

			normal_button_template.VisualTree = normal_button_merged_element;
			style.Setters.Add(new Setter(TemplateProperty, normal_button_template));

			// For Pressed
			Trigger button_pressed_trigger = new Trigger();
			button_pressed_trigger.Property = Button.IsPressedProperty;
			button_pressed_trigger.Value = true;

			ControlTemplate pressed_button_template = new ControlTemplate(typeof(Button));

			FrameworkElementFactory pressed_button_shape = new FrameworkElementFactory(typeof(Rectangle));
			pressed_button_shape.SetValue(Shape.FillProperty, MetrialColor.getBrush(color, press));
			//pressed_button_shape.SetValue(Shape.StrokeProperty, Brushes.White);
			//pressed_button_shape.SetValue(Shape.StrokeThicknessProperty, 2.0);

			FrameworkElementFactory pressed_button_button_content_presenter = new FrameworkElementFactory(typeof(ContentPresenter));
			pressed_button_button_content_presenter.SetValue(ContentProperty, new TemplateBindingExtension(ContentProperty));
			pressed_button_button_content_presenter.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Center);
			pressed_button_button_content_presenter.SetValue(VerticalAlignmentProperty, VerticalAlignment.Center);

			FrameworkElementFactory pressed_button_mreged_element = new FrameworkElementFactory(typeof(Grid));
			pressed_button_mreged_element.AppendChild(pressed_button_shape);
			pressed_button_mreged_element.AppendChild(pressed_button_button_content_presenter);

			pressed_button_template.VisualTree = pressed_button_mreged_element;
			button_pressed_trigger.Setters.Add(new Setter(TemplateProperty, pressed_button_template));

			style.Triggers.Add(button_pressed_trigger);

			button.Style = style;
		}
	}
}
