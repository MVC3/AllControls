using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTMLControlsReference.ViewModels
{
    public class CheckBoxViewModel
    {
        public CheckBoxViewModel()
        { }
        
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }

        public CheckBoxViewModel(int id, string name, bool isChecked = false)
        {
            ID = id;
            Name = name;
            Checked = isChecked;
        }

    }
}