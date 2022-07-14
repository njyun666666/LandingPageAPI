using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbSectionType
    {
        public TbSectionType()
        {
            TbFooterSettings = new HashSet<TbFooterSetting>();
        }

        public string SectionTypeId { get; set; } = null!;

        public virtual ICollection<TbFooterSetting> TbFooterSettings { get; set; }
    }
}
