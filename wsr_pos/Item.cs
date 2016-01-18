using System.Collections.Generic;

namespace wsr_pos
{
	class Item
	{
		private uint CategoryId {get; set; }
		private uint Id { get; set; }
		private string Name { get; set; }
		private string Comment { get; set; }
		private uint Price { get; set; }
		private bool Discount { get; set; }
		private bool Print { get; set; }
		private bool PrintTogether { get; set; }
		private uint PositionX { get; set; }
		private uint PositionY { get; set; }
		private MetrialColor.Name ColorName { get; set; }
		private List<uint> SubItemIdList { get; set; }

		Item(uint category_id = 0, uint id = 0, string name = "", string comment = "", uint price = 0, bool discout = false, bool print = false, bool print_together = false, uint position_x = 0, uint position_y = 0, MetrialColor.Name color_name = MetrialColor.Name.BlueGrey, List<uint> sub_item_id_list = null)
		{

			CategoryId = category_id;
			Id = id;
			Name = name;
			Comment = comment;
			Price = price;
			Discount = discout;
			Print = print;
			PrintTogether = print_together;
			PositionX = position_x;
			PositionY = position_y;
			ColorName = color_name;
			SubItemIdList = sub_item_id_list;
		}
	}
}
