using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splc.domain
{
    public class Suspect : Person
    {
        
        public string SSN { get; set; }
        public string DriverLicenseNumber { get; set; }
        public int LicenseTypeId { get; set; }
        public virtual LicenseType LicenseType { get; set; }
        public int? DriverLicenseStateId { get; set; }
        public virtual State DriverLicenseState { get; set; }

        public DateTime? DeceasedDate { get; set; }

        public Guid ConfidentialityTypeId { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }

    }
}
