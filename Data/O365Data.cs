using System;
using System.Linq;
using System.Threading.Tasks;

namespace blazor_base.Data
{
    public class O365Data
    {
        public int MsgNum { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Centroid { get; set; } // eg this msg belongs to which group/centroid?

        O365Data()
        {

        }
    }
}