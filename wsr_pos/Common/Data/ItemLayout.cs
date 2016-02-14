using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsr_pos
{
	public class ItemLayout
	{
		private uint mItemId;
		private Item mItem;
		private uint mId;
		private uint mPositionX;
		private uint mPositionY;
		private MetrialColor.Name mColorName;

		public ItemLayout(uint item_id = 0, uint id = 0, uint position_x = 0, uint position_y = 0, MetrialColor.Name color_name = MetrialColor.Name.Amber)
		{
			mItemId = item_id;
			mId = id;
			mPositionX = position_x;
			mPositionY = position_y;
			mColorName = color_name;

			findItem();
		}

		private void findItem()
		{
			List<Item> item_list = DBManager.getInstance().getItemList();

			foreach (Item item in item_list)
			{
				if(item.getId() == mItemId)
				{
					mItem = item;
				}
			}
		}

		public uint getItemId()
		{
			return mItemId;
		}

		public Item getItem()
		{
			return mItem;
		}

		public uint getId()
		{
			return mId;
		}

		public uint getPositionX()
		{
			return mPositionX;
		}

		public uint getPositionY()
		{
			return mPositionY;
		}

		public MetrialColor.Name getColorName()
		{
			return mColorName;
		}

		public void setItemId(uint item_id)
		{
			mItemId = item_id;
		}

		public void setId(uint id)
		{
			mId = id;
		}

		public void setPositionX(uint position_x)
		{
			mPositionX = position_x;
		}

		public void setPositionY(uint position_y)
		{
			mPositionY = position_y;
		}

		public void setColorName(MetrialColor.Name color_name)
		{
			mColorName = color_name;
		}
	}
}
