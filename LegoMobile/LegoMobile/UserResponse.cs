using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile
{
    public class UserResponse
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public string message { get; set; }

        public class Data
        {
            public int id { get; set; }
            public string token { get; set; }
            public string name { get; set; }
            public string error { get; set; }
        }
    }
}
