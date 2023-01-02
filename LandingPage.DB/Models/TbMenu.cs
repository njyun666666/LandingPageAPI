using System;
using System.Collections.Generic;

namespace LandingPageDB.Models
{
    public partial class TbMenu
    {
        public int MenuId { get; set; }
        public int? MenuParentId { get; set; }
        public int? MenuGroupId { get; set; }
        public string? MenuTypeId { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Url { get; set; }
        public string? Target { get; set; }
        public string? Icon { get; set; }
        public string? ImageUrl { get; set; }
        public bool Enable { get; set; }
        public int Sort { get; set; }

        public virtual TbMenuType? MenuType { get; set; }
    }
}
