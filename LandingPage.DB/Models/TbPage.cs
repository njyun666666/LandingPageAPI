using System;
using System.Collections.Generic;

namespace LandingPageDB.Models
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
        public string Path { get; set; } = null!;
        /// <summary>
        /// 網頁標題
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 網頁描述
        /// </summary>
        public string? Description { get; set; }
        public string? HeaderColorMode { get; set; }
        public bool Enable { get; set; }
        public bool BodyNavFixed { get; set; }

        public virtual ICollection<TbPageSection> TbPageSections { get; set; }
    }
}
