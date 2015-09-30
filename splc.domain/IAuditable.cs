using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splc.domain
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set;  }
        DateTime ModifiedOn { get; set; }

        Guid CreatedBy { get; set; }
        Guid ModifiedBy { get; set; }

    }
}
