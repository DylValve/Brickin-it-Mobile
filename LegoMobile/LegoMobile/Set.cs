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
        public int ThemeId { get; set; }

        public string Barcode { get; set; }

        public Set(int id, string name, string setNumber, string picture, int themeId, string barcode)
        {
            Id = id;
            Name = name;
            SetNumber = setNumber;
            Picture = picture;
            ThemeId = themeId;
            Barcode = barcode;
        }
    }
}
