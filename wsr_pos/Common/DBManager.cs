using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsr_pos
{
	class DBManager
	{
		public static string DB_FILE_NAME = @"Data Source=./WSR_POS.db";

		private static DBManager mInstance;
		private SQLiteConnection mConnection;

		private List<Item> mItemList;
		private List<ItemLayout> mItemLayoutList;

		private DBManager()
		{
			mConnection = new SQLiteConnection(DB_FILE_NAME);
			mConnection.Open();

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
							position_x INTEGER,
							position_y INTEGER,
							color INTEGER,
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
										color INTEGER";
			SQLiteCommand item_layout_cmd = new SQLiteCommand(item_layout_query, mConnection);
			item_layout_cmd.ExecuteNonQuery();
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
				item.setPositionX((uint)(dr["position_x"]));
				item.setPositionY((uint)(dr["position_y"]));
				item.setColorName(MetrialColor.getName((uint)(dr["color"])));

				mItemList.Add(item);
			}
		}

		public List<Item> getItemList()
		{
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
			return mItemLayoutList;
		}

		public void addItem(Item item)
		{
			Dictionary<string, string> set_data = new Dictionary<string, string>();
			set_data.Add("enable", "0");
			set_data.Add("delete_time", DateTime.Now.Ticks.ToString());

			Dictionary<string, string> where_data = new Dictionary<string, string>();
			where_data.Add("position_x", item.getPositionX().ToString());
			where_data.Add("position_y", item.getPositionY().ToString());
			where_data.Add("enable", "1");

			update("item", set_data, where_data);

			Dictionary<string, string> insert_data = new Dictionary<string, string>();
			insert_data.Add("category_id", item.getCategoryId().ToString());
			insert_data.Add("name", item.getName());
			insert_data.Add("comment", item.getComment());
			insert_data.Add("price", item.getPrice().ToString());
			insert_data.Add("discount", (item.getDiscount() ? 1 : 0).ToString());
			insert_data.Add("print", (item.getPrint() ? 1 : 0).ToString());
			insert_data.Add("print_together", (item.getPrintTogether() ? 1 : 0).ToString());
			insert_data.Add("position_x", item.getPositionX().ToString());
			insert_data.Add("position_y", item.getPositionY().ToString());
			insert_data.Add("color", Convert.ToInt32(item.getColorName()).ToString());
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
	}
}

