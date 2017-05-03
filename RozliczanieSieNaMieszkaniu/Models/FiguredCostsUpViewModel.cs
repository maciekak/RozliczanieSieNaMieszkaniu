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
        public decimal HowMuch { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as FiguredCostsUpViewModel);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Who?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Whom?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ HowMuch.GetHashCode();
                return hashCode;
            }
        }

        protected bool Equals(FiguredCostsUpViewModel other)
        {
            return string.Equals(Who, other.Who) && string.Equals(Whom, other.Whom) 
                && (HowMuch == other.HowMuch && HowMuch == other.HowMuch);
        }
    }
}