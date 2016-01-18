using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace wsr_pos
{
	/// <summary>
	/// Interaction logic for ItemButton.xaml
	/// </summary>
	public partial class ItemButton : UserControl
    {
        private string Name;
        private string Comment;
        private string Price;

        private TextBlock TextBlockName;
        private TextBlock TextBlockComment;
        private TextBlock TextBlockPrice;

        public ItemButton(string name, string comment, uint price)
        {
            InitializeComponent();

            setData(name, comment, price);
            setWidget();
            setColor(MetrialColor.Name.LightGreen);
        }

		private void setData(string name, string comment, uint price)
		{
			Name = name;
			Comment = comment;
			Price = string.Format("{0:N0}", price);
		}

		private void setWidget()
		{
			button.HorizontalContentAlignment = HorizontalAlignment.Center;
			button.VerticalContentAlignment = VerticalAlignment.Center;

			button.FontFamily = new FontFamily("맑은고딕");
			button.FontSize = 15;

			button.Click += onClick;

			TextBlockName = new TextBlock();
			TextBlockName.HorizontalAlignment = HorizontalAlignment.Center;
			TextBlockName.VerticalAlignment = VerticalAlignment.Center;
			TextBlockName.Text = Name;

			TextBlockComment = new TextBlock();
			TextBlockComment.HorizontalAlignment = HorizontalAlignment.Center;
			TextBlockComment.VerticalAlignment = VerticalAlignment.Center;
			TextBlockComment.FontSize = 10;
			TextBlockComment.FontStyle = FontStyles.Italic;
			TextBlockComment.Text = Comment;

			TextBlockPrice = new TextBlock();
			TextBlockPrice.HorizontalAlignment = HorizontalAlignment.Center;
			TextBlockPrice.VerticalAlignment = VerticalAlignment.Center;
			TextBlockPrice.Text = Price;

			addTextBlock(TextBlockName, 0);

			if (Comment != "")
			{
				addTextBlock(TextBlockComment, 1);
				addTextBlock(TextBlockPrice, 2);
			}
			else
			{
				addTextBlock(TextBlockPrice, 1);
			}
		}

		private void addTextBlock(TextBlock text_block, int index)
		{
			RowDefinition row = new RowDefinition();
			row.Height = GridLength.Auto;
			grid.RowDefinitions.Add(row);

			grid.Children.Add(text_block);
			Grid.SetRow(text_block, index);
		}

		private void setColor(MetrialColor.Name color_name)
        {
            Style style = new Style();

            style.Setters.Add(new Setter(BackgroundProperty, MetrialColor.getBrush(color_name, 3)));
			style.Setters.Add(new Setter(ForegroundProperty, MetrialColor.getBrush(MetrialColor.Name.White)));

			Trigger mouse_over_trigger = new Trigger();
			mouse_over_trigger.Property = UIElement.IsMouseOverProperty;
			mouse_over_trigger.Value = true;
			mouse_over_trigger.Setters.Add(new Setter(BackgroundProperty, MetrialColor.getBrush(color_name, 4)));
			style.Triggers.Add(mouse_over_trigger);

			ControlTemplate control_template = new ControlTemplate(typeof(Button));
			var border = new FrameworkElementFactory(typeof(Border));
			border.SetValue(BorderThicknessProperty, new Thickness(0));
			border.SetValue(BorderBrushProperty, Brushes.Black);
			var binding = new TemplateBindingExtension();
			binding.Property = BackgroundProperty;
			border.SetValue(BackgroundProperty, binding);

			FrameworkElementFactory content_presenter = new FrameworkElementFactory(typeof(ContentPresenter));
			content_presenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
			content_presenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
			border.AppendChild(content_presenter);

			control_template.VisualTree = border;

			style.Setters.Add(new Setter(TemplateProperty, control_template));

			button.Style = style;
		}

		private Style Merge(Style style1, Style style2)
		{
			Style style = new Style();

			_Merge(style, style1);
			_Merge(style, style2);

			return style;
		}

		private void _Merge(Style style1, Style style2)
		{
			if (style1 == null)
			{
				throw new ArgumentNullException("style1");
			}

			if (style2 == null)
			{
				throw new ArgumentNullException("style2");
			}

			if (style1.TargetType.IsAssignableFrom(style2.TargetType))
			{
				style1.TargetType = style2.TargetType;
			}

			if (style2.BasedOn != null)
			{
				Merge(style1, style2.BasedOn);
			}

			foreach (SetterBase currentSetter in style2.Setters)
			{
				style1.Setters.Add(currentSetter);
			}

			foreach (TriggerBase currentTrigger in style2.Triggers)
			{
				style1.Triggers.Add(currentTrigger);
			}

			// This code is only needed when using DynamicResources.
			foreach (object key in style2.Resources.Keys)
			{
				style1.Resources[key] = style2.Resources[key];
			}
		}

		public delegate void ClickEvent(object sender, RoutedEventArgs e);

		public event ClickEvent Click;

		public void onClick(object sender, RoutedEventArgs e)
		{
			if (Click != null)
			{
				Click(sender, e);
			}
		}

		public void setPosition(int x, int y, int w, int h)
		{
			Canvas.SetLeft(this, x);
			Canvas.SetTop(this, y);
			Width = w;
			Height = h;
		}
    }
}
