using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splc.domain.Validators
{
   public class DobValidator : RangeAttribute
    {
       public DobValidator()
           : base(typeof(DateTime), DateTime.Now.AddYears(-100).ToShortDateString(), DateTime.Now.ToShortDateString())
       {

       }
    }
}


//DateTime.Now.AddYears(-100).ToShortDateString()