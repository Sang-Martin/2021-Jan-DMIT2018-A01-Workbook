using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    //this class will be used as a generic container for data
    //  that will load a dropdownlist (ddl)
    //this value field will represent a interger primary
    //the display field will represent the displayed string of the ddl
    public class SelectionList
    {
        public int ValueField { get; set; }
        public string DisplayField { get; set; }
    }
}
