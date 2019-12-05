
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace Domaine
{
    public class Forum
    {

        public Forum()
        {

        }
    [Key]
        public int id { get; set; }

        [ForeignKey("ProjectId")]

        public virtual project Project { get; set; }
    }
}