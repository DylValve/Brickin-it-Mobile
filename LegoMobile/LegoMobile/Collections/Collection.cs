using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile.Collections
{
    /// <summary>
    /// Collection Class
    /// </summary>
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User_Id { get; set; }

        /// <summary>
        /// constracter with below parametra
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="user_id"></param>
        public Collection(int id, string name, int user_id)
        {
            Id = id;
            Name = name;
            User_Id = user_id;
        }
    }
}
