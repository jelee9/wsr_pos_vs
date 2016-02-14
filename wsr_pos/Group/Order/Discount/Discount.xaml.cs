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
	/// Interaction logic for Discount.xaml
	/// </summary>
	public partial class Discount : Window
	{
		public static uint BUTTON_WIDTH = 120;
		public static uint BUTTON_HEIGHT = 70;

		public static uint LABEL_X = 0;
		public static uint LABEL_Y = 0;
		public static uint LABEL_WIDTH = (BUTTON_WIDTH * 3);
		public static uint LABEL_HEIGHT = BUTTON_HEIGHT;

		private Label mLabel;

		private Button m1Button;
		private Button m2Button;
		private Button m3Button;
		private Button m4Button;
		private Button m5Button;
		private Button m6Button;
		private Button m7Button;
		private Button m8Button;
		private Button m9Button;
		private Button m0Button;
		private Button m00Button;
		private Button mCancelButton;
		private Button mDoneButton;

		private OrderItem.DiscountType mDiscountType;
		private uint mValue;

		public Discount()
		{
			InitializeComponent();

			//mDiscountType = OrderItem.DiscountType.Price;
			mDiscountType = OrderItem.DiscountType.Percent;
			mValue = 0;

			setLabel();
			setButton();

		}
		private void setPosition(FrameworkElement element, uint x, uint y, uint w, uint h)
		{
			Canvas.SetLeft(element, x);
			Canvas.SetTop(element, y);
			element.Width = w;
			element.Height = h;
		}

		private void setColor(Button button, MetrialColor.Name color_name)
		{
			Style style = new Style();

			style.Setters.Add(new Setter(BackgroundProperty, MetrialColor.getBrush(color_name, 3)));
			style.Setters.Add(new Setter(ForegroundProperty, MetrialColor.getBrush(MetrialColor.Name.White)));

			Trigger button_pressed_trigger = new Trigger();
			//mouse_over_trigger.Property = UIElement.IsMouseOverProperty;
			button_pressed_trigger.Property = Button.IsPressedProperty;
			button_pressed_trigger.Value = true;
			button_pressed_trigger.Setters.Add(new Setter(BackgroundProperty, MetrialColor.getBrush(color_name, 4)));
			button_pressed_trigger.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(5)));
			button_pressed_trigger.Setters.Add(new Setter(BorderBrushProperty, MetrialColor.getBrush(color_name, 1)));
			style.Triggers.Add(button_pressed_trigger);

			ControlTemplate control_template = new ControlTemplate(typeof(Button));
			var border = new FrameworkElementFactory(typeof(Border));
			border.Name = "button_border";
			border.SetValue(BorderThicknessProperty, new Thickness(0));
			border.SetValue(BorderBrushProperty, MetrialColor.getBrush(color_name, 3));
			var binding = new TemplateBindingExtension();
			binding.Property = BackgroundProperty;
			border.SetValue(BackgroundProperty, binding);

			/* border color change on mouse pressed
			Trigger mouse_over_trigger_border = new Trigger();
			mouse_over_trigger_border.Property = Button.IsPressedProperty;
			mouse_over_trigger_border.Value = true;
			mouse_over_trigger_border.Setters.Add(new Setter(BorderBrushProperty, MetrialColor.getBrush(mItem.getColorName(), 3), "button_border"));
			control_template.Triggers.Add(mouse_over_trigger_border);
			*/

			FrameworkElementFactory content_presenter = new FrameworkElementFactory(typeof(ContentPresenter));
			content_presenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
			content_presenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
			border.AppendChild(content_presenter);

			control_template.VisualTree = border;

			style.Setters.Add(new Setter(TemplateProperty, control_template));

			button.Style = style;
		}

		private void setLabel()
		{
			mLabel = new Label();
			setPosition(mLabel, LABEL_X, LABEL_Y, LABEL_WIDTH, LABEL_HEIGHT);
			mLabel.Background = MetrialColor.getBrush(MetrialColor.Name.BlueGrey);
			mLabel.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mLabel.FontSize = 30;
			mLabel.HorizontalContentAlignment = HorizontalAlignment.Right;
			mLabel.VerticalContentAlignment = VerticalAlignment.Center;
			mLabel.Content = "0";
			mLabel.Padding = new Thickness(0, 0, 50, 0);
			canvas.Children.Add(mLabel);
		}
		private void setButton()
		{
			m1Button = new Button();
			setPosition(m1Button, 0, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			m1Button.FontSize = 20;
			m1Button.Content = "1";
			setColor(m1Button, MetrialColor.Name.Cyan);
			m1Button.Click += onClick;
			canvas.Children.Add(m1Button);

			m2Button = new Button();
			setPosition(m2Button, BUTTON_WIDTH, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			m2Button.FontSize = 20;
			m2Button.Content = "2";
			setColor(m2Button, MetrialColor.Name.Cyan);
			m2Button.Click += onClick;
			canvas.Children.Add(m2Button);

			m3Button = new Button();
			setPosition(m3Button, BUTTON_WIDTH * 2, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			m3Button.FontSize = 20;
			m3Button.Content = "3";
			setColor(m3Button, MetrialColor.Name.Cyan);
			m3Button.Click += onClick;
			canvas.Children.Add(m3Button);

			m4Button = new Button();
			setPosition(m4Button, 0, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT, BUTTON_WIDTH, BUTTON_HEIGHT);
			m4Button.FontSize = 20;
			m4Button.Content = "4";
			setColor(m4Button, MetrialColor.Name.Cyan);
			m4Button.Click += onClick;
			canvas.Children.Add(m4Button);

			m5Button = new Button();
			setPosition(m5Button, BUTTON_WIDTH, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT, BUTTON_WIDTH, BUTTON_HEIGHT);
			m5Button.FontSize = 20;
			m5Button.Content = "5";
			setColor(m5Button, MetrialColor.Name.Cyan);
			m5Button.Click += onClick;
			canvas.Children.Add(m5Button);

			m6Button = new Button();
			setPosition(m6Button, BUTTON_WIDTH * 2, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT, BUTTON_WIDTH, BUTTON_HEIGHT);
			m6Button.FontSize = 20;
			m6Button.Content = "6";
			setColor(m6Button, MetrialColor.Name.Cyan);
			m6Button.Click += onClick;
			canvas.Children.Add(m6Button);

			m7Button = new Button();
			setPosition(m7Button, 0, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT * 2, BUTTON_WIDTH, BUTTON_HEIGHT);
			m7Button.FontSize = 20;
			m7Button.Content = "7";
			setColor(m7Button, MetrialColor.Name.Cyan);
			m7Button.Click += onClick;
			canvas.Children.Add(m7Button);

			m8Button = new Button();
			setPosition(m8Button, BUTTON_WIDTH, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT * 2, BUTTON_WIDTH, BUTTON_HEIGHT);
			m8Button.FontSize = 20;
			m8Button.Content = "8";
			setColor(m8Button, MetrialColor.Name.Cyan);
			m8Button.Click += onClick;
			canvas.Children.Add(m8Button);

			m9Button = new Button();
			setPosition(m9Button, BUTTON_WIDTH * 2, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT * 2, BUTTON_WIDTH, BUTTON_HEIGHT);
			m9Button.FontSize = 20;
			m9Button.Content = "9";
			setColor(m9Button, MetrialColor.Name.Cyan);
			m9Button.Click += onClick;
			canvas.Children.Add(m9Button);

			m0Button = new Button();
			setPosition(m0Button, 0, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT * 3, BUTTON_WIDTH, BUTTON_HEIGHT);
			m0Button.FontSize = 20;
			m0Button.Content = "0";
			setColor(m0Button, MetrialColor.Name.Cyan);
			m0Button.Click += onClick;
			canvas.Children.Add(m0Button);

			m00Button = new Button();
			setPosition(m00Button, BUTTON_WIDTH, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT * 3, BUTTON_WIDTH * 2, BUTTON_HEIGHT);
			m00Button.FontSize = 20;
			m00Button.Content = "00";
			setColor(m00Button, MetrialColor.Name.Cyan);
			m00Button.Click += onClick;
			canvas.Children.Add(m00Button);

			mCancelButton = new Button();
			setPosition(mCancelButton, 0, (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT * 4, ((BUTTON_WIDTH * 3) / 2), BUTTON_HEIGHT);
			mCancelButton.FontSize = 20;
			mCancelButton.Content = "취소";
			setColor(mCancelButton, MetrialColor.Name.Red);
			canvas.Children.Add(mCancelButton);

			mDoneButton = new Button();
			setPosition(mDoneButton, ((BUTTON_WIDTH * 3) / 2), (LABEL_Y + LABEL_HEIGHT) + BUTTON_HEIGHT * 4, ((BUTTON_WIDTH * 3) / 2), BUTTON_HEIGHT);
			mDoneButton.FontSize = 20;
			mDoneButton.Content = "적용";
			setColor(mDoneButton, MetrialColor.Name.Blue);
			canvas.Children.Add(mDoneButton);
		}

		public void onClick(object sender, RoutedEventArgs e)
		{
			if (sender == m1Button)
			{
				mValue = (mValue * 10) + 1;
			}
			else if (sender == m2Button)
			{
				mValue = (mValue * 10) + 2;
			}
			else if (sender == m3Button)
			{
				mValue = (mValue * 10) + 3;
			}
			else if (sender == m4Button)
			{
				mValue = (mValue * 10) + 4;
			}
			else if (sender == m5Button)
			{
				mValue = (mValue * 10) + 5;
			}
			else if (sender == m6Button)
			{
				mValue = (mValue * 10) + 6;
			}
			else if (sender == m7Button)
			{
				mValue = (mValue * 10) + 7;
			}
			else if (sender == m8Button)
			{
				mValue = (mValue * 10) + 8;
			}
			else if (sender == m9Button)
			{
				mValue = (mValue * 10) + 9;
			}
			else if (sender == m0Button)
			{
				mValue = (mValue * 10);
			}
			else if (sender == m00Button)
			{
				mValue = (mValue * 100);
			}

			if(mDiscountType == OrderItem.DiscountType.Percent)
			{
				if(mValue > 100)
				{
					mValue = 100;
				}

				mLabel.Content = string.Format("{0:N0}", mValue) + " %";
			}
			else if(mDiscountType == OrderItem.DiscountType.Price)
			{
				if(mValue > 10000000)
				{
					mValue = 10000000;
				}
			}
		}
	}
}