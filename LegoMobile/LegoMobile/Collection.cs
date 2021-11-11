using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User_Id { get; set; }

        public Collection (int id, string name, int user_id)
        {
            Id = id;
            Name = name;
            User_Id = user_id;
        }
    }
}
