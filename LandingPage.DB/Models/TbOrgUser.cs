using System;
using System.Collections.Generic;

namespace LandingPageDB.Models
{
    public partial class TbOrgUser
    {
        public TbOrgUser()
        {
            Rids = new HashSet<TbOrgRole>();
        }

        public string Uid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Passwrod { get; set; }
        public bool Enable { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUid { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateUid { get; set; }

        public virtual ICollection<TbOrgRole> Rids { get; set; }
    }
}
