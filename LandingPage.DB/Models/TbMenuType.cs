using System;
using System.Collections.Generic;

namespace LandingPageDB.Models
{
    public partial class TbMenuType
    {
        public TbMenuType()
        {
            TbMenus = new HashSet<TbMenu>();
        }

        public string MenuTypeId { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<TbMenu> TbMenus { get; set; }
    }
}
