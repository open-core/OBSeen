using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSeen.Models
{
    public class TimesheetEntryDTO : TimesheetEntryModel
    {
        public PersonModel Person { get; set; }
    }
}
