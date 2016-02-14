using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsr_pos
{
	public class OrderItem
	{
		public enum DiscountType
		{
			None,
			Percent,
			Price,
			Custom,
		};

		private Item mItem;
		private uint mQuantity;
		private uint mSubTotalPrice;
		private DiscountType mDiscountType;

		private uint mDiscountPrice;
		private uint mDiscountPercent;
		private uint mEnuriPrice;
		private uint mEnuriPercent;
		private uint mTotalPrice;

		public OrderItem(Item item)
		{
			mItem = item;
			mQuantity = 1;
			mSubTotalPrice = 0;
			mDiscountType = DiscountType.None;
			mDiscountPrice = 0;
			mDiscountPercent = 0;
			mEnuriPrice = 0;
			mEnuriPercent = 0;
			mTotalPrice = 0;

			recalculation();
		}

		public Item getItem()
		{
			return mItem;
		}

		public uint getQuantity()
		{
			return mQuantity;
		}

		public void increaseQuantity(uint amount = 1)
		{
			mQuantity = mQuantity + amount;
			recalculation();
		}

		public void decreaseQuantity(uint amount = 1)
		{
			if (mQuantity > 0)
			{
				mQuantity = mQuantity - amount;
			}

			recalculation();
		}

		public void increaseDiscountPercent(uint discount = 10)
		{
			mDiscountPercent = mDiscountPercent + discount;

			if (mDiscountPercent > 100)
			{
				mDiscountPercent = 100;
			}

			recalculation();
		}

		public void decreaseDiscountPercent(uint discount = 10)
		{
			if (mDiscountPercent <= discount)
			{
				mDiscountPercent = 0;
			}
			else
			{
				mDiscountPercent = mDiscountPercent - discount;
			}

			recalculation();
		}

		public void setDiscountPrice(uint price)
		{
			mDiscountType = DiscountType.Price;
			mDiscountPrice = price;
			recalculation();
		}

		public void setDiscountPercent(uint discount = 10)
		{
			mDiscountType = DiscountType.Percent;

			if (discount > 100)
			{
				mDiscountPercent = 100;
			}
			else
			{
				mDiscountPercent = discount;
			}

			recalculation();
		}

		public void setEnuriPrice(uint price)
		{
			mEnuriPrice = price;
			recalculation();
		}

		public uint getTotalPrice()
		{
			return mTotalPrice;
		}

		public uint getSubTotalPrice()
		{
			return mSubTotalPrice;
		}

		public uint getDiscountPercent()
		{
			return mDiscountPercent;
		}

		public uint getDiscountPrice()
		{
			return mDiscountPrice;
		}

		public uint getEnuriPrice()
		{
			return mEnuriPrice;
		}

		public uint getEnuriPercent()
		{
			return mEnuriPercent;
		}

		private void recalculation()
		{
			mSubTotalPrice = mItem.getPrice() * mQuantity;

			switch (mDiscountType)
			{
				case DiscountType.Percent:
					{
						if (mDiscountPercent != 0)
						{
							mDiscountPrice = (uint)((float)mDiscountPercent * (float)mSubTotalPrice / 100.0);
						}
						else
						{
							mDiscountPrice = 0;
						}

						break;
					}
				case DiscountType.Price:
					{
						if (mDiscountPrice != 0)
						{
							mDiscountPercent = (uint)((float)mDiscountPrice / (float)mSubTotalPrice * 100);
						}
						else
						{
							mDiscountPercent = 0;
						}

						break;
					}
				case DiscountType.Custom:
					{
						break;
					}
				default:
					{
						mDiscountPrice = 0;
						mDiscountPercent = 0;
						break;
					}
			}

			mEnuriPercent = (uint)((float)mEnuriPrice / (float)mSubTotalPrice * 100);
			mTotalPrice = mSubTotalPrice - mDiscountPrice - mEnuriPrice;
		}
	}
}
