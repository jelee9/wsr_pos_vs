using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsr_pos
{
	public class DBManager
	{
		public static readonly string DB_FILE_NAME = @"Data Source=./WSR_POS.db";

		private static DBManager mInstance;
		private SQLiteConnection mConnection;

		private List<Category> mCategoryList;
		private List<Item> mItemList;
		private List<ItemLayout> mItemLayoutList;

		private DBManager()
		{
			mConnection = new SQLiteConnection(DB_FILE_NAME);
			mConnection.Open();

			mCategoryList = new List<Category>();
			mItemList = new List<Item>();
			mItemLayoutList = new List<ItemLayout>();
			createDB();
		}

		public static DBManager getInstance()
		{
			if(mInstance == null)
			{
				mInstance = new DBManager();
			}

			return mInstance;
		}

		private void createDB()
		{
			string category_query = @"CREATE TABLE IF NOT EXISTS category
									(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
									name TEXT,
									create_time INTEGER,
									delete_time INTEGER,
									enable INTEGER)";

			SQLiteCommand category_cmd = new SQLiteCommand(category_query, mConnection);
			category_cmd.ExecuteNonQuery();

			string item_query = @"CREATE TABLE IF NOT EXISTS item
							(category_id INTEGER,
							id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
							name TEXT,
							comment TEXT,
							price INTEGER,
							discount INTEGER,
							print INTEGER,
							print_together INTEGER,
							print_dot INTEGER,
							sub_item_list TEXT,
							create_time INTEGER,
							delete_time INTEGER,
							enable INTEGER)";

			SQLiteCommand item_cmd = new SQLiteCommand(item_query, mConnection);
			item_cmd.ExecuteNonQuery();

			string item_layout_query = @"CREATE TABLE IF NOT EXISTS item_layout
										(item_id INTEGER,
										id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
			                            position_x INTEGER,
										position_y INTEGER,
										color INTEGER,
										create_time INTEGER,
										delete_time INTEGER,
										enable INTEGER)";
			SQLiteCommand item_layout_cmd = new SQLiteCommand(item_layout_query, mConnection);
			item_layout_cmd.ExecuteNonQuery();

			string order_summary_query = @"CREATE TABLE IF NOT EXISTS order_summary
									(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
									sub_total_price INTEGER,
									discount_price INTEGER,
									discount_percent INTEGER,
									enuri_price INTEGER,
									enuri_percent INTEGER,
									total_price INTEGER,
									total_percent INTEGER,
									payment_method INTEGER,
									create_time INTEGER)";
			SQLiteCommand order_summary_cmd = new SQLiteCommand(order_summary_query, mConnection);
			order_summary_cmd.ExecuteNonQuery();

			string order_item_query = @"CREATE TABLE IF NOT EXISTS order_item
											(order_id INTEGER,
											item_id INTEGER,
											id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
											quantity INTEGER,
											sub_total_price INTEGER,
											discount_type INTEGER,
											discount_price INTEGER,
											discount_percent INTEGER,
											enuri_price INTEGER,
											enuri_percent INTEGER,
											total_price INTEGER, 
											total_percent INTEGER)";
			SQLiteCommand order_item_cmd = new SQLiteCommand(order_item_query, mConnection);
			order_item_cmd.ExecuteNonQuery();

			string pension_query = @"CREATE TABLE IF NOT EXISTS pension
									(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
									name TEXT,
									create_time INTEGER,
									delete_time INTEGER,
									enable INTEGER)";
			SQLiteCommand pension_cmd = new SQLiteCommand(pension_query, mConnection);
			pension_cmd.ExecuteNonQuery();
		}

		private bool insert(string tableName, Dictionary<string, string> data)
		{
			string columns = "";
			string values = "";
			Boolean returnCode = true;

			foreach (KeyValuePair<string, string> val in data)
			{
				columns += string.Format(" {0},", val.Key.ToString());
				values += string.Format(" '{0}',", val.Value);
			}

			columns = columns.Substring(0, columns.Length - 1);
			values = values.Substring(0, values.Length - 1);

			try
			{
				executeNonQuery(string.Format("INSERT INTO {0} ({1}) VALUES ({2});", tableName, columns, values));
			}
			catch(Exception e)
			{
				Debug.Print(e.Message);
				returnCode = false;
			}

			return returnCode;
		}

		private bool update(string tableName, Dictionary<string, string> set_data, Dictionary<string, string> where_data)
		{
			string set_data_string = "";
			string where_data_string = "";
			Boolean return_code = true;

			if (set_data.Count >= 1)
			{
				foreach (KeyValuePair<string, string> item in set_data)
				{
					set_data_string += string.Format(" {0} = '{1}',", item.Key.ToString(), item.Value.ToString());
				}
				set_data_string = set_data_string.Substring(0, set_data_string.Length - 1);
			}
			if(where_data.Count >= 1)
			{
				foreach (KeyValuePair<string, string> item in where_data)
				{
					where_data_string += string.Format(" {0} = '{1}' AND", item.Key.ToString(), item.Value.ToString());
				}
				where_data_string = where_data_string.Substring(0, where_data_string.Length - 4);
			}
			try
			{
				executeNonQuery(string.Format("UPDATE {0} SET {1} WHERE {2};", tableName, set_data_string, where_data_string));
			}
			catch(Exception e)
			{
				Debug.Print(e.Message);
				return_code = false;
			}

			return return_code;
		}

		private int executeNonQuery(string query)
		{
			SQLiteConnection conn = new SQLiteConnection(DB_FILE_NAME);
			conn.Open();

			SQLiteCommand mycommand = new SQLiteCommand(query, conn);
			int rowsUpdated = mycommand.ExecuteNonQuery();

			conn.Close();

			return rowsUpdated;
		}
		private SQLiteDataReader executeReader(string query)
		{
			SQLiteConnection conn = new SQLiteConnection(DB_FILE_NAME);
			conn.Open();

			SQLiteCommand mycommand = new SQLiteCommand(query, conn);
			SQLiteDataReader date_reader = mycommand.ExecuteReader();

			conn.Close();

			return date_reader;
		}

		private void updateCategoryList()
		{
			mCategoryList.Clear();

			string query = @"SELECT * FROM category WHERE enable=1";

			SQLiteCommand cmd = new SQLiteCommand(query, mConnection);
			SQLiteDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Category category = new Category();
				category.setId((uint)(dr["id"]));
				category.setName((string)(dr["name"]));

				mCategoryList.Add(category);
			}
		}

		public List<Category> getCategoryList()
		{
			mCategoryList.Clear();
			setTestCategoryData();
			return mCategoryList;
		}

		private void updateItemList()
		{
			mItemList.Clear();

			string query = @"SELECT * FROM item WHERE enable=1";

			SQLiteCommand cmd = new SQLiteCommand(query, mConnection);
			SQLiteDataReader dr = cmd.ExecuteReader();

			while(dr.Read())
			{
				Item item = new Item();
				item.setCategoryId((uint)(dr["category_id"]));
				item.setId((uint)(dr["id"]));
				item.setName((string)(dr["name"]));
				item.setComment((string)(dr["comment"]));
				item.setPrice((uint)(dr["price"]));
				item.setDiscount(((uint)dr["discount"] == 1 ? true : false));
				item.setPrint(((uint)dr["print"] == 1 ? true : false));
				item.setPrintTogether(((uint)dr["print_together"] == 1 ? true : false));
				item.setPrintDot(((uint)dr["print_dot"] == 1 ? true : false));

				mItemList.Add(item);
			}
		}

		public List<Item> getItemList()
		{
			mItemList.Clear();
			setTestItemData();
			return mItemList;
		}

		public void updateItemLayoutList()
		{
			mItemLayoutList.Clear();

			string query = @"SELECT * FROM item WHERE enable=1";

			SQLiteCommand cmd = new SQLiteCommand(query, mConnection);
			SQLiteDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				ItemLayout item_layout = new ItemLayout();
				item_layout.setItemId((uint)(dr["item_id"]));
				item_layout.setId((uint)(dr["id"]));
				item_layout.setPositionX((uint)(dr["position_x"]));
				item_layout.setPositionY((uint)(dr["position_y"]));
				item_layout.setColorName(MetrialColor.getName((uint)(dr["color"])));

				mItemLayoutList.Add(item_layout);
			}
		}

		public List<ItemLayout> getItemLayoutList()
		{
			mItemLayoutList.Clear();
			setTestItemLayoutData();
			return mItemLayoutList;
		}

		public void addItem(Item item)
		{
			Dictionary<string, string> insert_data = new Dictionary<string, string>();
			insert_data.Add("category_id", item.getCategoryId().ToString());
			insert_data.Add("name", item.getName());
			insert_data.Add("comment", item.getComment());
			insert_data.Add("price", item.getPrice().ToString());
			insert_data.Add("discount", (item.getDiscount() ? 1 : 0).ToString());
			insert_data.Add("print", (item.getPrint() ? 1 : 0).ToString());
			insert_data.Add("print_together", (item.getPrintTogether() ? 1 : 0).ToString());
			insert_data.Add("print_dot", (item.getPrintDot() ? 1 : 0).ToString());
			insert_data.Add("create_time", DateTime.Now.Ticks.ToString());

			insert("item", insert_data);

			updateItemList();
		}

		public void deleteItem(Item item)
		{
			Dictionary<string, string> set_data = new Dictionary<string, string>();
			set_data.Add("enable", "0");
			set_data.Add("delete_time", DateTime.Now.Ticks.ToString());

			Dictionary<string, string> where_data = new Dictionary<string, string>();
			where_data.Add("id", item.getId().ToString());

			update("item", set_data, where_data);
		}

		public void addItemLayout(ItemLayout item_layout)
		{
			Dictionary<string, string> set_data = new Dictionary<string, string>();
			set_data.Add("enable", "0");
			set_data.Add("delete_time", DateTime.Now.Ticks.ToString());

			Dictionary<string, string> where_data = new Dictionary<string, string>();
			where_data.Add("position_x", item_layout.getPositionX().ToString());
			where_data.Add("position_y", item_layout.getPositionY().ToString());
			where_data.Add("enable", "1");

			update("item_layout", set_data, where_data);

			Dictionary<string, string> insert_data = new Dictionary<string, string>();
			insert_data.Add("category_id", item_layout.getItemId().ToString());
			insert_data.Add("position_x", item_layout.getPositionX().ToString());
			insert_data.Add("position_y", item_layout.getPositionY().ToString());
			insert_data.Add("color", Convert.ToInt32(item_layout.getColorName()).ToString());
			insert_data.Add("create_time", DateTime.Now.Ticks.ToString());

			insert("item_layout", insert_data);

			updateItemLayoutList();
		}

		public void deleteItemLayout(ItemLayout item_layout)
		{
			Dictionary<string, string> set_data = new Dictionary<string, string>();
			set_data.Add("enable", "0");
			set_data.Add("delete_time", DateTime.Now.Ticks.ToString());

			Dictionary<string, string> where_data = new Dictionary<string, string>();
			where_data.Add("id", item_layout.getId().ToString());

			update("item_layout", set_data, where_data);
		}

		public void setTestCategoryData()
		{
			Category category01 = new Category(1, "레포츠");
			Category category02 = new Category(2, "물놀이");
			Category category03 = new Category(3, "패키지");

			mCategoryList.Add(category01);
			mCategoryList.Add(category02);
			mCategoryList.Add(category03);
		}

		public void setTestItemData()
		{
			Item item01 = new Item(1, 01, "수상스키", "", 25000, true, false, false, false);
			Item item02 = new Item(1, 02, "수상스키(초보)", "", 60000, true, false, false, false);
			Item item03 = new Item(1, 03, "웨이크보드", "", 25000, true, false, false, false);
			Item item04 = new Item(1, 04, "웨이크보드(초보)", "", 60000, true, false, false, false);

			Item item05 = new Item(2, 05, "바나나보트", "", 20000, true, false, false, false);
			Item item06 = new Item(2, 06, "밴드 웨곤", "", 20000, true, false, false, false);
			Item item07 = new Item(2, 07, "더블땅콩", "", 25000, true, false, false, false);
			Item item08 = new Item(2, 08, "디스코팡팡", "", 25000, true, false, false, false);
			Item item09 = new Item(2, 09, "뉴 디스코팡팡", "", 25000, true, false, false, false);
			Item item10 = new Item(2, 10, "헥사곤", "", 25000, true, false, false, false);
			Item item11 = new Item(2, 11, "마블", "", 25000, true, false, false, false);
			Item item12 = new Item(2, 12, "날으는 바나나", "", 25000, true, false, false, false);

			Item item13 = new Item(2, 13, "보팅 (A)", "바나나보트/밴드 웨곤/뉴 디스코팡팡/날으는 바나나", 50000, true, false, false, false);
			Item item14 = new Item(2, 14, "보팅 (B)", "", 100000, true, false, false, false);
			Item item15 = new Item(2, 15, "보팅 (C)", "수상스키(초보)/날으는 바나나/날으는 바나나", 150000, true, false, false, false);


			Item item16 = new Item(3, 16, "물놀이 패키지 1", "마블/바나나/밴드웨곤 2종", 28000, false, false, false, false);
			Item item17 = new Item(3, 17, "물놀이 패키지 2", "물놀이 2종", 30000, false, false, false, false);
			Item item18 = new Item(3, 18, "물놀이 패키지 3", "물놀이 3종", 45500, false, false, false, false);
			Item item19 = new Item(3, 19, "물놀이 패키지 4", "물놀이 4종", 59500, false, false, false, false);
			Item item20 = new Item(3, 20, "수상 패키지 1", "수상스키 2회 + 물놀이", 61000, false, false, false, false);
			Item item21 = new Item(3, 21, "수상 패키지 2", "수상스키 2회 + 물놀이 2종", 73500, false, false, false, false);

			mItemList.Add(item01);
			mItemList.Add(item02);
			mItemList.Add(item03);
			mItemList.Add(item04);
			mItemList.Add(item05);
			mItemList.Add(item06);
			mItemList.Add(item07);
			mItemList.Add(item08);
			mItemList.Add(item09);
			mItemList.Add(item10);
			mItemList.Add(item11);
			mItemList.Add(item12);
			mItemList.Add(item13);
			mItemList.Add(item14);
			mItemList.Add(item15);
			mItemList.Add(item16);
			mItemList.Add(item17);
			mItemList.Add(item18);
			mItemList.Add(item19);
			mItemList.Add(item20);
			mItemList.Add(item21);
		}

		private void setTestItemLayoutData()
		{ 
			ItemLayout item_layout01 = new ItemLayout(01, 01, 0, 0, MetrialColor.Name.Amber);
			ItemLayout item_layout02 = new ItemLayout(02, 02, 1, 0, MetrialColor.Name.Amber);
			ItemLayout item_layout03 = new ItemLayout(03, 03, 0, 1, MetrialColor.Name.Amber);
			ItemLayout item_layout04 = new ItemLayout(04, 04, 1, 1, MetrialColor.Name.Amber);

			ItemLayout item_layout05 = new ItemLayout(05, 05, 2, 0, MetrialColor.Name.Blue);
			ItemLayout item_layout06 = new ItemLayout(06, 06, 3, 0, MetrialColor.Name.Blue);
			ItemLayout item_layout07 = new ItemLayout(07, 07, 4, 0, MetrialColor.Name.Blue);
			ItemLayout item_layout08 = new ItemLayout(08, 08, 5, 0, MetrialColor.Name.Blue);
			ItemLayout item_layout09 = new ItemLayout(09, 09, 2, 1, MetrialColor.Name.Blue);
			ItemLayout item_layout10 = new ItemLayout(10, 10, 3, 1, MetrialColor.Name.Blue);
			ItemLayout item_layout11 = new ItemLayout(11, 11, 4, 1, MetrialColor.Name.Blue);
			ItemLayout item_layout12 = new ItemLayout(12, 12, 5, 1, MetrialColor.Name.Blue);

			ItemLayout item_layout13 = new ItemLayout(13, 13, 2, 2, MetrialColor.Name.Amber);
			ItemLayout item_layout14 = new ItemLayout(14, 14, 3, 2, MetrialColor.Name.Amber);
			ItemLayout item_layout15 = new ItemLayout(15, 15, 4, 2, MetrialColor.Name.Amber);

			ItemLayout item_layout16 = new ItemLayout(16, 16, 6, 0, MetrialColor.Name.Amber);
			ItemLayout item_layout17 = new ItemLayout(17, 17, 7, 0, MetrialColor.Name.Amber);
			ItemLayout item_layout18 = new ItemLayout(18, 18, 6, 1, MetrialColor.Name.Amber);
			ItemLayout item_layout19 = new ItemLayout(19, 19, 7, 1, MetrialColor.Name.Amber);
			ItemLayout item_layout20 = new ItemLayout(20, 20, 6, 2, MetrialColor.Name.Amber);
			ItemLayout item_layout21 = new ItemLayout(21, 21, 7, 2, MetrialColor.Name.Amber);

			mItemLayoutList.Add(item_layout01);
			mItemLayoutList.Add(item_layout02);
			mItemLayoutList.Add(item_layout03);
			mItemLayoutList.Add(item_layout04);
			mItemLayoutList.Add(item_layout05);
			mItemLayoutList.Add(item_layout06);
			mItemLayoutList.Add(item_layout07);
			mItemLayoutList.Add(item_layout08);
			mItemLayoutList.Add(item_layout09);
			mItemLayoutList.Add(item_layout10);
			mItemLayoutList.Add(item_layout11);
			mItemLayoutList.Add(item_layout12);
			mItemLayoutList.Add(item_layout13);
			mItemLayoutList.Add(item_layout14);
			mItemLayoutList.Add(item_layout15);
			mItemLayoutList.Add(item_layout16);
			mItemLayoutList.Add(item_layout17);
			mItemLayoutList.Add(item_layout18);
			mItemLayoutList.Add(item_layout19);
			mItemLayoutList.Add(item_layout20);
			mItemLayoutList.Add(item_layout21);
		}
	}
}

