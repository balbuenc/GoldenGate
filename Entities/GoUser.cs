using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Entities
{
    public class GoUser
    {
        public string user { get; set; }
        public string status { get; set; }
        public bool authorized { get; set; }

        public string observations { get; set; }

        public string key { get; set; }
    }
}
