using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile
{
	public class Set
	{ 
		public int Id { get; set; }
		public string Name { get; set; }
		public string SetNumber { get; set; }
		public string Picture { get; set; }
		public int themeId { get; set; }

		public string Barcode { get; set; }

		public Set(int id, string name, string set_number, string picture, int theme_id, string barcode )
		{
			Id = id;
			Name = name;
			SetNumber = set_number;
			Picture = picture;
			themeId = theme_id;
			Barcode = barcode;

		}
	}
}