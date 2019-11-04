using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkcoiAPI.Models
{
    public class DTO
    {
        public class ActionResultDto
        {
            public dynamic Error { set; get; } = null;
            public dynamic Result { set; get; } = null;
            public bool Success { set; get; } = true;
        }

        public class EtherscanModel
        {
            public int status { get; set; }
            public string message { get; set; }
            public string result { get; set; }
        }
    }
}
