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
	public delegate void DiscountSelectedEvent(OrderItem.DiscountType discount_type);

	/// <summary>
	/// Interaction logic for DIscountOption.xaml
	/// </summary>
	public partial class DiscountOption : Window
	{
		public static readonly uint BUTTON_WIDTH = 150;
		public static readonly uint BUTTON_HEIGHT = 100;

		public static readonly uint LABEL_X = 0;
		public static readonly uint LABEL_Y = 0;
		public static readonly uint LABEL_WIDTH = (BUTTON_WIDTH * 3);
		public static readonly uint LABEL_HEIGHT = BUTTON_HEIGHT;

		private Label mLabel;

		private Button m1Button;
		private Button m2Button;
		private Button m3Button;
		private Button m4Button;

		public DiscountOption()
		{
			InitializeComponent();

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
			mLabel.FontSize = 45;
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
			m1Button.FontSize = 30;
			m1Button.Content = "퍼센트";
			setColor(m1Button, MetrialColor.Name.Cyan);
			m1Button.Click += onClick;
			canvas.Children.Add(m1Button);

			m2Button = new Button();
			setPosition(m2Button, BUTTON_WIDTH, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			m2Button.FontSize = 30;
			m2Button.Content = "가격";
			setColor(m2Button, MetrialColor.Name.Cyan);
			m2Button.Click += onClick;
			canvas.Children.Add(m2Button);

			m3Button = new Button();
			setPosition(m3Button, BUTTON_WIDTH * 2, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			m3Button.FontSize = 30;
			m3Button.Content = "펜션";
			setColor(m3Button, MetrialColor.Name.Cyan);
			m3Button.Click += onClick;
			canvas.Children.Add(m3Button);

			m4Button = new Button();
			setPosition(m4Button, BUTTON_WIDTH * 3, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			m4Button.FontSize = 30;
			m4Button.Content = "에누리";
			setColor(m4Button, MetrialColor.Name.Cyan);
			m4Button.Click += onClick;
			canvas.Children.Add(m4Button);
		}

		public void onClick(object sender, RoutedEventArgs e)
		{
			if (sender == m1Button)
			{
				Close();
				onDiscountSelected(OrderItem.DiscountType.Percent);
			}
			else if (sender == m2Button)
			{
				Close();
				onDiscountSelected(OrderItem.DiscountType.Price);
			}
			else if (sender == m3Button)
			{
				Close();
				onDiscountSelected(OrderItem.DiscountType.Pension);
			}
			else if (sender == m4Button)
			{
				Close();
				onDiscountSelected(OrderItem.DiscountType.Enuri);
			}
		}

		public event DiscountSelectedEvent DiscountSelected;

		private void onDiscountSelected(OrderItem.DiscountType discount_type)
		{
			if (DiscountSelected != null)
			{
				DiscountSelected(discount_type);
			}
		}
	}
}
