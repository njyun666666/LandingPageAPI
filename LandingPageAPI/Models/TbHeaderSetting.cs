using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbHeaderSetting
    {
        public int HeaderId { get; set; }
        public int? MenuId { get; set; }
        public string? Logo { get; set; }

        public virtual TbMenu? Menu { get; set; }
    }
}
