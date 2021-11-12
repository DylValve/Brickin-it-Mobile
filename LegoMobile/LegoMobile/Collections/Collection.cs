using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile.Collections
{
    public class Collection
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int User_Id { get; set; }

        public Collection(int id, string name, int user_id)
        {
            ID = id;
            Name = name;
            User_Id = user_id;
        }

    }
}
