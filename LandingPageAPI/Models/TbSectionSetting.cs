using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbSectionSetting
    {
        public TbSectionSetting()
        {
            TbPageSections = new HashSet<TbPageSection>();
        }

        public int SectionId { get; set; }
        public string SectionTypeId { get; set; } = null!;
        public string? BackgroundImage { get; set; }
        public string? BackgroundColor { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Content { get; set; }
        public string? ParticleIcon { get; set; }
        public int? Item1 { get; set; }
        public int? Item2 { get; set; }

        public virtual TbItemGroup? Item1Navigation { get; set; }
        public virtual TbItemGroup? Item2Navigation { get; set; }
        public virtual ICollection<TbPageSection> TbPageSections { get; set; }
    }
}
