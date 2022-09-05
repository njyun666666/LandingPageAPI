using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbItemGroup
    {
        public TbItemGroup()
        {
            TbItems = new HashSet<TbItem>();
            TbSectionSettingItem1Navigations = new HashSet<TbSectionSetting>();
            TbSectionSettingItem2Navigations = new HashSet<TbSectionSetting>();
        }

        public int ItemGroupId { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TbItem> TbItems { get; set; }
        public virtual ICollection<TbSectionSetting> TbSectionSettingItem1Navigations { get; set; }
        public virtual ICollection<TbSectionSetting> TbSectionSettingItem2Navigations { get; set; }
    }
}
