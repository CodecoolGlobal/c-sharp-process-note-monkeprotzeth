using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace process_note
{
    public class Comment
    {
        public List<string> Comments { get; set; }

        public Comment()
        {
            this.Comments = new List<string>();
        }

    }
}
