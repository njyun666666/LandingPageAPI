using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbItem
    {
        public int ItemId { get; set; }
        public string? ItemGroupId { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Content { get; set; }
        public string? Icon { get; set; }
        public string? ImageUrl { get; set; }
        public string? Url { get; set; }
        public string? Target { get; set; }
        public float? Number { get; set; }
        public int? Sort { get; set; }
        public bool? Enable { get; set; }
    }
}
