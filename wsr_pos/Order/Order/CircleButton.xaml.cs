using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wsr_pos
{
	public delegate void CircleButtonClickEvent(Item item);

	/// <summary>
	/// Interaction logic for CircleButton.xaml
	/// </summary>
	public partial class CircleButton : UserControl
	{
		Item mItem;

		public CircleButton(Item item)
		{
			InitializeComponent();

			mItem = item;

			setCircle();

			Image img = new Image();
			//img.Source = new BitmapImage(new Uri("D:\\My_Project\\wsr_pos_vs\\wsr_pos_vs\\wsr_pos\\bin\\x64\\Debug\\Resource\\add_circle_button.png", UriKind.RelativeOrAbsolute));
			//img.Source = new BitmapImage(new Uri("C:\\add_circle_outline_grey600_192x192.png", UriKind.RelativeOrAbsolute));
			//img.Source = new BitmapImage(new Uri(".\\Resource\\add_circle_button.png", UriKind.RelativeOrAbsolute));
			//img.Source = Properties.Resources.add_circle_outline_grey600_192x192.GetHicon();

			
			System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
			Stream myStream = myAssembly.GetManifestResourceStream("wsr_pos.add_circle_outline_grey600_192x192.png");
			BitmapImage bi = new BitmapImage();

			bi.BeginInit();
			bi.StreamSource = myStream;
			bi.CacheOption = BitmapCacheOption.OnLoad;
			bi.EndInit();

			img.Source = bi;

			RenderOptions.SetBitmapScalingMode(img, BitmapScalingMode.HighQuality);
			//img.Source = new BitmapImage(new Uri(@"Resources\add_circle_outline_grey600_192x192.png", UriKind.Relative));

			img.Width = 35;
			img.Height = 35;
			//img.Stretch = Stretch.Fill;

			StackPanel stackPnl = new StackPanel();
			stackPnl.Orientation = Orientation.Horizontal;
			//stackPnl.Margin = new Thickness(10);
			stackPnl.Children.Add(img);

			btn.Content = stackPnl;
		}

		private void setCircle(MetrialColor.Name color = MetrialColor.Name.DeepOrange)
		{
			Style style = new Style();

			style.Setters.Add(new Setter(ForegroundProperty, MetrialColor.getBrush(MetrialColor.Name.White)));

			// Normal
			ControlTemplate normal_button_template = new ControlTemplate(typeof(Button));

			FrameworkElementFactory normal_button_shape = new FrameworkElementFactory(typeof(Ellipse));
			//normal_button_shape.SetValue(Shape.FillProperty, MetrialColor.getBrush(color, 3));
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

			FrameworkElementFactory pressed_button_shape = new FrameworkElementFactory(typeof(Ellipse));
			pressed_button_shape.SetValue(Shape.FillProperty, MetrialColor.getBrush(MetrialColor.Name.Grey, 3));
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

			btn.Style = style;

			btn.Click += onClick;
		}

		public event CircleButtonClickEvent Click;

		public void onClick(object sender, RoutedEventArgs e)
		{
			if (Click != null)
			{
				Click(mItem);
			}
		}
	}
}