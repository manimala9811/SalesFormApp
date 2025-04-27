using System;
using System.Collections.Generic;

namespace SalesFormApp.Models
{
    public class SalesDetail
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public List<SalesItem> SalesItems { get; set; } = new();
    }
}