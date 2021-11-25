using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile.Collections
{
    class CollectionSet
    {
        public int Id { get; set; }
        public int SetId { get; set; }
        public int CollectionId { get; set; }

        public CollectionSet(int id, int set_id, int collection_id)
        {
            Id = id;
            SetId = set_id;
            CollectionId = collection_id;
        }
    }
}
