using System;
using System.Collections.Generic;
using System.IO;
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
	public delegate void IconButtonClickEvent();

	/// <summary>
	/// Interaction logic for IconButton.xaml
	/// </summary>
	public partial class IconButton : UserControl
	{
		uint mWidth;
		uint mHeight;

		Image mIcon;
		Label mText;

		public IconButton(uint width, uint height)
		{
			InitializeComponent();

			button.Width = mWidth = width;
			button.Height = mHeight = height;

			Canvas.SetLeft(canvas, 0);
			Canvas.SetTop(canvas, 0);
			canvas.Width = width;
			canvas.Height = height;


			button.Click += onClick;
		}

		private Image makeImage(string image_uri)
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			Stream stream = assembly.GetManifestResourceStream("wsr_pos.Image." + image_uri);
			BitmapImage bitmap_image = new BitmapImage();

			bitmap_image.BeginInit();
			bitmap_image.StreamSource = stream;
			bitmap_image.CacheOption = BitmapCacheOption.OnLoad;
			bitmap_image.EndInit();

			RenderOptions.SetBitmapScalingMode(bitmap_image, BitmapScalingMode.HighQuality);

			Image image = new Image();
			image.Source = bitmap_image;

			return image;
		}

		public void setIcon(string image_uri, uint x, uint y, uint w, uint h)
		{
			mIcon = makeImage(image_uri);

			Canvas.SetLeft(mIcon, x);
			Canvas.SetTop(mIcon, y);
			mIcon.Width = w;
			mIcon.Height = h;

			canvas.Children.Add(mIcon);
		}
		public void setText(string text, uint x, uint y, uint w, uint h)
		{
			mText = new Label();

			Canvas.SetLeft(mText, x);
			Canvas.SetTop(mText, y);
			mText.Width = w;
			mText.Height = h;

			mText.Content = text;
			mText.FontSize = 16;
			mText.Foreground = MetrialColor.getBrush(MetrialColor.Name.White);
			mText.HorizontalContentAlignment = HorizontalAlignment.Left;
			mText.VerticalContentAlignment = VerticalAlignment.Center;

			canvas.Children.Add(mText);
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

		public event IconButtonClickEvent Click;

		public void onClick(object sender, RoutedEventArgs e)
		{
			if (Click != null)
			{
				Click();
			}
		}
	}
}
