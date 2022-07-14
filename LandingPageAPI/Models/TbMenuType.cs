using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbMenuType
    {
        public TbMenuType()
        {
            TbMenus = new HashSet<TbMenu>();
        }

        public string MenuTypeId { get; set; } = null!;

        public virtual ICollection<TbMenu> TbMenus { get; set; }
    }
}
