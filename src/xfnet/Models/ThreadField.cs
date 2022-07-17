using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: ThreadField. See https://xenforo.com/community/pages/api-endpoints/#type_ThreadField.
    /// </summary>
    public class ThreadField
    {
        public string field_id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public long? display_order { get; set; }

        public string field_type { get; set; }

        /// <summary>
        /// (Conditionally returned) For choice types, an ordered list of choices, with "option" and "name" keys for each.
        /// </summary>
        public List<FieldChoice> field_choices { get; set; }

        public string match_type { get; set; }

        public List<object> match_params { get; set; }

        public long? max_length { get; set; }

        public bool? required { get; set; }

        /// <summary>
        /// (Conditionally returned) If this field type supports grouping, the group this field belongs to.
        /// </summary>
        public string display_group { get; set; }
    }
}
