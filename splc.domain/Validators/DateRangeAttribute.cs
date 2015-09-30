using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splc.domain.Validators
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimumValue)
            : base(typeof (DateTime), minimumValue, DateTime.Now.ToShortDateString())
        {
            
        }
    }
}
