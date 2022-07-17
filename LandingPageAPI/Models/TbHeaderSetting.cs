using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbHeaderSetting
    {
        public int HeaderId { get; set; }
        public int? MenuGroupId { get; set; }
        public string? Logo { get; set; }
        public bool Enable { get; set; }
    }
}
