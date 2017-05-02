using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RozliczanieSieNaMieszkaniu.Models
{
    public class EntryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string What { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("Session")]
        public int SessionId { get; set; }
        
        public virtual SessionModel Session { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("User")]
        public string ApplicationUserId { get; set; }
    }
}