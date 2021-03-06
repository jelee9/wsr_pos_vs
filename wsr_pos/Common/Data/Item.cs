﻿using System.Collections.Generic;

namespace wsr_pos
{
	public class Item
	{
		private uint mCategoryId;
		private uint mId;
		private string mName;
		private string mComment;
		private uint mPrice;
		private bool mDiscount;
		private bool mPrint;
		private bool mPrintTogether;
		private bool mPrintDot;
		private List<uint> mSubItemIdList;

		public Item(uint category_id = 0, uint id = 0, string name = "", string comment = "", uint price = 0, bool discout = false, bool print = false, bool print_together = false, bool print_dot = false, List<uint> sub_item_id_list = null)
		{

			mCategoryId = category_id;
			mId = id;
			mName = name;
			mComment = comment;
			mPrice = price;
			mDiscount = discout;
			mPrint = print;
			mPrintTogether = print_together;
			mPrintDot = print_dot;
			mSubItemIdList = sub_item_id_list;
		}

		public uint getCategoryId()
		{
			return mCategoryId;
		}

		public uint getId()
		{
			return mId;
		}

		public string getName()
		{
			return mName;
		}

		public string getComment()
		{
			return mComment;
		}

		public uint getPrice()
		{
			return mPrice;
		}

		public bool getDiscount()
		{
			return mDiscount;
		}

		public bool getPrint()
		{
			return mPrint;
		}

		public bool getPrintTogether()
		{
			return mPrintTogether;
		}

		public bool getPrintDot()
		{
			return mPrintDot;
		}

		public List<uint> getSubItemIdList()
		{
			return mSubItemIdList;
		}

		public void setCategoryId(uint category_id)
		{
			mCategoryId = category_id;
		}

		public void setId(uint id)
		{
			mId = id;
		}

		public void setName(string name)
		{
			mName = name;
		}

		public void setComment(string comment)
		{
			mComment = comment;
		}

		public void setPrice(uint price)
		{
			mPrice = price;
		}

		public void setDiscount(bool discount)
		{
			mDiscount = discount;
		}

		public void setPrint(bool print)
		{
			mPrint = print;
		}

		public void setPrintTogether(bool print_together)
		{
			mPrintTogether = print_together;
		}

		public void setPrintDot(bool print_dot)
		{
			mPrintDot = print_dot;
		}

		public void setSubItemIdList(List<uint> sub_item_id_list)
		{
			mSubItemIdList = sub_item_id_list;
		}
	}
}
