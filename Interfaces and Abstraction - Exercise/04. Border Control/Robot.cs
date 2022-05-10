using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Robot : IIdentifiable
    {
        public Robot(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
