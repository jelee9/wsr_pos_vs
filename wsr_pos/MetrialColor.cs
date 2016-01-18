using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace wsr_pos
{
    class MetrialColor
    {
		public enum Name
		{
			Red,
			Pink,
			Purple,
			DeepPurple,
			Indigo,
			Blue,
			LightBlue,
			Cyan,
			Teal,
			Green,
			LightGreen,
			Lime,
			Yellow,
			Amber,
			Orange,
			DeepOrange,
			Brown,
			Grey,
			BlueGrey,
			Black,
			White,
		};

        private static string[] RED			= {"#FFFFCDD2","#FFEF9A9A","#FFE57373","#FFEF5350","#FFF44336","#FFE53935","#FFD32F2F","#FFC62828","#FFB71C1C",};
		private static string[] PINK		= {"#FFF8BBD0","#FFF48FB1","#FFF06292","#FFEC407A","#FFE91E63","#FFD81B60","#FFC2185B","#FFAD1457","#FF880E4F",};
		private static string[] PURPLE		= {"#FFE1BEE7","#FFCE93D8","#FFBA68C8","#FFAB47BC","#FF9C27B0","#FF8E24AA","#FF7B1FA2","#FF6A1B9A","#FF4A148C",};
		private static string[] DEEP_PURPLE	= {"#FFD1C4E9","#FFB39DDB","#FF9575CD","#FF7E57C2","#FF673AB7","#FF5E35B1","#FF512DA8","#FF4527A0","#FF311B92",};
		private static string[] INDIGO		= {"#FFC5CAE9","#FF9FA8DA","#FF7986CB","#FF5C6BC0","#FF3F51B5","#FF3949AB","#FF303F9F","#FF283593","#FF1A237E",};
		private static string[] BLUE		= {"#FFBBDEFB","#FF90CAF9","#FF64B5F6","#FF42A5F5","#FF2196F3","#FF1E88E5","#FF1976D2","#FF1565C0","#FF0D47A1",};
		private static string[] LIGHT_BLUE	= {"#FFB3E5FC","#FF81D4fA","#FF4fC3F7","#FF29B6FC","#FF03A9F4","#FF039BE5","#FF0288D1","#FF0277BD","#FF01579B",};
		private static string[] CYAN		= {"#FFB2EBF2","#FF80DEEA","#FF4DD0E1","#FF26C6DA","#FF00BCD4","#FF00ACC1","#FF0097A7","#FF00838F","#FF006064",};
		private static string[] TEAL		= {"#FFB2DFDB","#FF80CBC4","#FF4DB6AC","#FF26A69A","#FF009688","#FF00897B","#FF00796B","#FF00695C","#FF004D40",};
		private static string[] GREEN		= {"#FFC8E6C9","#FFA5D6A7","#FF81C784","#FF66BB6A","#FF4CAF50","#FF43A047","#FF388E3C","#FF2E7D32","#FF1B5E20",};
		private static string[] LIGHT_GREEN	= {"#FFDCEDC8","#FFC5E1A5","#FFAED581","#FF9CCC65","#FF8BC34A","#FF7CB342","#FF689F38","#FF558B2F","#FF33691E",};
		private static string[] LIME		= {"#FFF0F4C3","#FFE6EE9C","#FFDCE775","#FFD4E157","#FFCDDC39","#FFC0CA33","#FFA4B42B","#FF9E9D24","#FF827717",};
		private static string[] YELLOW		= {"#FFFFF9C4","#FFFFF590","#FFFFF176","#FFFFEE58","#FFFFEB3B","#FFFDD835","#FFFBC02D","#FFF9A825","#FFF57F17",};
		private static string[] AMBER		= {"#FFFFECB3","#FFFFE082","#FFFFD54F","#FFFFCA28","#FFFFC107","#FFFFB300","#FFFFA000","#FFFF8F00","#FFFF6F00",};
		private static string[] ORANGE		= {"#FFFFE0B2","#FFFFCC80","#FFFFB74D","#FFFFA726","#FFFF9800","#FFFB8C00","#FFF57C00","#FFEF6C00","#FFE65100",};
		private static string[] DEEP_ORANGE	= {"#FFFFCCBC","#FFFFAB91","#FFFF8A65","#FFFF7043","#FFFF5722","#FFF4511E","#FFE64A19","#FFD84315","#FFBF360C",};
		private static string[] BROWN		= {"#FFD7CCC8","#FFBCAAA4","#FFA1887F","#FF8D6E63","#FF795548","#FF6D4C41","#FF5D4037","#FF4E342E","#FF3E2723",};
		private static string[] GREY		= {"#FFF5F5F5","#FFEEEEEE","#FFE0E0E0","#FFBDBDBD","#FF9E9E9E","#FF757575","#FF616161","#FF424242","#FF212121",};
		private static string[] BLUE_GREY	= {"#FFCFD8DC","#FFB0BBC5","#FF90A4AE","#FF78909C","#FF607D8B","#FF546E7A","#FF455A64","#FF37474F","#FF263238",};

		public static Brush getBrush(Name name, int num = 4)
		{
			var converter = new System.Windows.Media.BrushConverter();

			switch(name)
			{
				case Name.Red:			return (Brush)converter.ConvertFromString(RED[num]);
				case Name.Pink:			return (Brush)converter.ConvertFromString(PINK[num]);
				case Name.Purple:		return (Brush)converter.ConvertFromString(PURPLE[num]);
				case Name.DeepPurple:	return (Brush)converter.ConvertFromString(DEEP_PURPLE[num]);
				case Name.Indigo:		return (Brush)converter.ConvertFromString(INDIGO[num]);
				case Name.Blue:			return (Brush)converter.ConvertFromString(BLUE[num]);
				case Name.LightBlue:	return (Brush)converter.ConvertFromString(LIGHT_BLUE[num]);
				case Name.Cyan:			return (Brush)converter.ConvertFromString(CYAN[num]);
				case Name.Teal:			return (Brush)converter.ConvertFromString(TEAL[num]);
				case Name.Green:		return (Brush)converter.ConvertFromString(GREEN[num]);
				case Name.LightGreen:	return (Brush)converter.ConvertFromString(LIGHT_GREEN[num]);
				case Name.Lime:			return (Brush)converter.ConvertFromString(LIME[num]);
				case Name.Yellow:		return (Brush)converter.ConvertFromString(YELLOW[num]);
				case Name.Amber:		return (Brush)converter.ConvertFromString(AMBER[num]);
				case Name.Orange:		return (Brush)converter.ConvertFromString(ORANGE[num]);
				case Name.DeepOrange:	return (Brush)converter.ConvertFromString(DEEP_ORANGE[num]);
				case Name.Brown:		return (Brush)converter.ConvertFromString(BROWN[num]);
				case Name.Grey:			return (Brush)converter.ConvertFromString(GREY[num]);
				case Name.BlueGrey:		return (Brush)converter.ConvertFromString(BLUE_GREY[num]);
				case Name.Black:		return (Brush)converter.ConvertFromString("#FF000000");
			}

			return (Brush)converter.ConvertFromString("#FFFFFFFF");
		}
    }
}
