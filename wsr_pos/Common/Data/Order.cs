using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsr_pos
{
	public class Order
	{
		public enum PaymentMethod
		{
			Cash,
			Card,
			AccountTransfer,
		};

		private uint mId;

		private uint mSubTotalPrice;

		private uint mDiscountPrice;
		private uint mDiscountPercent;

		private uint mEnuriPrice;
		private uint mEnuriPercent;

		private uint mTotalPrice;
		private uint mTotalPercent;

		private PaymentMethod mPaymentMethod;

		private DateTime mCreateTIme;

		public Order(uint sub_total_price, uint discount_price, uint discount_percent, uint enuri_price, uint enuri_percent, uint total_price, uint total_percent, PaymentMethod payment_method)
		{
			mSubTotalPrice = sub_total_price;
			mDiscountPrice = discount_price;
			mDiscountPercent = discount_percent;
			mEnuriPrice = enuri_price;
			mEnuriPercent = enuri_percent;
			mTotalPrice = total_price;
			mTotalPercent = total_percent;
			mPaymentMethod = payment_method;
			mCreateTIme = DateTime.Now;
		}

		public Order(uint id, uint sub_total_price, uint discount_price, uint discount_percent, uint enuri_price, uint enuri_percent, uint total_price, uint total_percent, PaymentMethod payment_method, string create_time)
		{
			mId = id;
			mSubTotalPrice = sub_total_price;
			mDiscountPrice = discount_price;
			mDiscountPercent = discount_percent;
			mEnuriPrice = enuri_price;
			mEnuriPercent = enuri_percent;
			mTotalPrice = total_price;
			mTotalPercent = total_percent;
			mPaymentMethod = payment_method;
			mCreateTIme = DateTime.ParseExact(create_time, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
		}
	}
}
