using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RozliczanieSieNaMieszkaniu.Models
{
    public class EntriesViewModel
    {
        public List<EntryViewModel> EntryList { get; set; }

        public EntryViewModel NewEntry { get; set; }

    }
}