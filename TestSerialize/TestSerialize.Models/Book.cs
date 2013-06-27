using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSerialize.Models
{
    public class Book
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public bool IsNew { get; set; }

        public string Url { get; set; }
    }
}
