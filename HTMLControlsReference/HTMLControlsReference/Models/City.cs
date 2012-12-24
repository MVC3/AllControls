using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HTMLControlsReference.Models
{
    //[Table(name:"Cities")]
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }
        public virtual State State { get; set; }
    }
}