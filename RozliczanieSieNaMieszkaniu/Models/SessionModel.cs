using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace RozliczanieSieNaMieszkaniu.Models
{
    public class SessionModel
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<EntryModel> Entries { get; set; }



    }
}