using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbFooterSetting
    {
        public int FooterId { get; set; }
        public string? SectionTypeId { get; set; }
        public string? Logo { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? CopyRight { get; set; }
        public string? Item1 { get; set; }

        public virtual TbSectionType? SectionType { get; set; }
    }
}
