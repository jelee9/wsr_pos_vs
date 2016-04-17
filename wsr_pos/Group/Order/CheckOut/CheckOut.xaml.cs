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
	public delegate void CheckoutPressedEvent(Order.PaymentMethod payment_method);
	/// <summary>
	/// Interaction logic for CheckOut.xaml
	/// </summary>
	public partial class CheckOut : Window
	{
		public static readonly uint BUTTON_WIDTH = 200;
		public static readonly uint BUTTON_HEIGHT = 100;

		public static readonly uint LABEL_X = 0;
		public static readonly uint LABEL_Y = 0;
		public static readonly uint LABEL_WIDTH = (BUTTON_WIDTH * 2);
		public static readonly uint LABEL_HEIGHT = 50;

		private Label mLabel;

		private Button mYesButton;
		private Button mNoButton;

		public CheckOut()
		{
			InitializeComponent();

			Width = BUTTON_WIDTH * 2;
			Height = LABEL_HEIGHT + BUTTON_HEIGHT;

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
			mLabel.FontSize = 25;
			mLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
			mLabel.VerticalContentAlignment = VerticalAlignment.Center;
			mLabel.Content = "정말 계산 하시겠습니까?";
			mLabel.Padding = new Thickness(0, 0, 50, 0);
			canvas.Children.Add(mLabel);
		}
		private void setButton()
		{
			mYesButton = new Button();
			setPosition(mYesButton, 0, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			mYesButton.FontSize = 30;
			mYesButton.Content = "예";
			setColor(mYesButton, MetrialColor.Name.Cyan);
			mYesButton.Click += onClick;
			canvas.Children.Add(mYesButton);
			
			mNoButton = new Button();
			setPosition(mNoButton, BUTTON_WIDTH, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			mNoButton.FontSize = 30;
			mNoButton.Content = "아니오";
			setColor(mNoButton, MetrialColor.Name.Red);
			mNoButton.Click += onCancel;
			canvas.Children.Add(mNoButton);
		}

		public event CheckOutPressedEvent CheckOutPressed;

		public void onClick(object sender, RoutedEventArgs e)
		{
			if (CheckOutPressed != null)
			{
				//PaymentMethodSelected(Order.PaymentMethod.Cash);
			}

			Close();
		}

		private void onCancel(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
