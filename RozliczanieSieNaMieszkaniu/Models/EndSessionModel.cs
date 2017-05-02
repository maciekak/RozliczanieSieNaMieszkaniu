using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RozliczanieSieNaMieszkaniu.Models
{
    public class EndSessionModel
    {
        [Key]
        [ForeignKey("Session")]
        public int SessionId { get; set; }

        [Required]
        public string Who { get; set; }

        [Required]
        public string Whom { get; set; }

        [Required]
        public decimal HowMuch { get; set; }

        [Required]
        public bool Realized { get; set; }

        public virtual SessionModel Session { get; set; }
    }
}