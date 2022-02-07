﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Writer

    {  [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(500)]
        public string writerAbout { get; set; }
        [StringLength(250)]
        public string WriterImage { get; set; }
        [StringLength(150)]
        public string WriterMail { get; set; }
        [StringLength(150)]
        public string writerPassword { get; set; }
        [StringLength(50)]
        public string  WriterTitle { get; set; }

        public bool WriterStatus { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}