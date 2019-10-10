using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreSample
{
    public class Book
    {
        public int BookId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        public string? Publisher { get; set; }
        public string? Isbn { get; set; }
    }
}
