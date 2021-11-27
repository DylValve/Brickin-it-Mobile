using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile.Collections
{
    class CollectionSet
    {
        /// <summary>
        /// CollectionSet Class
        /// </summary>
        public int Id { get; set; }
        public int SetId { get; set; }
        public int CollectionId { get; set; }
        /// <summary>
        ///  constracter with below parametra
        /// </summary>
        /// <param name="id"></param>
        /// <param name="set_id"></param>
        /// <param name="collection_id"></param>
        public CollectionSet(int id, int set_id, int collection_id)
        {
            Id = id;
            SetId = set_id;
            CollectionId = collection_id;
        }
    }
}
