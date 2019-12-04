using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class EmployeeCommentaireViewModels
    {
        public Eval360ViewModels eval360 { get; set; }
        public List<CommentaireViewModels> commentaire { get; set; }
    }
}