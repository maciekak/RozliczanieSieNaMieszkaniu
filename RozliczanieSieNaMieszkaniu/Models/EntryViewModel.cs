using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RozliczanieSieNaMieszkaniu.Models
{
    public class EntryViewModel
    {
        public string UserName { get; set; }
        public string What { get; set; }
        
//        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
//        [RegularExpression("^[0-9]([.,][0-9]{1,3})?$", ErrorMessage = "Uncorrect amount")]
        [DataType(DataType.Currency, ErrorMessage = "Uncorrect amount")]
        public decimal Price { get; set; }

    }
}