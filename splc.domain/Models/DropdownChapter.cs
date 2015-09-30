using System;
using System.Collections.Generic;
using System.Linq;

namespace splc.domain.Models
{
    public class DropdownChapter
    {
        public int Id { get; set; }
        public string label { get; set; }
    }

    public class DropdownChapters
    {
        public int Id { get; set; }
        public IQueryable<DropdownChapter> DropDownChapters { get; set; }
    }
}
