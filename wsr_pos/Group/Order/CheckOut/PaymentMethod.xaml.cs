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
	public delegate void PaymentMethodSelectedEvent(Order.PaymentMethod payment_method);
	/// <summary>
	/// Interaction logic for PaymentMethod.xaml
	/// </summary>
	public partial class PaymentMethod : Window
	{
		public static readonly uint BUTTON_WIDTH = 150;
		public static readonly uint BUTTON_HEIGHT = 100;

		public static readonly uint LABEL_X = 0;
		public static readonly uint LABEL_Y = 0;
		public static readonly uint LABEL_WIDTH = (BUTTON_WIDTH * 4);
		public static readonly uint LABEL_HEIGHT = 50;

		private Label mLabel;

		private Button mCashButton;
		private Button mCardButton;
		private Button mTransferButton;
		private Button mCancelButton;

		public PaymentMethod()
		{
			InitializeComponent();

			Width = BUTTON_WIDTH * 4;
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
			mLabel.Content = "계산";
			mLabel.Padding = new Thickness(0, 0, 50, 0);
			canvas.Children.Add(mLabel);
		}
		private void setButton()
		{
			mCashButton = new Button();
			setPosition(mCashButton, 0, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			mCashButton.FontSize = 30;
			mCashButton.Content = "현금";
			setColor(mCashButton, MetrialColor.Name.Cyan);
			mCashButton.Click += onClick;
			canvas.Children.Add(mCashButton);

			mCardButton = new Button();
			setPosition(mCardButton, BUTTON_WIDTH, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			mCardButton.FontSize = 30;
			mCardButton.Content = "카드";
			setColor(mCardButton, MetrialColor.Name.Cyan);
			mCardButton.Click += onClick;
			canvas.Children.Add(mCardButton);

			mTransferButton = new Button();
			setPosition(mTransferButton, BUTTON_WIDTH * 2, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			mTransferButton.FontSize = 30;
			mTransferButton.Content = "계좌이체";
			setColor(mTransferButton, MetrialColor.Name.Cyan);
			mTransferButton.Click += onClick;
			canvas.Children.Add(mTransferButton);

			mCancelButton = new Button();
			setPosition(mCancelButton, BUTTON_WIDTH * 3, (LABEL_Y + LABEL_HEIGHT) + 0, BUTTON_WIDTH, BUTTON_HEIGHT);
			mCancelButton.FontSize = 30;
			mCancelButton.Content = "취소";
			setColor(mCancelButton, MetrialColor.Name.Red);
			mCancelButton.Click += onCancel;
			canvas.Children.Add(mCancelButton);
		}

		public event PaymentMethodSelectedEvent PaymentMethodSelected;

		public void onClick(object sender, RoutedEventArgs e)
		{
			if (PaymentMethodSelected != null)
			{
				if (sender == mCashButton)
				{
					PaymentMethodSelected(Order.PaymentMethod.Cash);
				}
				else if (sender == mCardButton)
				{
					PaymentMethodSelected(Order.PaymentMethod.Card);
				}
				else if (sender == mTransferButton)
				{
					PaymentMethodSelected(Order.PaymentMethod.Transfer);
				}

				Close();
			}
		}

		private void onCancel(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
