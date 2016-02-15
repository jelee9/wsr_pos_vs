using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsr_pos
{
	public class Category
	{
		private uint mId;
		private string mName;

		public Category(uint id = 0, string name = "")
		{
			mId = id;
			mName = name;
		}

		public uint getId()
		{
			return mId;
		}

		public void setId(uint id)
		{
			mId = id;
		}

		public string getName()
		{
			return mName;
		}

		public void setName(string name)
		{
			mName = name;
		}
	}
}
