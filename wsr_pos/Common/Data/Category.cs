using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsr_pos
{
	class Category
	{
		private uint mId;
		private string mName;

		public Category(string name)
		{
			mName = name;
		}

		public string getName()
		{
			return mName;
		}

		public void setname(string name)
		{
			mName = name;
		}
	}
}
