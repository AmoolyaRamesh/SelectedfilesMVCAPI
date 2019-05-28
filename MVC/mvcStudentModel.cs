using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcStudentModel
    {
        public int StuentId { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Stream { get; set; }
        public Nullable<int> StudentPercentage { get; set; }
    }
}