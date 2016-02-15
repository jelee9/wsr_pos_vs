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
	/// <summary>
	/// Interaction logic for MenuCanvas.xaml
	/// </summary>
	public partial class MenuCanvas : UserControl
	{
		public static readonly uint X = 0;
		public static readonly uint Y = 0;
		public static readonly uint W = 300;
		public static readonly uint H = 1024 - 50;

		public static readonly uint BUTTON_W = W;
		public static readonly uint BUTTON_H = 45;

		public static readonly uint BUTTON_ICON_X = 30;
		public static readonly uint BUTTON_ICON_W = 25;
		public static readonly uint BUTTON_ICON_H = 25;
		public static readonly uint BUTTON_ICON_Y = ((BUTTON_H - BUTTON_ICON_H) / 2);

		public static readonly uint BUTTON_ICON_TEXT_GAP = 30;

		public static readonly uint BUTTON_TEXT_X = BUTTON_ICON_X + BUTTON_ICON_W + BUTTON_ICON_TEXT_GAP;
		public static readonly uint BUTTON_TEXT_Y = 0;
		public static readonly uint BUTTON_TEXT_W = BUTTON_W - BUTTON_TEXT_X;
		public static readonly uint BUTTON_TEXT_H = BUTTON_H;

		private IconButton mOrder;
		private IconButton mOrderButton;

		private IconButton mCoupon;
		private IconButton mCouponManageButton;

		private IconButton mSetting;
		private IconButton mSettingCategoryButton;
		private IconButton mSettingItemButton;
		private IconButton mSettingItemLayoutButton;
		private IconButton mPensionButton;

		private IconButton mReport;
		private IconButton mDailyReportButton;
		private IconButton mMonthlyReportButton;

		public MenuCanvas(uint x, uint y, uint w, uint h)
		{
			InitializeComponent();

			Canvas.SetLeft(this, x);
			Canvas.SetTop(this, y);
			this.Width = w;
			this.Height = h;
			this.Background = MetrialColor.getBrush(MetrialColor.Name.Grey, 8);
			setButton();
		}

		private void setButton()
		{
			{
				mOrder = new IconButton(BUTTON_W, BUTTON_H);
				mOrder.setText("주  문", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mOrder.setIcon("order_white_36x36.png", BUTTON_ICON_X, BUTTON_ICON_Y, BUTTON_ICON_W, BUTTON_ICON_H);
				mOrder.setBackgroundColor(MetrialColor.Name.Grey, 8, 5);

				mOrder.IsEnabled = false;

				Canvas.SetTop(mOrder, 0);
				Canvas.SetLeft(mOrder, 0);
				canvas.Children.Add(mOrder);
			}
			{
				mOrderButton = new IconButton(BUTTON_W, BUTTON_H);
				mOrderButton.setText("주문 관리", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mOrderButton.setBackgroundColor(MetrialColor.Name.Blue, 7, 7);

				//mOrderButton.IsEnabled = false;

				Canvas.SetTop(mOrderButton, BUTTON_H);
				Canvas.SetLeft(mOrderButton, 0);
				canvas.Children.Add(mOrderButton);
			}
			{
				mCoupon = new IconButton(BUTTON_W, BUTTON_H);
				mCoupon.setText("쿠  폰", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mCoupon.setIcon("coupon_white_36x36.png", BUTTON_ICON_X, BUTTON_ICON_Y, BUTTON_ICON_W, BUTTON_ICON_H);
				mCoupon.setBackgroundColor(MetrialColor.Name.Grey, 8, 5);

				mCoupon.IsEnabled = false;

				Canvas.SetTop(mCoupon, BUTTON_H * 2);
				Canvas.SetLeft(mCoupon, 0);
				canvas.Children.Add(mCoupon);
			}
			{
				mCouponManageButton = new IconButton(BUTTON_W, BUTTON_H);
				mCouponManageButton.setText("쿠폰 관리", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mCouponManageButton.setBackgroundColor(MetrialColor.Name.Blue, 7, 7);

				//mOrderButton.IsEnabled = false;

				Canvas.SetTop(mCouponManageButton, BUTTON_H * 3);
				Canvas.SetLeft(mCouponManageButton, 0);
				canvas.Children.Add(mCouponManageButton);
			}
			{
				mSetting = new IconButton(BUTTON_W, BUTTON_H);
				mSetting.setText("설  정", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mSetting.setIcon("settings_white_36x36.png", BUTTON_ICON_X, BUTTON_ICON_Y, BUTTON_ICON_W, BUTTON_ICON_H);
				mSetting.setBackgroundColor(MetrialColor.Name.Grey, 8, 5);

				mSetting.IsEnabled = false;

				Canvas.SetTop(mSetting, BUTTON_H * 4);
				Canvas.SetLeft(mSetting, 0);
				canvas.Children.Add(mSetting);
			}
			{
				mSettingCategoryButton = new IconButton(BUTTON_W, BUTTON_H);
				mSettingCategoryButton.setText("카테고리 관리", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mSettingCategoryButton.setBackgroundColor(MetrialColor.Name.Grey, 7, 5);

				//mSettingCategoryButton.IsEnabled = false;

				Canvas.SetTop(mSettingCategoryButton, BUTTON_H * 5);
				Canvas.SetLeft(mSettingCategoryButton, 0);
				canvas.Children.Add(mSettingCategoryButton);
			}
			{
				mSettingItemButton = new IconButton(BUTTON_W, BUTTON_H);
				mSettingItemButton.setText("아이템 관리", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mSettingItemButton.setBackgroundColor(MetrialColor.Name.Grey, 7, 5);

				//mSettingItemButton.IsEnabled = false;

				Canvas.SetTop(mSettingItemButton, BUTTON_H * 6);
				Canvas.SetLeft(mSettingItemButton, 0);
				canvas.Children.Add(mSettingItemButton);
			}
			{
				mSettingItemLayoutButton = new IconButton(BUTTON_W, BUTTON_H);
				mSettingItemLayoutButton.setText("아이템 위치 관리", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mSettingItemLayoutButton.setBackgroundColor(MetrialColor.Name.Grey, 7, 5);

				//mSettingItemLayoutButton.IsEnabled = false;

				Canvas.SetTop(mSettingItemLayoutButton, BUTTON_H * 7);
				Canvas.SetLeft(mSettingItemLayoutButton, 0);
				canvas.Children.Add(mSettingItemLayoutButton);
			}
			{
				mPensionButton = new IconButton(BUTTON_W, BUTTON_H);
				mPensionButton.setText("펜션 관리", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mPensionButton.setBackgroundColor(MetrialColor.Name.Grey, 7, 5);

				//mSettingItemLayoutButton.IsEnabled = false;

				Canvas.SetTop(mPensionButton, BUTTON_H * 8);
				Canvas.SetLeft(mPensionButton, 0);
				canvas.Children.Add(mPensionButton);
			}
			{
				mReport = new IconButton(BUTTON_W, BUTTON_H);
				mReport.setText("리 포 트", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mReport.setIcon("chart_white_36x36.png", BUTTON_ICON_X, BUTTON_ICON_Y, BUTTON_ICON_W, BUTTON_ICON_H);
				mReport.setBackgroundColor(MetrialColor.Name.Grey, 8, 5);

				mReport.IsEnabled = false;

				Canvas.SetTop(mReport, BUTTON_H * 9);
				Canvas.SetLeft(mReport, 0);
				canvas.Children.Add(mReport);
			}
			{
				mDailyReportButton = new IconButton(BUTTON_W, BUTTON_H);
				mDailyReportButton.setText("일간 리포트", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mDailyReportButton.setBackgroundColor(MetrialColor.Name.Grey, 7, 5);

				//mSettingItemLayoutButton.IsEnabled = false;

				Canvas.SetTop(mDailyReportButton, BUTTON_H * 10);
				Canvas.SetLeft(mDailyReportButton, 0);
				canvas.Children.Add(mDailyReportButton);
			}
			{
				mMonthlyReportButton = new IconButton(BUTTON_W, BUTTON_H);
				mMonthlyReportButton.setText("월간 리포트", BUTTON_TEXT_X, BUTTON_TEXT_Y, BUTTON_TEXT_W, BUTTON_TEXT_H);
				mMonthlyReportButton.setBackgroundColor(MetrialColor.Name.Grey, 7, 5);

				//mSettingItemLayoutButton.IsEnabled = false;

				Canvas.SetTop(mMonthlyReportButton, BUTTON_H * 11);
				Canvas.SetLeft(mMonthlyReportButton, 0);
				canvas.Children.Add(mMonthlyReportButton);
			}
		}
	}
}
