using System;
using System.Collections.Generic;

namespace LandingPageDB.Models
{
    public partial class TbOrgRole
    {
        public TbOrgRole()
        {
            Uids = new HashSet<TbOrgUser>();
        }

        public string Rid { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public bool Enable { get; set; }

        public virtual ICollection<TbOrgUser> Uids { get; set; }
    }
}
