using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: Page. See https://xenforo.com/community/pages/api-endpoints/#type_Page.
    /// </summary>
    public class Page
    {
        public long? publish_date { get; set; }

        public long? view_count { get; set; }
    }
}
