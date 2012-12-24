using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HTMLControlsReference.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string StateName { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}