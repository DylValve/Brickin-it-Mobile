using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile
{
	class Set
	{
		public string Name { get; set; }
		public string SetNumber { get; set; }
		public string Picture { get; set; }
		public int themeId { get; set; }

		public Set(string name, string set_number, string picture, int theme_id)
		{
			Name = name;
			SetNumber = set_number;
			Picture = picture;
			themeId = theme_id;


		}
	}
}