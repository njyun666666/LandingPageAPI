using System;
using System.Collections.Generic;

namespace LandingPageAPI.Models
{
    public partial class TbPage
    {
        public TbPage()
        {
            TbPageSections = new HashSet<TbPageSection>();
        }

        public int PageId { get; set; }
        /// <summary>
        /// 路徑
        /// </summary>
        public string? Path { get; set; }
        /// <summary>
        /// 網頁標題
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 網頁描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 首頁
        /// </summary>
        public bool? IsIndex { get; set; }
        public string? HeaderColorMode { get; set; }
        public bool? Enable { get; set; }

        public virtual ICollection<TbPageSection> TbPageSections { get; set; }
    }
}
