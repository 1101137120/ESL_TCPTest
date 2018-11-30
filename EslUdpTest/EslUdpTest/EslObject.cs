using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;

namespace EslUdpTest
{
    public class EslObject
    {
        public Socket workSocket = null;
        public SmcEsl mSmcEsl = new SmcEsl(null);
        public Stopwatch stopwatch = new Stopwatch();
    }

    public class ScanEslObject
    {
        public string mac = "null";
        public string battery = "null";
    }
    public class ErrorEslObject
    {
        public string mac = "null";
        public int error = 0;
    }

}
