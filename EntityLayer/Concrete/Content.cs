using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace EntityLayer
{
    public class Content
    { [Key]
        public int ContentId { get; set; }
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public bool ContentStatus { get; set; }

    }
}
