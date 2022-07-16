using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: LinkForum. See https://xenforo.com/community/pages/api-endpoints/#type_LinkForum.
    /// </summary>
    public class LinkForum
    {
        public string link_url { get; set; }

        public long? redirect_count { get; set; }
    }
}
