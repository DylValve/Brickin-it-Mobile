using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile.Sets
{   /// <summary>
    /// class Set 
    /// </summary>
     public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SetNumber { get; set; }
        public string Picture { get; set; }
        public int themeId { get; set; }

        public string Barcode { get; set; }


        public Set()
        {

        }
        /// <summary>
        /// constracter with below parametra
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="set_number"></param>
        /// <param name="picture"></param>
        /// <param name="theme_id"></param>
        /// <param name="barcode"></param>
        public Set(int id, string name, string set_number, string picture, int theme_id, string barcode)
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
