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
		private Item mItem;

        private TextBlock mTextBlockName;
        private TextBlock mTextBlockComment;
        private TextBlock mTextBlockPrice;

		public ItemButton(Item item)
		{
			InitializeComponent();

			mItem = item;
			setWidget();
			setColor();
		}

		private void setWidget()
		{
			button.HorizontalContentAlignment = HorizontalAlignment.Center;
			button.VerticalContentAlignment = VerticalAlignment.Center;

			button.FontFamily = new FontFamily("맑은고딕");
			button.FontSize = 15;

			button.Click += onClick;

			mTextBlockName = new TextBlock();
			mTextBlockName.HorizontalAlignment = HorizontalAlignment.Center;
			mTextBlockName.VerticalAlignment = VerticalAlignment.Center;
			mTextBlockName.Text = mItem.getName();

			mTextBlockComment = new TextBlock();
			mTextBlockComment.HorizontalAlignment = HorizontalAlignment.Center;
			mTextBlockComment.VerticalAlignment = VerticalAlignment.Center;
			mTextBlockComment.FontSize = 10;
			mTextBlockComment.FontStyle = FontStyles.Italic;
			mTextBlockComment.Text = mItem.getComment();

			mTextBlockPrice = new TextBlock();
			mTextBlockPrice.HorizontalAlignment = HorizontalAlignment.Center;
			mTextBlockPrice.VerticalAlignment = VerticalAlignment.Center;
			mTextBlockPrice.Text = string.Format("{0:N0}", mItem.getPrice());

			addTextBlock(mTextBlockName, 0);

			if (mItem.getComment() != "")
			{
				addTextBlock(mTextBlockComment, 1);
				addTextBlock(mTextBlockPrice, 2);
			}
			else
			{
				addTextBlock(mTextBlockPrice, 1);
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

		private void setColor()
        {
            Style style = new Style();

            style.Setters.Add(new Setter(BackgroundProperty, MetrialColor.getBrush(mItem.getColorName(), 3)));
			style.Setters.Add(new Setter(ForegroundProperty, MetrialColor.getBrush(MetrialColor.Name.White)));

			Trigger mouse_over_trigger = new Trigger();
			mouse_over_trigger.Property = UIElement.IsMouseOverProperty;
			mouse_over_trigger.Value = true;
			mouse_over_trigger.Setters.Add(new Setter(BackgroundProperty, MetrialColor.getBrush(mItem.getColorName(), 4)));
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
