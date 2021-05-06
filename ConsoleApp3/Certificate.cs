using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Certificate
    {
        public string Subject { get; set; }
        public object IssuerName { get; set; }
        public DateTime certStartDate { get; set; }
        public DateTime certEndDate { get; set; }
        public string SerialNumber { get; set; }
        public object PublicKey { get; set; }
        public object Version { get; set; }
        public string ThumbPrint { get; set; }
  


    }
}
