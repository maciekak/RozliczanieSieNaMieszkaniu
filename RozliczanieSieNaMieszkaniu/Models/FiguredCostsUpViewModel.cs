using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RozliczanieSieNaMieszkaniu.Models
{
    public class FiguredCostsUpViewModel
    {
        public string Who { get; set; }
        public string Whom { get; set; }
        public decimal HowMany { get; set; }
    }
}