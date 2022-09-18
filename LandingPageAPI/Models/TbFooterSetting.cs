using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbFooterSetting
    {
        public int FooterId { get; set; }
        public int SectionId { get; set; }
        public bool Enable { get; set; }

        public virtual TbSectionSetting Section { get; set; } = null!;
    }
}
