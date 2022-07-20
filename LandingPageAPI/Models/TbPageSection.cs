using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbPageSection
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public int SectionId { get; set; }
        public int Sort { get; set; }

        public virtual TbPage Page { get; set; } = null!;
        public virtual TbSectionSetting Section { get; set; } = null!;
    }
}
